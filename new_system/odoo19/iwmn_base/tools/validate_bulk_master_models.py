"""Validate generated master views with the Odoo 19 RelaxNG schemas."""

from pathlib import Path

from lxml import etree


def main() -> None:
    addon = Path(__file__).resolve().parents[1]
    odoo_rng = Path(r"D:\develop\workspace19\odoo19\odoo\addons\base\rng")
    validators = {
        view_type: etree.RelaxNG(etree.parse(str(odoo_rng / f"{view_type}_view.rng")))
        for view_type in ("list", "search")
    }
    errors = []
    checked = 0
    for xml_path in (addon / "master").glob("*.xml"):
        document = etree.parse(str(xml_path))
        for arch in document.xpath(
            '//record[@model="ir.ui.view"]/field[@name="arch"]'
        ):
            if not len(arch) or arch[0].tag not in validators:
                continue
            checked += 1
            validator = validators[arch[0].tag]
            if not validator.validate(arch[0]):
                errors.append(
                    f"{xml_path.name} ({arch[0].tag}): {validator.error_log.last_error}"
                )
    print(f"Validated {checked} list/search architectures")
    if errors:
        raise ValueError("\n".join(errors))


if __name__ == "__main__":
    main()
