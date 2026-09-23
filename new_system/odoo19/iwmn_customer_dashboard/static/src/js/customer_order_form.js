/** @odoo-module **/

function numberValue(input) {
    const value = Number.parseFloat(input?.value || "0");
    return Number.isFinite(value) ? Math.max(0, value) : 0;
}

function formatNumber(value, maximumFractionDigits = 3) {
    return new Intl.NumberFormat("vi-VN", { maximumFractionDigits }).format(value);
}

function formatGroupedDigitsInput(input, groupSizes, separator) {
    const selectionStart = input.selectionStart ?? input.value.length;
    const digitsBeforeCaret = input.value.slice(0, selectionStart).replace(/\D/g, "").length;
    const maximumDigits = groupSizes.reduce((sum, size) => sum + size, 0);
    const digits = input.value.replace(/\D/g, "").slice(0, maximumDigits);
    const groups = [];
    let offset = 0;
    groupSizes.forEach((size) => {
        const group = digits.slice(offset, offset + size);
        if (group) groups.push(group);
        offset += size;
    });
    const formatted = groups.join(separator);
    input.value = formatted;

    if (document.activeElement !== input) return;
    let caret = 0;
    let seenDigits = 0;
    while (caret < formatted.length && seenDigits < digitsBeforeCaret) {
        if (/\d/.test(formatted[caret])) seenDigits += 1;
        caret += 1;
    }
    input.setSelectionRange(caret, caret);
}

function initializeContactFormatting(root) {
    const identitySelector = "[name='vehicle_driver_identity']";
    const phoneSelector = "[name='vehicle_driver_phone']";
    root.querySelectorAll(identitySelector).forEach((input) => {
        formatGroupedDigitsInput(input, [3, 3, 3, 3], ".");
    });
    root.querySelectorAll(phoneSelector).forEach((input) => {
        formatGroupedDigitsInput(input, [3, 3, 4], " ");
    });
    root.addEventListener("input", (event) => {
        if (event.target.matches(identitySelector)) {
            formatGroupedDigitsInput(event.target, [3, 3, 3, 3], ".");
        } else if (event.target.matches(phoneSelector)) {
            formatGroupedDigitsInput(event.target, [3, 3, 4], " ");
        }
    });
}

function initializeOrderForm(root) {
    const form = root.querySelector("form.iwmn-order-form");
    if (!form) return;
    const products = root.querySelector("[data-order-lines]");
    const productTemplate = root.querySelector("#iwmn-product-line-template");
    const orderShape = form.querySelector("[data-order-steel-shape]");
    const shapeConfirmation = form.querySelector("[data-shape-change-confirmed]");
    let previousOrderShape = orderShape.value;

    function initializeContractSearch() {
        const query = form.querySelector("[data-contract-search]");
        const contractId = form.querySelector("[name='contract_id']");
        const contractNumber = form.querySelector("[name='contract_number']");
        const suggestions = form.querySelector("[data-contract-suggestions]");
        if (!query || !contractId || !contractNumber || !suggestions) return;

        let searchTimer;
        let searchItems = [];
        let activeIndex = -1;
        let searchController;

        const closeSuggestions = () => {
            suggestions.hidden = true;
            activeIndex = -1;
        };
        const selectContract = (contract) => {
            contractId.value = String(contract.id);
            contractNumber.value = contract.code;
            query.value = contract.label;
            query.dataset.selectedLabel = contract.label;
            query.setCustomValidity("");
            closeSuggestions();
        };
        const renderSuggestions = (items) => {
            searchItems = items;
            activeIndex = -1;
            suggestions.replaceChildren();
            if (!items.length) {
                const empty = document.createElement("div");
                empty.className = "iwmn-product-suggestion-empty";
                empty.textContent = "Không tìm thấy hợp đồng còn hiệu lực";
                suggestions.append(empty);
            } else {
                items.forEach((contract, index) => {
                    const option = document.createElement("button");
                    option.type = "button";
                    option.className = "iwmn-contract-suggestion";
                    option.setAttribute("role", "option");
                    option.dataset.index = String(index);
                    const code = document.createElement("strong");
                    code.textContent = contract.code;
                    const name = document.createElement("span");
                    name.textContent = contract.name || contract.number || "Hợp đồng";
                    const dates = document.createElement("small");
                    dates.textContent = `Hiệu lực: ${contract.start_date} - ${contract.end_date}`;
                    option.append(code, name, dates);
                    option.addEventListener("mousedown", (event) => {
                        event.preventDefault();
                        selectContract(contract);
                    });
                    suggestions.append(option);
                });
            }
            suggestions.hidden = false;
        };
        const searchContracts = async () => {
            searchController?.abort();
            searchController = new AbortController();
            try {
                const response = await fetch(`/my/orders/contracts?q=${encodeURIComponent(query.value.trim())}`, {
                    credentials: "same-origin",
                    headers: { Accept: "application/json" },
                    signal: searchController.signal,
                });
                if (response.ok) renderSuggestions((await response.json()).items || []);
            } catch (error) {
                if (error.name !== "AbortError") closeSuggestions();
            }
        };

        query.addEventListener("input", () => {
            query.setCustomValidity("");
            if (query.value !== query.dataset.selectedLabel) {
                contractId.value = "";
                contractNumber.value = "";
            }
            clearTimeout(searchTimer);
            searchTimer = setTimeout(searchContracts, 250);
        });
        query.addEventListener("focus", searchContracts);
        query.addEventListener("blur", () => setTimeout(closeSuggestions, 120));
        query.addEventListener("keydown", (event) => {
            if (suggestions.hidden || !searchItems.length) return;
            if (event.key === "ArrowDown" || event.key === "ArrowUp") {
                event.preventDefault();
                activeIndex = event.key === "ArrowDown"
                    ? (activeIndex + 1) % searchItems.length
                    : (activeIndex - 1 + searchItems.length) % searchItems.length;
                suggestions.querySelectorAll(".iwmn-contract-suggestion").forEach((option, index) => {
                    option.classList.toggle("is-active", index === activeIndex);
                });
            } else if (event.key === "Enter" && activeIndex >= 0) {
                event.preventDefault();
                selectContract(searchItems[activeIndex]);
            } else if (event.key === "Escape") {
                closeSuggestions();
            }
        });
        if (contractId.value) query.dataset.selectedLabel = query.value;
    }

    function initializeWarehouseSearch() {
        const deliveryType = form.querySelector("[data-delivery-type]");
        const field = form.querySelector("[data-warehouse-field]");
        const query = form.querySelector("[data-warehouse-search]");
        const warehouseId = form.querySelector("[name='warehouse_id']");
        const warehouseCode = form.querySelector("[name='ma_kho']");
        const suggestions = form.querySelector("[data-warehouse-suggestions]");
        if (!deliveryType || !field || !query || !warehouseId || !warehouseCode || !suggestions) return;

        let searchTimer;
        let searchController;
        let searchItems = [];
        let activeIndex = -1;
        const closeSuggestions = () => {
            suggestions.hidden = true;
            activeIndex = -1;
        };
        const updateVisibility = () => {
            const isConsignment = deliveryType.value === "KG";
            field.hidden = !isConsignment;
            query.required = isConsignment;
            if (!isConsignment) {
                query.setCustomValidity("");
                closeSuggestions();
            }
        };
        const selectWarehouse = (warehouse) => {
            warehouseId.value = String(warehouse.id);
            warehouseCode.value = warehouse.code;
            query.value = warehouse.label;
            query.dataset.selectedLabel = warehouse.label;
            query.setCustomValidity("");
            closeSuggestions();
        };
        const renderSuggestions = (items) => {
            searchItems = items;
            activeIndex = -1;
            suggestions.replaceChildren();
            if (!items.length) {
                const empty = document.createElement("div");
                empty.className = "iwmn-product-suggestion-empty";
                empty.textContent = "Không tìm thấy kho phù hợp";
                suggestions.append(empty);
            } else {
                items.forEach((warehouse, index) => {
                    const option = document.createElement("button");
                    option.type = "button";
                    option.className = "iwmn-contract-suggestion";
                    option.setAttribute("role", "option");
                    option.dataset.index = String(index);
                    const code = document.createElement("strong");
                    code.textContent = warehouse.code;
                    const name = document.createElement("span");
                    name.textContent = warehouse.name || "Kho";
                    option.append(code, name);
                    option.addEventListener("mousedown", (event) => {
                        event.preventDefault();
                        selectWarehouse(warehouse);
                    });
                    suggestions.append(option);
                });
            }
            suggestions.hidden = false;
        };
        const searchWarehouses = async () => {
            if (field.hidden) return;
            searchController?.abort();
            searchController = new AbortController();
            try {
                const response = await fetch(`/my/orders/warehouses?q=${encodeURIComponent(query.value.trim())}`, {
                    credentials: "same-origin",
                    headers: { Accept: "application/json" },
                    signal: searchController.signal,
                });
                if (response.ok) renderSuggestions((await response.json()).items || []);
            } catch (error) {
                if (error.name !== "AbortError") closeSuggestions();
            }
        };
        query.addEventListener("input", () => {
            query.setCustomValidity("");
            if (query.value !== query.dataset.selectedLabel) {
                warehouseId.value = "";
                warehouseCode.value = "";
            }
            clearTimeout(searchTimer);
            searchTimer = setTimeout(searchWarehouses, 250);
        });
        query.addEventListener("focus", searchWarehouses);
        query.addEventListener("blur", () => setTimeout(closeSuggestions, 120));
        query.addEventListener("keydown", (event) => {
            if (suggestions.hidden || !searchItems.length) return;
            if (event.key === "ArrowDown" || event.key === "ArrowUp") {
                event.preventDefault();
                activeIndex = event.key === "ArrowDown"
                    ? (activeIndex + 1) % searchItems.length
                    : (activeIndex - 1 + searchItems.length) % searchItems.length;
                suggestions.querySelectorAll(".iwmn-contract-suggestion").forEach((option, index) => {
                    option.classList.toggle("is-active", index === activeIndex);
                });
            } else if (event.key === "Enter" && activeIndex >= 0) {
                event.preventDefault();
                selectWarehouse(searchItems[activeIndex]);
            } else if (event.key === "Escape") {
                closeSuggestions();
            }
        });
        deliveryType.addEventListener("change", updateVisibility);
        if (warehouseId.value) query.dataset.selectedLabel = query.value;
        updateVisibility();
    }

    function initializeProjectSearch() {
        const query = form.querySelector("[data-project-search]");
        const projectId = form.querySelector("[name='project_id']");
        const suggestions = form.querySelector("[data-project-suggestions]");
        const appendixQuery = form.querySelector("[data-project-appendix-search]");
        const appendixId = form.querySelector("[name='project_appendix_id']");
        if (!query || !projectId || !suggestions) return;

        let searchTimer;
        let searchItems = [];
        let activeIndex = -1;
        let searchController;

        const closeSuggestions = () => {
            suggestions.hidden = true;
            activeIndex = -1;
        };
        const resetAppendix = () => {
            if (!appendixQuery || !appendixId) return;
            appendixId.value = "";
            appendixQuery.value = "";
            appendixQuery.dataset.selectedLabel = "";
            appendixQuery.disabled = !projectId.value;
            appendixQuery.setCustomValidity("");
        };
        const selectProject = (item) => {
            projectId.value = String(item.id);
            query.value = item.label;
            query.dataset.selectedLabel = item.label;
            query.setCustomValidity("");
            resetAppendix();
            if (appendixQuery) appendixQuery.disabled = false;
            closeSuggestions();
        };
        const renderSuggestions = (items) => {
            searchItems = items;
            activeIndex = -1;
            suggestions.replaceChildren();
            if (!items.length) {
                const empty = document.createElement("div");
                empty.className = "iwmn-product-suggestion-empty";
                empty.textContent = "Không tìm thấy công trình phù hợp";
                suggestions.append(empty);
            } else {
                items.forEach((item, index) => {
                    const option = document.createElement("button");
                    option.type = "button";
                    option.className = "iwmn-contract-suggestion";
                    option.setAttribute("role", "option");
                    option.dataset.index = String(index);
                    const code = document.createElement("strong");
                    code.textContent = item.code || "Không có mã công trình";
                    const name = document.createElement("small");
                    name.textContent = item.name || "Không có tên công trình";
                    option.append(code, name);
                    option.addEventListener("mousedown", (event) => {
                        event.preventDefault();
                        selectProject(item);
                    });
                    suggestions.append(option);
                });
            }
            suggestions.hidden = false;
        };
        const searchProjects = async () => {
            searchController?.abort();
            searchController = new AbortController();
            try {
                const response = await fetch(
                    `/my/orders/projects?q=${encodeURIComponent(query.value.trim())}`,
                    {
                        credentials: "same-origin",
                        headers: { Accept: "application/json" },
                        signal: searchController.signal,
                    }
                );
                if (response.ok) renderSuggestions((await response.json()).items || []);
            } catch (error) {
                if (error.name !== "AbortError") closeSuggestions();
            }
        };

        query.addEventListener("input", () => {
            query.setCustomValidity("");
            if (query.value !== query.dataset.selectedLabel) {
                projectId.value = "";
                resetAppendix();
            }
            clearTimeout(searchTimer);
            searchTimer = setTimeout(searchProjects, 250);
        });
        query.addEventListener("focus", searchProjects);
        query.addEventListener("blur", () => setTimeout(closeSuggestions, 120));
        query.addEventListener("keydown", (event) => {
            if (suggestions.hidden || !searchItems.length) return;
            if (event.key === "ArrowDown" || event.key === "ArrowUp") {
                event.preventDefault();
                activeIndex = event.key === "ArrowDown"
                    ? (activeIndex + 1) % searchItems.length
                    : (activeIndex - 1 + searchItems.length) % searchItems.length;
                suggestions.querySelectorAll(".iwmn-contract-suggestion").forEach((option, index) => {
                    option.classList.toggle("is-active", index === activeIndex);
                });
            } else if (event.key === "Enter" && activeIndex >= 0) {
                event.preventDefault();
                selectProject(searchItems[activeIndex]);
            } else if (event.key === "Escape") {
                closeSuggestions();
            }
        });
        if (projectId.value) query.dataset.selectedLabel = query.value;
        if (appendixQuery) appendixQuery.disabled = !projectId.value;
    }

    function initializeProjectAppendixSearch() {
        const query = form.querySelector("[data-project-appendix-search]");
        const projectAppendixId = form.querySelector("[name='project_appendix_id']");
        const projectId = form.querySelector("[name='project_id']");
        const suggestions = form.querySelector("[data-project-appendix-suggestions]");
        if (!query || !projectAppendixId || !projectId || !suggestions) return;

        let searchTimer;
        let searchItems = [];
        let activeIndex = -1;
        let searchController;

        const closeSuggestions = () => {
            suggestions.hidden = true;
            activeIndex = -1;
        };
        const selectProjectAppendix = (item) => {
            projectAppendixId.value = String(item.id);
            query.value = item.label;
            query.dataset.selectedLabel = item.label;
            query.setCustomValidity("");
            closeSuggestions();
        };
        const renderSuggestions = (items) => {
            searchItems = items;
            activeIndex = -1;
            suggestions.replaceChildren();
            if (!items.length) {
                const empty = document.createElement("div");
                empty.className = "iwmn-product-suggestion-empty";
                empty.textContent = "Không tìm thấy phụ lục thuộc công trình đã chọn";
                suggestions.append(empty);
            } else {
                items.forEach((item, index) => {
                    const option = document.createElement("button");
                    option.type = "button";
                    option.className = "iwmn-contract-suggestion";
                    option.setAttribute("role", "option");
                    option.dataset.index = String(index);
                    const appendixCode = document.createElement("strong");
                    appendixCode.textContent = item.appendix_code || "Không có mã phụ lục";
                    const name = document.createElement("small");
                    name.textContent = item.name || "Không có tên phụ lục";
                    option.append(appendixCode, name);
                    option.addEventListener("mousedown", (event) => {
                        event.preventDefault();
                        selectProjectAppendix(item);
                    });
                    suggestions.append(option);
                });
            }
            suggestions.hidden = false;
        };
        const searchProjectAppendices = async () => {
            if (!projectId.value) {
                closeSuggestions();
                return;
            }
            searchController?.abort();
            searchController = new AbortController();
            try {
                const response = await fetch(
                    `/my/orders/project-appendices?project_id=${encodeURIComponent(projectId.value)}&q=${encodeURIComponent(query.value.trim())}`,
                    {
                        credentials: "same-origin",
                        headers: { Accept: "application/json" },
                        signal: searchController.signal,
                    }
                );
                if (response.ok) renderSuggestions((await response.json()).items || []);
            } catch (error) {
                if (error.name !== "AbortError") closeSuggestions();
            }
        };

        query.addEventListener("input", () => {
            query.setCustomValidity("");
            if (query.value !== query.dataset.selectedLabel) projectAppendixId.value = "";
            clearTimeout(searchTimer);
            searchTimer = setTimeout(searchProjectAppendices, 250);
        });
        query.addEventListener("focus", searchProjectAppendices);
        query.addEventListener("blur", () => setTimeout(closeSuggestions, 120));
        query.addEventListener("keydown", (event) => {
            if (suggestions.hidden || !searchItems.length) return;
            if (event.key === "ArrowDown" || event.key === "ArrowUp") {
                event.preventDefault();
                activeIndex = event.key === "ArrowDown"
                    ? (activeIndex + 1) % searchItems.length
                    : (activeIndex - 1 + searchItems.length) % searchItems.length;
                suggestions.querySelectorAll(".iwmn-contract-suggestion").forEach((option, index) => {
                    option.classList.toggle("is-active", index === activeIndex);
                });
            } else if (event.key === "Enter" && activeIndex >= 0) {
                event.preventDefault();
                selectProjectAppendix(searchItems[activeIndex]);
            } else if (event.key === "Escape") {
                closeSuggestions();
            }
        });
        if (projectAppendixId.value) query.dataset.selectedLabel = query.value;
        query.disabled = !projectId.value;
    }

    function updateTotals() {
        const selectedLines = [...products.querySelectorAll("[data-order-line]")]
            .filter((line) => line.querySelector("[name='line_product_id']")?.value);
        const total = selectedLines.reduce((sum, line) => sum + Number.parseFloat(line.dataset.weight || "0"), 0);
        const totalBars = selectedLines.reduce((sum, line) => {
            if (line.querySelector("[name='line_product_type']")?.value !== "bar") return sum;
            return sum + Math.floor(numberValue(line.querySelector("[name='line_total_bar_qty']")));
        }, 0);
        const totalCoils = selectedLines.reduce((sum, line) => {
            return sum + (line.querySelector("[name='line_product_type']")?.value === "coil"
                ? Math.floor(numberValue(line.querySelector("[name='line_coil_cut_qty']"))) : 0);
        }, 0);
        const totalAmount = selectedLines.reduce((sum, line) => {
            return sum + Number.parseFloat(line.dataset.weight || "0")
                * numberValue(line.querySelector("[name='line_customer_unit_price']"));
        }, 0);
        root.querySelector("[data-order-total-weight]").textContent = `${formatNumber(total, 0)} kg`;
        root.querySelectorAll("[data-cart-item-count]").forEach((output) => { output.textContent = String(selectedLines.length); });
        root.querySelector("[data-cart-total-bars]").textContent = formatNumber(totalBars, 0);
        root.querySelector("[data-cart-total-coils]").textContent = formatNumber(totalCoils, 0);
        root.querySelector("[data-cart-total-weight]").textContent = `${formatNumber(total, 0)} kg`;
        root.querySelector("[data-cart-total-amount]").textContent = `${formatNumber(totalAmount, 0)} ₫`;
        root.querySelector("[data-cart-empty]").hidden = products.querySelectorAll("[data-order-line]").length > 0;
    }

    function updateCartRow(line) {
        const type = line.querySelector("[name='line_product_type']").value;
        const query = line.querySelector("[name='line_product_query']").value.trim();
        const size = line.querySelector("[name='line_size_code']").value.trim();
        const grade = line.querySelector("[name='line_steel_grade']").value.trim();
        const length = numberValue(line.querySelector("[name='line_length_m']"));
        const weight = Number.parseFloat(line.dataset.weight || "0");
        const price = numberValue(line.querySelector("[name='line_customer_unit_price']"));
        line.querySelector("[data-cart-name]").textContent = query || "Chưa chọn sản phẩm";
        const shape = line.querySelector("[name='line_steel_shape']").value === "bent" ? "Bẻ cong" : "Thẳng";
        const hasProduct = Boolean(line.querySelector("[name='line_product_id']").value);
        line.querySelector("[data-cart-spec]").textContent = [size, grade, hasProduct ? `${formatNumber(length)} m` : "", shape]
            .filter(Boolean).join(" · ");
        line.querySelector("[data-cart-quantity]").textContent = type === "bar"
            ? `${formatNumber(Math.floor(numberValue(line.querySelector("[name='line_total_bar_qty']"))), 0)} cây`
            : `${formatNumber(Math.floor(numberValue(line.querySelector("[name='line_coil_cut_qty']"))), 0)} cuộn`;
        line.querySelector("[data-cart-conversion]").textContent = line.querySelector("[data-line-conversion]").textContent;
        line.querySelector("[data-cart-weight]").textContent = `${formatNumber(weight, 0)} kg`;
        line.querySelector("[data-cart-price]").textContent = price > 0
            ? `${formatNumber(price, 0)} ₫/kg (tham khảo)` : "Chưa nhập giá";
    }

    function updateIndexes() {
        products.querySelectorAll("[data-order-line]").forEach((line, index) => {
            line.querySelectorAll("[data-line-number]").forEach((number) => { number.textContent = String(index + 1); });
        });
    }

    function setLineMode(line) {
        const isBar = line.querySelector("[name='line_product_type']").value === "bar";
        line.querySelectorAll(".iwmn-bar-field").forEach((field) => { field.hidden = !isBar; });
        line.querySelectorAll(".iwmn-coil-field").forEach((field) => { field.hidden = isBar; });
        line.querySelector("[name='line_requested_weight_kg']").required = !isBar;
        line.querySelector("[name='line_coil_cut_qty']").required = !isBar;
    }

    function normalizeBarInputs(line) {
        const barsPerBundle = Number.parseInt(line.dataset.barsPerBundle || "0", 10);
        const bundleInput = line.querySelector("[name='line_order_bundle_qty']");
        const looseInput = line.querySelector("[name='line_order_loose_bar_qty']");
        const totalInput = line.querySelector("[name='line_total_bar_qty']");
        const bundleLabel = line.querySelector("[data-bars-per-bundle-label]");
        bundleLabel.textContent = barsPerBundle > 0
            ? `1 bó = ${formatNumber(barsPerBundle, 0)} cây`
            : "Chọn vật tư để xem số cây mỗi bó.";
        if (barsPerBundle <= 0) {
            totalInput.value = "0";
            return 0;
        }
        let bundles = Math.floor(numberValue(bundleInput));
        let looseBars = Math.floor(numberValue(looseInput));
        if (looseBars >= barsPerBundle) {
            bundles += Math.floor(looseBars / barsPerBundle);
            looseBars %= barsPerBundle;
            bundleInput.value = String(bundles);
            looseInput.value = String(looseBars);
        }
        const totalBars = bundles * barsPerBundle + looseBars;
        totalInput.value = String(totalBars);
        return totalBars;
    }

    async function calculateLine(line) {
        line.calculateRevision = (line.calculateRevision || 0) + 1;
        const revision = line.calculateRevision;
        line.weightController?.abort();
        setLineMode(line);
        const type = line.querySelector("[name='line_product_type']").value;
        const conversion = line.querySelector("[data-line-conversion]");
        let weight = 0;
        if (type === "bar") {
            line.dataset.weight = "0";
            line.querySelector("[data-line-weight]").textContent = "Đang tính kg...";
            updateCartRow(line);
            updateTotals();
        }
        if (type === "coil") {
            weight = Math.round(numberValue(line.querySelector("[name='line_requested_weight_kg']")));
            conversion.textContent = `${formatNumber(Math.floor(numberValue(line.querySelector("[name='line_coil_cut_qty']"))), 0)} cuộn cần cắt · nhập trực tiếp theo kg`;
        } else {
            let totalBars = normalizeBarInputs(line);
            const productId = line.querySelector("[name='line_product_id']").value;
            if (productId) {
                const key = productId;
                if (line.dataset.baremKey !== key) {
                    try {
                        const params = new URLSearchParams({ product_id: productId });
                        const response = await fetch(`/my/orders/barem?${params}`, { credentials: "same-origin" });
                        if (response.ok) {
                            const barem = await response.json();
                            line.dataset.baremKey = key;
                            line.dataset.barWeight = String(barem.bar_weight_kg || 0);
                            line.dataset.bundleWeight = String(barem.bundle_weight_kg || 0);
                            line.dataset.barsPerBundle = String(barem.bars_per_bundle || 0);
                        }
                    } catch {
                        // Server validates barem again when the form is submitted.
                    }
                }
                if (revision !== line.calculateRevision) return;
                const barsPerBundle = Number.parseInt(line.dataset.barsPerBundle || "0", 10);
                totalBars = normalizeBarInputs(line);
                if (barsPerBundle > 0 && totalBars > 0) {
                    const bundles = Math.floor(totalBars / barsPerBundle);
                    const looseBars = totalBars % barsPerBundle;
                    conversion.textContent = `${formatNumber(totalBars, 0)} cây = ${bundles} bó + ${looseBars} cây lẻ · đang tính kg`;
                    line.weightController = new AbortController();
                    try {
                        const params = new URLSearchParams({ product_id: productId, total_bar_qty: String(totalBars) });
                        const response = await fetch(`/my/orders/weight?${params}`, {
                            credentials: "same-origin", signal: line.weightController.signal,
                        });
                        if (!response.ok) throw new Error("Barem API unavailable");
                        weight = Number((await response.json()).weight_kg) || 0;
                        if (revision !== line.calculateRevision) return;
                        conversion.textContent = `${formatNumber(totalBars, 0)} cây = ${bundles} bó + ${looseBars} cây lẻ`;
                    } catch (error) {
                        if (error.name === "AbortError") return;
                        if (revision !== line.calculateRevision) return;
                        conversion.textContent = "Không tính được kg từ hệ thống TMN. Vui lòng thử lại.";
                    }
                } else {
                    conversion.textContent = barsPerBundle > 0 ? "Nhập số bó hoặc số cây lẻ" : "Chưa có số cây/bó của vật tư";
                }
            } else {
                conversion.textContent = "Chọn sản phẩm rồi nhập số bó hoặc cây lẻ";
            }
        }
        line.dataset.weight = String(weight);
        if (weight > 0 && line.querySelector("[name='line_product_id']")?.value) {
            line.querySelector("[name='line_product_query']").setCustomValidity("");
        }
        line.querySelector("[data-line-weight]").textContent = `${formatNumber(weight, 0)} kg`;
        updateCartRow(line);
        updateTotals();
    }

    function initializeLine(line) {
        if (!line.querySelector("[name='line_coil_cut_qty']")) {
            const field = document.createElement("label");
            field.className = "iwmn-field iwmn-coil-field";
            const caption = document.createElement("span");
            caption.textContent = "Số cuộn cần cắt *";
            const input = document.createElement("input");
            input.type = "number";
            input.min = "1";
            input.step = "1";
            input.name = "line_coil_cut_qty";
            field.append(caption, input);
            line.querySelector("[name='line_requested_weight_kg']").closest("label").after(field);
        }
        let timer;
        const schedule = () => {
            clearTimeout(timer);
            timer = setTimeout(() => calculateLine(line), 180);
        };
        line.addEventListener("input", (event) => {
            if (event.target.matches("[name='line_order_bundle_qty'], [name='line_order_loose_bar_qty']")) {
                normalizeBarInputs(line);
            }
            schedule();
        });
        line.addEventListener("change", schedule);
        const query = line.querySelector("[name='line_product_query']");
        const productId = line.querySelector("[name='line_product_id']");
        const suggestions = line.querySelector("[data-product-suggestions]");
        let searchTimer;
        let searchItems = [];
        let activeIndex = -1;
        let searchController;
        const knownSizes = new Set();

        function closeSuggestions() {
            suggestions.hidden = true;
            activeIndex = -1;
        }

        function updateProductSummary() {
            const summary = line.querySelector("[data-product-summary]");
            const selected = Boolean(productId.value);
            summary.classList.toggle("is-selected", selected);
            if (!selected) {
                summary.textContent = "Chọn hoặc gõ size → mác thép → chiều dài.";
                return;
            }
            const size = line.querySelector("[name='line_size_code']").value.trim();
            const grade = line.querySelector("[name='line_steel_grade']").value.trim();
            const length = numberValue(line.querySelector("[name='line_length_m']"));
            summary.textContent = [
                size && `Size: ${size}`,
                grade && `Mác thép: ${grade}`,
                `Chiều dài: ${formatNumber(length)} m`,
            ].filter(Boolean).join(" · ") || "Đã chọn vật tư";
        }

        function selectProduct(product) {
            const label = `${product.code} - ${product.name}`;
            productId.value = String(product.id);
            query.value = label;
            query.dataset.selectedLabel = label;
            delete query.dataset.quickSize;
            delete query.dataset.quickGrade;
            line.querySelector("[name='line_product_type']").value = product.product_type;
            line.querySelector("[data-product-type-label]").value = product.product_type === "coil" ? "Thép cuộn" : "Thép cây";
            line.querySelector("[name='line_size_code']").value = product.size_code || "";
            line.querySelector("[name='line_steel_grade']").value = product.steel_grade || "";
            line.querySelector("[name='line_length_m']").value = product.length_m ?? "";
            updateProductSummary();
            line.dataset.barsPerBundle = String(product.num_bars || 0);
            line.dataset.baremKey = String(product.id);
            normalizeBarInputs(line);
            line.querySelector("[data-cart-image]").src = product.image_url;
            line.querySelector("[data-cart-image]").alt = product.name || product.code;
            closeSuggestions();
            calculateLine(line);
        }

        function quickContext(value) {
            if (!value.trim()) return { stage: "size", size: "", q: "" };
            const selectedSize = query.dataset.quickSize;
            const selectedGrade = query.dataset.quickGrade;
            if (selectedSize && value.toLowerCase().startsWith(`${selectedSize} `.toLowerCase())) {
                const remainder = value.slice(selectedSize.length + 1);
                if (selectedGrade && remainder.toLowerCase().startsWith(`${selectedGrade} `.toLowerCase())) {
                    return { stage: "length", size: selectedSize, grade: selectedGrade, q: remainder.slice(selectedGrade.length + 1).trim() };
                }
                return { stage: "grade", size: selectedSize, q: remainder.trim() };
            }
            const tokens = value.trim().split(/\s+/);
            const reversedSize = /^(\d+)([a-z])$/i.exec(tokens[0]);
            const size = reversedSize ? `${reversedSize[2].toUpperCase()}${reversedSize[1]}` : tokens[0];
            if (tokens.length >= 2 && knownSizes.has(size.toLowerCase())) {
                return { stage: "grade", size, q: value.trim().slice(tokens[0].length).trim() };
            }
            if (tokens.length > 3) return null;
            const trailingSpace = /\s$/.test(value);
            if (tokens.length === 1) return {
                stage: trailingSpace ? "grade" : "size",
                size, q: trailingSpace ? "" : tokens[0],
            };
            if (tokens.length === 2) return { stage: trailingSpace ? "length" : "grade", size, grade: tokens[1], q: trailingSpace ? "" : tokens[1] };
            return { stage: "length", size, grade: tokens[1], q: tokens[2] };
        }

        function chooseQuickOption(stage, choice, context) {
            const value = typeof choice === "string" ? choice : choice.code;
            query.value = stage === "size" ? `${value} `
                : stage === "grade" ? `${context.size} ${value} `
                    : `${context.size} ${context.grade} ${value}`;
            if (stage === "size") {
                query.dataset.quickSize = value;
                delete query.dataset.quickGrade;
            } else if (stage === "grade") {
                query.dataset.quickSize = context.size;
                query.dataset.quickGrade = value;
            }
            productId.value = "";
            closeSuggestions();
            searchProducts();
            query.focus();
        }

        function renderQuickSuggestions(stage, options, context) {
            searchItems = options.map((choice) => ({
                quickStage: stage,
                value: typeof choice === "string" ? choice : choice.code,
                name: typeof choice === "string" ? "" : choice.name,
                context,
            }));
            activeIndex = -1;
            suggestions.replaceChildren();
            if (!searchItems.length) {
                const empty = document.createElement("div");
                empty.className = "iwmn-product-suggestion-empty";
                empty.textContent = "Không tìm thấy size, mác hoặc chiều dài phù hợp";
                suggestions.append(empty);
            }
            searchItems.forEach((item, index) => {
                const option = document.createElement("button");
                option.type = "button";
                option.className = "iwmn-product-suggestion is-quick";
                option.setAttribute("role", "option");
                option.dataset.index = String(index);
                const title = document.createElement("strong");
                title.textContent = item.value;
                const description = document.createElement("span");
                description.textContent = stage === "grade" && item.name
                    ? item.name : ({ size: "Chọn size", grade: "Chọn mác thép", length: "Chọn chiều dài (m)" })[stage];
                option.append(title, description);
                option.addEventListener("mousedown", (event) => {
                    event.preventDefault();
                    chooseQuickOption(item.quickStage, item.value, item.context);
                });
                suggestions.append(option);
            });
            suggestions.hidden = false;
        }

        function renderSuggestions(items) {
            searchItems = items;
            activeIndex = -1;
            suggestions.replaceChildren();
            if (!items.length) {
                const empty = document.createElement("div");
                empty.className = "iwmn-product-suggestion-empty";
                empty.textContent = "Không tìm thấy sản phẩm phù hợp";
                suggestions.append(empty);
            } else {
                items.forEach((product, index) => {
                    const option = document.createElement("button");
                    option.type = "button";
                    option.className = "iwmn-product-suggestion";
                    option.setAttribute("role", "option");
                    option.dataset.index = String(index);
                    const image = document.createElement("img");
                    image.src = product.image_url;
                    image.alt = "";
                    const code = document.createElement("strong");
                    code.textContent = product.code;
                    const name = document.createElement("span");
                    name.textContent = product.name;
                    const details = document.createElement("small");
                    details.textContent = [product.size_code, product.steel_grade, product.length_m != null ? `${formatNumber(product.length_m)} m` : "", product.uom]
                        .filter(Boolean).join(" · ");
                    option.append(image, code, name, details);
                    option.addEventListener("mousedown", (event) => {
                        event.preventDefault();
                        selectProduct(product);
                    });
                    suggestions.append(option);
                });
            }
            suggestions.hidden = false;
        }

        async function searchProducts(showAllSizes = false) {
            const term = query.value.trim();
            searchController?.abort();
            searchController = new AbortController();
            const context = showAllSizes ? { stage: "size", size: "", q: "" } : quickContext(query.value);
            const capturedValue = query.value;
            try {
                const params = context
                    ? new URLSearchParams({ stage: context.stage, size: context.size, grade: context.grade || "", q: context.q })
                    : new URLSearchParams({ q: term });
                const path = context ? "/my/orders/products/quick" : "/my/orders/products";
                const response = await fetch(`${path}?${params}`, {
                    credentials: "same-origin",
                    headers: { Accept: "application/json" },
                    signal: searchController.signal,
                });
                if (!response.ok || query.value !== capturedValue) return;
                const data = await response.json();
                if (query.value !== capturedValue) return;
                if (context?.stage === "size") {
                    (data.options || []).forEach((size) => knownSizes.add(size.toLowerCase()));
                }
                if (!context) {
                    renderSuggestions(data.items || []);
                } else if (context.stage === "size" && !data.options?.length && term.length >= 5) {
                    const fallback = await fetch(`/my/orders/products?q=${encodeURIComponent(term)}`, {
                        credentials: "same-origin", signal: searchController.signal,
                    });
                    if (fallback.ok && query.value === capturedValue) renderSuggestions((await fallback.json()).items || []);
                } else if (data.unique_product) {
                    selectProduct(data.unique_product);
                } else if (data.unique && context.stage !== "length") {
                    chooseQuickOption(context.stage, data.options[0], context);
                } else if (data.products?.length) {
                    renderSuggestions(data.products);
                } else {
                    renderQuickSuggestions(context.stage, data.options || [], context);
                }
            } catch (error) {
                if (error.name !== "AbortError") closeSuggestions();
            }
        }

        query.addEventListener("input", () => {
            query.setCustomValidity("");
            if (query.value !== query.dataset.selectedLabel) {
                productId.value = "";
                line.querySelector("[name='line_product_type']").value = "bar";
                line.querySelector("[data-product-type-label]").value = "Chọn sản phẩm để xác định";
            }
            updateProductSummary();
            clearTimeout(searchTimer);
            searchTimer = setTimeout(searchProducts, 250);
        });
        query.addEventListener("focus", () => searchProducts(true));
        query.addEventListener("blur", () => setTimeout(closeSuggestions, 120));
        query.addEventListener("keydown", (event) => {
            if (suggestions.hidden || !searchItems.length) return;
            if (event.key === "ArrowDown" || event.key === "ArrowUp") {
                event.preventDefault();
                activeIndex = event.key === "ArrowDown"
                    ? (activeIndex + 1) % searchItems.length
                    : (activeIndex - 1 + searchItems.length) % searchItems.length;
                suggestions.querySelectorAll(".iwmn-product-suggestion").forEach((option, index) => {
                    option.classList.toggle("is-active", index === activeIndex);
                });
            } else if (event.key === "Enter" && activeIndex >= 0) {
                event.preventDefault();
                const item = searchItems[activeIndex];
                if (item.quickStage) chooseQuickOption(item.quickStage, item.value, item.context);
                else selectProduct(item);
            } else if (event.key === "Escape") {
                closeSuggestions();
            }
        });
        if (productId.value) query.dataset.selectedLabel = query.value;
        updateProductSummary();
        normalizeBarInputs(line);
        calculateLine(line);
    }

    function initializeDriverVehicleLookup() {
        const identity = form.querySelector("[name='vehicle_driver_identity']");
        const orderDate = form.querySelector("[name='order_date']");
        const driverName = form.querySelector("[name='vehicle_driver_name']");
        const vehicleNumber = form.querySelector("[name='vehicle_license_plate']");
        const bargeNumber = form.querySelector("[name='vehicle_barge_number']");
        const status = form.querySelector("[data-driver-lookup-status]");
        if (!identity || !orderDate || !driverName || !vehicleNumber || !bargeNumber || !status) return;

        let lookupTimer;
        let lookupController;
        let lastIdentity = identity.value.replace(/\D/g, "");

        const setStatus = (message, state = "") => {
            status.textContent = message;
            status.classList.toggle("is-loading", state === "loading");
            status.classList.toggle("is-found", state === "found");
            status.classList.toggle("is-error", state === "error");
        };
        const lookup = async () => {
            const digits = identity.value.replace(/\D/g, "");
            if (![9, 12].includes(digits.length) || digits === lastIdentity) return;
            lastIdentity = digits;
            lookupController?.abort();
            lookupController = new AbortController();
            setStatus("Đang tìm thông tin tài xế và phương tiện gần nhất...", "loading");
            try {
                const response = await fetch(
                    `/my/orders/driver-vehicle?identity=${encodeURIComponent(identity.value)}&document_date=${encodeURIComponent(orderDate.value)}`,
                    {
                        credentials: "same-origin",
                        headers: { Accept: "application/json" },
                        signal: lookupController.signal,
                    }
                );
                const payload = await response.json();
                if (!response.ok) {
                    setStatus(payload.error || "Không lấy được thông tin tài xế.", "error");
                    return;
                }
                if (!payload.found) {
                    setStatus("Không tìm thấy dữ liệu tài xế trong 3 năm gần nhất.");
                    return;
                }
                if (payload.driver_name) driverName.value = payload.driver_name;
                if (payload.vehicle_number) vehicleNumber.value = payload.vehicle_number;
                if (payload.barge_number) bargeNumber.value = payload.barge_number;
                setStatus("Đã tự động điền thông tin gần nhất; anh/chị có thể chỉnh lại nếu cần.", "found");
            } catch (error) {
                if (error.name !== "AbortError") {
                    setStatus("Không thể kết nối để tìm thông tin tài xế.", "error");
                }
            }
        };
        identity.addEventListener("input", () => {
            const digits = identity.value.replace(/\D/g, "");
            if (![9, 12].includes(digits.length)) {
                lastIdentity = "";
                setStatus("Nhập đủ CCCD/CMT để tự động tìm tên tài xế và phương tiện gần nhất.");
                clearTimeout(lookupTimer);
                return;
            }
            clearTimeout(lookupTimer);
            lookupTimer = setTimeout(lookup, 350);
        });
        identity.addEventListener("blur", lookup);
        orderDate.addEventListener("change", () => {
            lastIdentity = "";
            lookup();
        });
    }

    function updateTransportFields() {
        const method = form.querySelector("[data-transport-method]").value;
        root.querySelectorAll(".iwmn-truck-field").forEach((field) => {
            field.hidden = false;
            field.querySelector("input")?.toggleAttribute("required", method === "xe");
            field.querySelector("[data-truck-required-mark]")?.toggleAttribute("hidden", method !== "xe");
        });
        root.querySelectorAll(".iwmn-barge-field").forEach((field) => {
            field.hidden = false;
            field.querySelector("input")?.toggleAttribute("required", method === "salan");
            field.querySelector("[data-barge-required-mark]")?.toggleAttribute("hidden", method !== "salan");
        });
    }

    function addOrderLine() {
        const fragment = productTemplate.content.cloneNode(true);
        const line = fragment.querySelector("[data-order-line]");
        line.querySelector("[name='line_steel_shape']").value = orderShape.value === "bent" ? "bent" : "straight";
        products.append(fragment);
        initializeLine(line);
        updateIndexes();
        updateTotals();
        products.scrollTo({ top: products.scrollHeight, behavior: "smooth" });
        line.querySelector("[data-product-search]").focus();
    }
    root.querySelectorAll("[data-add-order-line]").forEach((button) => {
        button.addEventListener("click", addOrderLine);
    });
    root.addEventListener("click", (event) => {
        const editButton = event.target.closest("[data-edit-cart-item]");
        if (editButton) {
            editButton.closest("[data-order-line]").classList.remove("is-collapsed");
            return;
        }
        const closeButton = event.target.closest("[data-close-editor]");
        if (closeButton) {
            const line = closeButton.closest("[data-order-line]");
            if (line.querySelector("[name='line_product_id']").value) line.classList.add("is-collapsed");
            return;
        }
        const addToCart = event.target.closest("[data-add-to-cart]");
        if (addToCart) {
            const line = addToCart.closest("[data-order-line]");
            const productInput = line.querySelector("[name='line_product_query']");
            const productIdInput = line.querySelector("[name='line_product_id']");
            productInput.setCustomValidity(productIdInput.value ? "" : "Vui lòng chọn sản phẩm trong danh sách gợi ý.");
            const requiredInputs = [...line.querySelectorAll("[data-product-editor] [required]")]
                .filter((input) => !input.closest("[hidden]"));
            const invalid = requiredInputs.find((input) => !input.checkValidity());
            if (invalid) {
                invalid.reportValidity();
                invalid.focus();
                return;
            }
            productInput.setCustomValidity("");
            line.classList.add("is-collapsed");
            updateCartRow(line);
            updateTotals();
            return;
        }
        const button = event.target.closest("[data-remove-row]");
        if (!button) return;
        const row = button.closest("[data-order-line]");
        row.remove();
        updateIndexes();
        updateTotals();
    });
    form.querySelector("[data-transport-method]").addEventListener("change", updateTransportFields);
    orderShape.addEventListener("change", () => {
        const nextShape = orderShape.value;
        if (nextShape === "mixed") {
            shapeConfirmation.value = "0";
            previousOrderShape = nextShape;
            return;
        }
        const completedLines = [...products.querySelectorAll("[data-order-line]")]
            .filter((line) => line.querySelector("[name='line_product_id']")?.value);
        const existingShapes = new Set(completedLines.map((line) => line.querySelector("[name='line_steel_shape']").value));
        if (existingShapes.size > 1) {
            const label = nextShape === "bent" ? "Bẻ cong" : "Thẳng";
            if (!window.confirm(`Chi tiết đơn hàng đang có cả Thẳng và Bẻ cong. Bạn có muốn đổi toàn bộ sản phẩm sang ${label} không?`)) {
                orderShape.value = previousOrderShape;
                return;
            }
            shapeConfirmation.value = "1";
        }
        products.querySelectorAll("[name='line_steel_shape']").forEach((select) => {
            select.value = nextShape;
            updateCartRow(select.closest("[data-order-line]"));
        });
        previousOrderShape = nextShape;
    });
    initializeContactFormatting(root);
    initializeDriverVehicleLookup();
    initializeProjectSearch();
    initializeProjectAppendixSearch();
    form.addEventListener("submit", (event) => {
        const contractQuery = form.querySelector("[data-contract-search]");
        const contractId = form.querySelector("[name='contract_id']");
        if (contractQuery && contractId) {
            contractQuery.setCustomValidity(
                contractQuery.value.trim() && !contractId.value
                    ? "Vui lòng chọn hợp đồng trong danh sách gợi ý."
                    : ""
            );
        }
        const projectQuery = form.querySelector("[data-project-search]");
        const projectId = form.querySelector("[name='project_id']");
        if (projectQuery && projectId) {
            projectQuery.setCustomValidity(
                projectQuery.value.trim() && !projectId.value
                    ? "Vui lòng chọn công trình trong danh sách gợi ý."
                    : ""
            );
        }
        const projectAppendixQuery = form.querySelector("[data-project-appendix-search]");
        const projectAppendixId = form.querySelector("[name='project_appendix_id']");
        if (projectAppendixQuery && projectAppendixId) {
            projectAppendixQuery.setCustomValidity(
                projectAppendixQuery.value.trim() && !projectAppendixId.value
                    ? "Vui lòng chọn phụ lục thuộc công trình đã chọn trong danh sách gợi ý."
                    : ""
            );
        }
        const warehouseQuery = form.querySelector("[data-warehouse-search]");
        const warehouseId = form.querySelector("[name='warehouse_id']");
        if (form.querySelector("[data-delivery-type]")?.value === "KG" && warehouseQuery && warehouseId) {
            warehouseQuery.setCustomValidity(warehouseId.value
                ? "" : "Vui lòng chọn kho ký gửi trong danh sách gợi ý.");
        }
        products.querySelectorAll("[data-order-line]").forEach((line) => {
            const query = line.querySelector("[name='line_product_query']");
            const selected = line.querySelector("[name='line_product_id']").value;
            query.setCustomValidity(!selected
                ? "Vui lòng chọn sản phẩm trong danh sách gợi ý."
                : line.querySelector("[name='line_product_type']").value === "bar"
                    && Number(line.dataset.weight || "0") <= 0
                    ? "Chưa tính được kg từ hệ thống TMN. Vui lòng thử lại."
                    : "");
            if (!query.checkValidity()) line.classList.remove("is-collapsed");
        });
        if (!form.checkValidity()) {
            event.preventDefault();
            form.reportValidity();
        }
    });
    initializeContractSearch();
    initializeWarehouseSearch();
    products.querySelectorAll("[data-order-line]").forEach(initializeLine);
    updateTransportFields();
    updateIndexes();
}

function initializeOrderDetail(root) {
    initializeContactFormatting(root);
    const dialog = root.querySelector("[data-cancel-dialog]");
    const openButton = root.querySelector("[data-open-cancel-dialog]");
    if (!dialog || !openButton) return;

    const reason = dialog.querySelector("[data-cancel-reason]");
    const cancelForm = dialog.querySelector("[data-cancel-form]");
    const confirmButton = dialog.querySelector("[data-confirm-cancel]");
    const closeDialog = () => dialog.close();

    openButton.addEventListener("click", () => {
        dialog.showModal();
        window.setTimeout(() => reason?.focus(), 0);
    });
    dialog.querySelectorAll("[data-close-cancel-dialog]").forEach((button) => {
        button.addEventListener("click", closeDialog);
    });
    dialog.addEventListener("click", (event) => {
        if (event.target === dialog) closeDialog();
    });
    cancelForm?.addEventListener("submit", () => {
        if (!confirmButton) return;
        confirmButton.disabled = true;
        confirmButton.innerHTML = '<i class="fa fa-spinner fa-spin"></i> Đang hủy đơn...';
    });
}

function boot() {
    document.querySelectorAll("[data-iwmn-order-form]").forEach(initializeOrderForm);
    document.querySelectorAll("[data-iwmn-order-detail]").forEach(initializeOrderDetail);
}

if (document.readyState === "loading") document.addEventListener("DOMContentLoaded", boot, { once: true });
else boot();
