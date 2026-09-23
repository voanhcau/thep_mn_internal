"""Generate Odoo models, views and seed XML from the legacy MSSQL script.

This script intentionally keeps the legacy column names (lower-cased) and creates
one concrete registry header per table before extending it with the actual fields.
"""

from __future__ import annotations

import base64
import re
from dataclasses import dataclass
from decimal import Decimal
from pathlib import Path
from xml.sax.saxutils import escape, quoteattr


TARGETS = [
    "R81DMBL", "R81DMBP", "R81DMBPCT", "R81DMCANCHUAN", "R81DMCANT",
    "R81DMCCKQKD", "R81DMCKSL", "R81DMCL", "R81DMCOTINH", "R81DMCTAUTO",
    "R81DMCUMTB", "R81DMDINHMUCNL", "R81DMDINHMUCTH", "R81DMDMKYGUI",
    "R81DMDT_XNCN", "R81DMJOB", "R81DMKHO", "R81DMKHOCT", "R81DMKHOCT_KG",
    "R81DMKHOKG", "R81DMKM", "R81DMKV", "R81DMLAISUAT", "R81DMLOAIHANG",
    "R81DMLOPDT", "R81DMLOTS", "R81DMMACTHEP", "R81DMMACTHEPCT", "R81DMME",
    "R81DMMONAN", "R81DMNGACHLUONG", "R81DMNGAYLE", "R81DMNHCCKQKD",
    "R81DMNHDT", "R81DMNHHD", "R81DMNHLOPDT", "R81DMNHVT", "R81DMNVU",
    "R81DMQDCAN", "R81DMQDCT", "R81DMSIZE", "R81DMSOHD", "R81DMSTANDARD",
    "R81DMSUCO", "R81DMTHUE", "R81DMTK", "R81DMTOKHAIHQ", "R81DMTPHH",
    "R81DmTTCCong", "R81DMVTTD", "R81DMVTTHTX", "R81DMVTTT", "R81DMXERVC",
    "R81Equipment", "R81EQUIPMENT_CHAMCONG", "R81EQUIPMENTINFO",
    "R81EQUIPMENTINFOCT", "R81FORMULAR_SCALE", "R81HSCHAYHAO", "R81LAISUAT",
    "R81NGAYLECTY", "R81NGAYLECTY_CT", "R81VTPTCHAMLC", "R81VTRILDDN",
]

CUSTOMER_TABLE = "R81DMDT"
PRODUCT_TABLE = "R81DMVT"
CONTRACT_TABLE = "R81DMHD"
PROJECT_TABLE = "R81DMCTRINH"
PROJECT_APPENDIX_TABLE = "R81DMPLCTRINH"

GROUPS = {
    "organization": {
        "label": "Tổ chức & nhân sự", "sequence": 10,
        "tables": {
            "R81DMBP", "R81DMBPCT", "R81DMDT_XNCN", "R81DMJOB", "R81DMLOPDT",
            "R81DMMONAN", "R81DMNGACHLUONG", "R81DMNGAYLE", "R81DMNHDT",
            "R81DMNHLOPDT", "R81DmTTCCong", "R81EQUIPMENT_CHAMCONG",
            "R81NGAYLECTY", "R81NGAYLECTY_CT", "R81VTRILDDN",
        },
    },
    "warehouse": {
        "label": "Kho & vận chuyển", "sequence": 20,
        "tables": {
            "R81DMKHO", "R81DMKHOCT", "R81DMKHOCT_KG", "R81DMKHOKG",
            "R81DMDMKYGUI", "R81DMCTAUTO", "R81DMTOKHAIHQ", "R81DMXERVC",
        },
    },
    "materials": {
        "label": "Vật tư & sản phẩm", "sequence": 30,
        "tables": {
            "R81DMLOAIHANG", "R81DMLOTS", "R81DMNHVT", "R81DMSIZE", "R81DMVTTD",
            "R81DMVTTHTX", "R81DMVTTT", "R81VTPTCHAMLC", "R81DMBAREMS",
            "R81DMVT",
        },
    },
    "quality": {
        "label": "Chất lượng & tiêu chuẩn", "sequence": 40,
        "tables": {
            "R81DMCL", "R81DMCOTINH", "R81DMMACTHEP", "R81DMMACTHEPCT",
            "R81DMSTANDARD", "R81DMTPHH",
        },
    },
    "equipment": {
        "label": "Thiết bị & cân", "sequence": 50,
        "tables": {
            "R81DMCANT", "R81DMCUMTB", "R81Equipment", "R81EQUIPMENTINFO",
            "R81EQUIPMENTINFOCT", "R81FORMULAR_SCALE",
        },
    },
    "finance": {
        "label": "Tài chính & kế toán", "sequence": 60,
        "tables": {
            "R81DMBL", "R81DMCKSL", "R81DMKM", "R81DMKV", "R81DMLAISUAT",
            "R81DMNHHD", "R81DMNVU", "R81DMQDCT", "R81DMSOHD", "R81DMTHUE",
            "R81DMTK", "R81LAISUAT", "R81DMHD", "R81DMCTRINH",
            "R81DMPLCTRINH",
        },
    },
    "production": {
        "label": "Sản xuất & định mức", "sequence": 70,
        "tables": {
            "R81DMCANCHUAN", "R81DMDINHMUCNL", "R81DMDINHMUCTH", "R81DMME",
            "R81DMQDCAN", "R81HSCHAYHAO", "R81BAREMPHOI", "R81DMBANVE",
            "R81BANGCANDOI", "R81BANGCANDOI_NEW", "R81BANGCANDOITHEP",
        },
    },
    "business": {
        "label": "Kết quả kinh doanh", "sequence": 80,
        "tables": {"R81DMCCKQKD", "R81DMNHCCKQKD"},
    },
    "operations": {
        "label": "Vận hành chung", "sequence": 90,
        "tables": {"R81DMSUCO"},
    },
}

ALL_EXISTING = [
    "R81BAREMPHOI", "R81DMBANVE", "R81BANGCANDOI", "R81BANGCANDOI_NEW",
    "R81BANGCANDOITHEP", "R81DMBAREMS",
]

CREATE_RE = re.compile(
    r"CREATE TABLE \[dbo\]\.\[(?P<table>[^]]+)\]\((?P<body>.*?)\n\) ON \[PRIMARY\]",
    re.IGNORECASE | re.DOTALL,
)
COL_RE = re.compile(
    r"^\s*\[(?P<name>[^]]+)\]\s+\[(?P<type>[^]]+)\]"
    r"(?P<args>\([^\r\n]*?\))?(?:\s+IDENTITY\([^)]*\))?\s+"
    r"(?P<nullable>NOT NULL|NULL),?\s*$",
    re.IGNORECASE,
)
INSERT_RE = re.compile(
    r"^INSERT \[dbo\]\.\[(?P<table>[^]]+)\] \((?P<columns>.+)\) VALUES \((?P<values>.+)\)$",
    re.IGNORECASE | re.DOTALL,
)
CAST_RE = re.compile(
    r"^CAST\(N?'(?P<value>(?:''|[^'])*)'\s+AS\s+"
    r"(?P<type>[a-zA-Z0-9_]+(?:\s*\([^)]*\))?)\)$",
    re.IGNORECASE,
)
NUMERIC_CAST_RE = re.compile(
    r"^CAST\((?P<value>[-+0-9.eE]+)\s+AS\s+"
    r"(?P<type>[a-zA-Z0-9_]+(?:\s*\([^)]*\))?)\)$",
    re.IGNORECASE,
)
STRING_RE = re.compile(r"^N?'(?P<value>(?:''|[^'])*)'$", re.DOTALL)


@dataclass(frozen=True)
class Column:
    source_name: str
    sql_type: str
    args: str
    nullable: bool

    @property
    def name(self) -> str:
        return self.source_name.lower()


def split_sql_list(value: str) -> list[str]:
    parts, start, depth, in_string, index = [], 0, 0, False, 0
    while index < len(value):
        char = value[index]
        if in_string:
            if char == "'":
                if index + 1 < len(value) and value[index + 1] == "'":
                    index += 1
                else:
                    in_string = False
        elif char == "'":
            in_string = True
        elif char == "(":
            depth += 1
        elif char == ")":
            depth -= 1
        elif char == "," and depth == 0:
            parts.append(value[start:index].strip())
            start = index + 1
        index += 1
    parts.append(value[start:].strip())
    return parts


def parse_value(raw: str) -> tuple[str | None, bool]:
    if raw.upper() == "NULL":
        return None, False
    numeric_cast = NUMERIC_CAST_RE.match(raw)
    if numeric_cast:
        return numeric_cast.group("value"), False
    cast = CAST_RE.match(raw)
    if cast:
        value = cast.group("value").replace("''", "'").replace("T", " ")
        if "time" not in cast.group("type").lower() or "datetime" in cast.group("type").lower():
            value = re.sub(r"\.\d+$", "", value)
        return value, False
    string = STRING_RE.match(raw)
    if string:
        return string.group("value").replace("''", "'"), False
    if raw.lower().startswith("0x"):
        return base64.b64encode(bytes.fromhex(raw[2:])).decode("ascii"), True
    return raw, False


def read_sql(path: Path) -> str:
    payload = path.read_bytes()
    encoding = "utf-16" if payload.startswith((b"\xff\xfe", b"\xfe\xff")) else "utf-8-sig"
    return payload.decode(encoding)


def parse_schemas(sql: str) -> dict[str, list[Column]]:
    schemas = {}
    for match in CREATE_RE.finditer(sql):
        columns = []
        for line in match.group("body").splitlines():
            col = COL_RE.match(line)
            if col:
                columns.append(Column(
                    col.group("name"), col.group("type").lower(), col.group("args") or "",
                    col.group("nullable").upper() == "NULL",
                ))
        schemas[match.group("table").lower()] = columns
    return schemas


def parse_rows(sql: str, wanted: set[str]) -> dict[str, list[dict[str, str]]]:
    rows = {name.lower(): [] for name in wanted}
    statement = ""
    in_string = False
    depth = 0
    statements = []
    for line in sql.splitlines():
        if not statement:
            if not line.startswith("INSERT [dbo].["):
                continue
            statement = line.strip()
        else:
            statement += "\n" + line

        index = 0
        while index < len(line):
            char = line[index]
            if in_string:
                if char == "'":
                    if index + 1 < len(line) and line[index + 1] == "'":
                        index += 1
                    else:
                        in_string = False
            elif char == "'":
                in_string = True
            elif char == "(":
                depth += 1
            elif char == ")":
                depth -= 1
            index += 1

        if not in_string and depth == 0:
            statements.append(statement)
            statement = ""

    if statement:
        raise ValueError("Unterminated INSERT statement at end of SQL script")

    for statement in statements:
        match = INSERT_RE.match(statement.strip())
        if not match or match.group("table").lower() not in rows:
            continue
        columns = [part.strip().strip("[]").lower() for part in split_sql_list(match.group("columns"))]
        values = split_sql_list(match.group("values"))
        if len(columns) != len(values):
            raise ValueError(f"Column/value count mismatch for {match.group('table')}: {statement[:200]}")
        rows[match.group("table").lower()].append(dict(zip(columns, values, strict=True)))
    return rows


def group_for(table: str) -> str:
    matches = [key for key, config in GROUPS.items() if table in config["tables"]]
    if len(matches) != 1:
        raise ValueError(f"{table} must belong to exactly one functional group: {matches}")
    return matches[0]


def model_field(column: Column, required: bool) -> list[str]:
    sql_type, args = column.sql_type, column.args
    options = [f'string="{column.source_name}"']
    if required:
        options.append("required=True")
    if column.name == "ident00" or column.name.startswith("ma_") or column.name in {"tk", "grade_id", "standard_id"}:
        options.append("index=True")
    if column.name == "ident00":
        options.extend(["copy=False", f'help="ID của bản ghi trong MSSQL ({column.source_name})."'])

    if column.name == "barweight_bk":
        field_type = "Char"
        options.append("size=50")
    elif sql_type in {"varchar", "nvarchar", "char", "nchar"}:
        size_match = re.search(r"\((\d+)\)", args)
        if size_match:
            options.append(f"size={size_match.group(1)}")
        field_type = "Char"
    elif sql_type in {"text", "ntext", "xml"}:
        field_type = "Text"
    elif sql_type in {"int", "smallint", "tinyint", "bigint"} or column.name == "nam":
        field_type = "Integer"
    elif sql_type in {"money", "smallmoney"}:
        field_type = "Float"
        options.append("digits=(19, 4)")
    elif sql_type in {"decimal", "numeric"}:
        field_type = "Float"
        digits = re.search(r"\((\d+)\s*,\s*(\d+)\)", args)
        if digits:
            options.append(f"digits=({digits.group(1)}, {digits.group(2)})")
    elif sql_type in {"float", "real"}:
        field_type = "Float"
    elif sql_type == "bit":
        field_type = "Boolean"
    elif sql_type == "date":
        field_type = "Date"
    elif sql_type in {"datetime", "datetime2", "smalldatetime"}:
        field_type = "Datetime"
    elif sql_type == "time":
        field_type = "Char"
        options.append("size=16")
    elif sql_type in {"binary", "varbinary", "image", "timestamp", "rowversion"}:
        field_type = "Binary"
    elif sql_type == "uniqueidentifier":
        field_type = "Char"
        options.append("size=36")
    else:
        raise ValueError(f"Unsupported MSSQL type {sql_type} on {column.source_name}")

    lines = [f"    {column.name} = fields.{field_type}("]
    lines.extend(f"        {option}," for option in options)
    lines.append("    )")
    return lines


def choose_rec_name(columns: list[Column]) -> str:
    names = [col.name for col in columns]
    for prefix in ("ten_", "description", "grade_name", "standard_name", "lot_name", "so_", "ma_"):
        for name in names:
            if name == prefix or name.startswith(prefix):
                return name
    return "ident00" if "ident00" in names else names[0]


def field_is_required(column: Column, rows: list[dict[str, str]]) -> bool:
    if column.nullable or column.name in {"ident00", "create_log", "lastmodify_log"}:
        return False
    for row in rows:
        if column.name not in row:
            return False
        value, _ = parse_value(row[column.name])
        if value in (None, ""):
            return False
    return True


def render_model(table: str, columns: list[Column], rows: list[dict[str, str]]) -> str:
    stem = table.lower()
    rec_name = choose_rec_name(columns)
    lines = [
        "from odoo import fields, models", "", "", f"class iwmn_{stem}(models.Model):",
        f'    _inherit = "iwmn.{stem}"', f'    _rec_name = "{rec_name}"',
        f'    _order = "{rec_name}, id"', "",
    ]
    for column in columns:
        required = field_is_required(column, rows)
        if table == PROJECT_TABLE and column.name in {"ma_kv", "ma_ctrinh_parent"}:
            required = False
        lines.extend(model_field(column, required))
        lines.append("")
    return "\n".join(lines)


def display_name(table: str, columns: list[Column]) -> str:
    if table == CUSTOMER_TABLE:
        return "Khách hàng"
    if table == PRODUCT_TABLE:
        return "Sản phẩm"
    if table == CONTRACT_TABLE:
        return "Hợp đồng"
    if table == PROJECT_TABLE:
        return "Công trình"
    if table == PROJECT_APPENDIX_TABLE:
        return "Phụ lục công trình"
    rec_name = choose_rec_name(columns)
    rec_column = next(col for col in columns if col.name == rec_name)
    return f"{table} - {rec_column.source_name}"


def render_view(table: str, columns: list[Column], sequence: int) -> str:
    stem, model = table.lower(), f"iwmn.{table.lower()}"
    title = display_name(table, columns)
    names = [column.name for column in columns]
    list_names = names[:8]
    search_names = []
    for name in [choose_rec_name(columns), *names]:
        if name not in search_names and len(search_names) < 4:
            search_names.append(name)
    def field_tag(name: str, indent: str) -> str:
        option = " options=\"{'enable_formatting': false}\"" if name == "nam" else ""
        return f'{indent}<field name="{name}"{option}/>'

    lines = [
        '<?xml version="1.0" encoding="utf-8"?>', "<odoo>",
        f'    <record id="view_iwmn_{stem}_list" model="ir.ui.view">',
        f'        <field name="name">{model}.list</field>',
        f'        <field name="model">{model}</field>', '        <field name="arch" type="xml">',
        f'            <list string="{escape(title)}">',
    ]
    lines.extend(field_tag(name, "                ") for name in list_names)
    menu_parent = (
        "menu_iwmn_base_root"
        if table == CUSTOMER_TABLE
        else f"menu_iwmn_master_{group_for(table)}"
    )
    lines.extend([
        "            </list>", "        </field>", "    </record>", "",
        f'    <record id="view_iwmn_{stem}_form" model="ir.ui.view">',
        f'        <field name="name">{model}.form</field>', f'        <field name="model">{model}</field>',
        '        <field name="arch" type="xml">', f'            <form string="{escape(title)}">',
        "                <sheet>", "                    <group>",
    ])
    midpoint = (len(names) + 1) // 2
    for chunk in (names[:midpoint], names[midpoint:]):
        lines.append("                        <group>")
        lines.extend(field_tag(name, "                            ") for name in chunk)
        lines.append("                        </group>")
    lines.extend([
        "                    </group>", "                </sheet>", "            </form>",
        "        </field>", "    </record>", "",
        f'    <record id="view_iwmn_{stem}_search" model="ir.ui.view">',
        f'        <field name="name">{model}.search</field>', f'        <field name="model">{model}</field>',
        '        <field name="arch" type="xml">', "            <search>",
    ])
    lines.extend(field_tag(name, "                ") for name in search_names)
    lines.extend([
        "            </search>", "        </field>", "    </record>", "",
        f'    <record id="action_iwmn_{stem}" model="ir.actions.act_window">',
        f'        <field name="name">{escape(title)}</field>', f'        <field name="res_model">{model}</field>',
        '        <field name="view_mode">list,form</field>',
        f'        <field name="search_view_id" ref="view_iwmn_{stem}_search"/>', "    </record>", "",
        f'    <menuitem id="menu_iwmn_{stem}" name="{escape(title)}"',
        f'              parent="{menu_parent}"',
        f'              action="action_iwmn_{stem}" sequence="{sequence}"/>', "</odoo>", "",
    ])
    return "\n".join(lines)


def normalize_data_value(column: Column, raw: str) -> tuple[str | None, bool]:
    value, is_binary = parse_value(raw)
    if value in (None, ""):
        return value, is_binary
    if column.name == "nam" or column.sql_type in {"int", "smallint", "tinyint", "bigint"}:
        number = Decimal(value)
        if number != number.to_integral_value():
            raise ValueError(f"{column.source_name} must be an integer: {raw}")
        return str(int(number)), is_binary
    return value, is_binary


def safe_xml_id(table: str, key: str, occurrence: int) -> str:
    value = re.sub(r"[^a-zA-Z0-9_]+", "_", key).strip("_").lower() or "empty"
    suffix = f"_{occurrence}" if occurrence > 1 else ""
    return f"iwmn_{table.lower()}_{value}{suffix}"


def render_data(table: str, columns: list[Column], rows: list[dict[str, str]]) -> str:
    key = "ident00" if any(col.name == "ident00" for col in columns) else columns[0].name
    by_name = {column.name: column for column in columns}
    used_ids: set[str] = set()
    lines = ['<?xml version="1.0" encoding="utf-8"?>', "<odoo>", '    <data noupdate="1">']
    for row_number, row in enumerate(rows, 1):
        key_value, _ = normalize_data_value(by_name[key], row.get(key, str(row_number)))
        stable_key = key_value or str(row_number)
        base_id = safe_xml_id(table, stable_key, 1)
        record_id = base_id
        occurrence = 2
        while record_id in used_ids:
            record_id = f"{base_id}_{occurrence}"
            occurrence += 1
        used_ids.add(record_id)
        lines.append(f'        <record id={quoteattr(record_id)} model="iwmn.{table.lower()}">')
        for field_name, raw in row.items():
            column = by_name[field_name]
            value, _ = normalize_data_value(column, raw)
            if value in (None, ""):
                lines.append(f'            <field name="{field_name}" eval="False"/>')
            elif column.sql_type == "bit":
                boolean = value not in {"0", "False", "false"}
                lines.append(f'            <field name="{field_name}" eval="{boolean}"/>')
            else:
                lines.append(f'            <field name="{field_name}">{escape(value)}</field>')
        lines.append("        </record>")
    lines.extend(["    </data>", "</odoo>", ""])
    return "\n".join(lines)


def render_menus() -> str:
    lines = [
        '<?xml version="1.0" encoding="utf-8"?>', "<odoo>",
        '    <menuitem id="menu_iwmn_base_root" name="IWMN" sequence="90"/>',
        '    <menuitem id="menu_iwmn_master_data" name="Danh mục" parent="menu_iwmn_base_root" sequence="10"/>',
    ]
    for key, config in GROUPS.items():
        lines.append(
            f'    <menuitem id="menu_iwmn_master_{key}" name="{escape(config["label"])}" '
            f'parent="menu_iwmn_master_data" sequence="{config["sequence"]}"/>'
        )
    lines.extend(["</odoo>", ""])
    return "\n".join(lines)


def render_header(tables: list[str]) -> str:
    lines = ["from odoo import models", ""]
    for table in tables:
        stem = table.lower()
        lines.extend([
            "", f"class iwmn_{stem}(models.Model):", f'    _name = "iwmn.{stem}"',
        ])
    lines.append("")
    return "\n".join(lines)


def render_master_init(tables: list[str]) -> str:
    return "\n".join(f"from . import iwmn_{table.lower()}" for table in tables) + "\n"


def render_access(tables: list[str]) -> str:
    lines = ["id,name,model_id:id,group_id:id,perm_read,perm_write,perm_create,perm_unlink"]
    for table in tables:
        stem = table.lower()
        lines.append(
            f"access_iwmn_{stem}_user,iwmn.{stem} user,model_iwmn_{stem},base.group_user,1,1,1,1"
        )
    return "\n".join(lines) + "\n"


def render_manifest(tables: list[str]) -> str:
    data_files = ["security/ir.model.access.csv", "master/iwmn_master_menus.xml"]
    data_files.extend(f"master/iwmn_{table.lower()}_data.xml" for table in tables)
    data_files.extend(f"master/iwmn_{table.lower()}.xml" for table in tables)
    lines = [
        "{", '    "name": "IWMN Base",',
        '    "summary": "Base objects and master data migrated from the legacy MSSQL ERP",',
        '    "version": "19.0.1.0.0",', '    "category": "Technical",',
        '    "license": "LGPL-3",', '    "depends": ["base"],', '    "data": [',
    ]
    lines.extend(f'        "{file_name}",' for file_name in data_files)
    lines.extend(['    ],', '    "installable": True,', '    "application": False,', "}", ""])
    return "\n".join(lines)


def regroup_existing_views(master: Path) -> None:
    root_menu = re.compile(
        r'\n\s*<menuitem id="menu_iwmn_base_root".*?'
        r'<menuitem\s+id="menu_iwmn_master_data".*?/>',
        re.DOTALL,
    )
    for table in ALL_EXISTING:
        path = master / f"iwmn_{table.lower()}.xml"
        content = path.read_text(encoding="utf-8")
        content = root_menu.sub("", content)
        content = content.replace(
            'parent="menu_iwmn_master_data"',
            f'parent="menu_iwmn_master_{group_for(table)}"',
        )
        path.write_text(content, encoding="utf-8")


def main() -> None:
    addon = Path(__file__).resolve().parents[1]
    repository = addon.parents[2]
    sql_path = repository / "old_system" / "database" / "script_master_data.sql"
    sql = read_sql(sql_path)
    schemas = parse_schemas(sql)
    wanted = set(TARGETS)
    rows = parse_rows(sql, wanted)

    customer_sql_path = repository / "old_system" / "database" / "r18dmdt_script.sql"
    customer_sql = read_sql(customer_sql_path)
    customer_schemas = parse_schemas(customer_sql)
    customer_rows = parse_rows(customer_sql, {CUSTOMER_TABLE})[CUSTOMER_TABLE.lower()]
    customer_rows = [
        row
        for row in customer_rows
        if (parse_value(row.get("tk_cn", ""))[0] or "").startswith("131")
    ]

    product_sql_path = repository / "old_system" / "database" / "dm_thep_sctrut_script.sql"
    product_sql = read_sql(product_sql_path)
    product_schemas = parse_schemas(product_sql)
    product_rows = parse_rows(product_sql, {PRODUCT_TABLE})[PRODUCT_TABLE.lower()]

    contract_sql_path = repository / "old_system" / "database" / "R81DMHD_script_struct.sql"
    contract_sql = read_sql(contract_sql_path)
    contract_schemas = parse_schemas(contract_sql)
    contract_rows = parse_rows(contract_sql, {CONTRACT_TABLE})[CONTRACT_TABLE.lower()]

    project_sql_path = (
        repository / "old_system" / "database" / "R81DMCTRINH_script_struct.sql"
    )
    project_sql = read_sql(project_sql_path)
    project_schemas = parse_schemas(project_sql)
    project_rows = parse_rows(project_sql, {PROJECT_TABLE})[PROJECT_TABLE.lower()]

    project_appendix_sql_path = (
        repository / "old_system" / "database" / "R81DMPLCTRINH_script_struct.sql"
    )
    project_appendix_sql = read_sql(project_appendix_sql_path)
    project_appendix_schemas = parse_schemas(project_appendix_sql)
    project_appendix_rows = parse_rows(
        project_appendix_sql, {PROJECT_APPENDIX_TABLE}
    )[PROJECT_APPENDIX_TABLE.lower()]

    missing = [table for table in TARGETS if table.lower() not in schemas]
    if missing:
        raise ValueError(f"Missing schemas: {missing}")
    assigned = set().union(*(config["tables"] for config in GROUPS.values()))
    expected = set(
        TARGETS
        + ALL_EXISTING
        + [PRODUCT_TABLE, CONTRACT_TABLE, PROJECT_TABLE, PROJECT_APPENDIX_TABLE]
    )
    if assigned != expected:
        raise ValueError(f"Invalid group mapping; missing={expected-assigned}, extra={assigned-expected}")

    master = addon / "master"
    for table in TARGETS:
        columns = schemas[table.lower()]
        table_rows = rows[table.lower()]
        stem = table.lower()
        (master / f"iwmn_{stem}.py").write_text(render_model(table, columns, table_rows), encoding="utf-8")
        (master / f"iwmn_{stem}.xml").write_text(render_view(table, columns, TARGETS.index(table) + 10), encoding="utf-8")
        (master / f"iwmn_{stem}_data.xml").write_text(render_data(table, columns, table_rows), encoding="utf-8")
        print(f"{table}: {len(columns)} fields, {len(table_rows)} records, group={group_for(table)}")

    customer_columns = customer_schemas[CUSTOMER_TABLE.lower()]
    customer_stem = CUSTOMER_TABLE.lower()
    (master / f"iwmn_{customer_stem}.py").write_text(
        render_model(CUSTOMER_TABLE, customer_columns, customer_rows), encoding="utf-8"
    )
    (master / f"iwmn_{customer_stem}.xml").write_text(
        render_view(CUSTOMER_TABLE, customer_columns, 15), encoding="utf-8"
    )
    (master / f"iwmn_{customer_stem}_data.xml").write_text(
        render_data(CUSTOMER_TABLE, customer_columns, customer_rows), encoding="utf-8"
    )
    print(
        f"{CUSTOMER_TABLE}: {len(customer_columns)} fields, "
        f"{len(customer_rows)} records, menu=customer"
    )

    product_columns = product_schemas[PRODUCT_TABLE.lower()]
    product_stem = PRODUCT_TABLE.lower()
    (master / f"iwmn_{product_stem}.py").write_text(
        render_model(PRODUCT_TABLE, product_columns, product_rows), encoding="utf-8"
    )
    (master / f"iwmn_{product_stem}.xml").write_text(
        render_view(PRODUCT_TABLE, product_columns, 75), encoding="utf-8"
    )
    (master / f"iwmn_{product_stem}_data.xml").write_text(
        render_data(PRODUCT_TABLE, product_columns, product_rows), encoding="utf-8"
    )
    print(
        f"{PRODUCT_TABLE}: {len(product_columns)} fields, "
        f"{len(product_rows)} records, group={group_for(PRODUCT_TABLE)}"
    )

    contract_columns = contract_schemas[CONTRACT_TABLE.lower()]
    contract_stem = CONTRACT_TABLE.lower()
    (master / f"iwmn_{contract_stem}.py").write_text(
        render_model(CONTRACT_TABLE, contract_columns, contract_rows), encoding="utf-8"
    )
    (master / f"iwmn_{contract_stem}.xml").write_text(
        render_view(CONTRACT_TABLE, contract_columns, 25), encoding="utf-8"
    )
    (master / f"iwmn_{contract_stem}_data.xml").write_text(
        render_data(CONTRACT_TABLE, contract_columns, contract_rows), encoding="utf-8"
    )
    print(
        f"{CONTRACT_TABLE}: {len(contract_columns)} fields, "
        f"{len(contract_rows)} records, group={group_for(CONTRACT_TABLE)}"
    )

    project_columns = project_schemas[PROJECT_TABLE.lower()]
    project_stem = PROJECT_TABLE.lower()
    (master / f"iwmn_{project_stem}.py").write_text(
        render_model(PROJECT_TABLE, project_columns, project_rows), encoding="utf-8"
    )
    (master / f"iwmn_{project_stem}.xml").write_text(
        render_view(PROJECT_TABLE, project_columns, 26), encoding="utf-8"
    )
    (master / f"iwmn_{project_stem}_data.xml").write_text(
        render_data(PROJECT_TABLE, project_columns, project_rows), encoding="utf-8"
    )
    print(
        f"{PROJECT_TABLE}: {len(project_columns)} fields, "
        f"{len(project_rows)} records, group={group_for(PROJECT_TABLE)}"
    )

    project_appendix_columns = project_appendix_schemas[PROJECT_APPENDIX_TABLE.lower()]
    project_appendix_stem = PROJECT_APPENDIX_TABLE.lower()
    (master / f"iwmn_{project_appendix_stem}.py").write_text(
        render_model(
            PROJECT_APPENDIX_TABLE,
            project_appendix_columns,
            project_appendix_rows,
        ),
        encoding="utf-8",
    )
    (master / f"iwmn_{project_appendix_stem}.xml").write_text(
        render_view(PROJECT_APPENDIX_TABLE, project_appendix_columns, 27),
        encoding="utf-8",
    )
    (master / f"iwmn_{project_appendix_stem}_data.xml").write_text(
        render_data(
            PROJECT_APPENDIX_TABLE,
            project_appendix_columns,
            project_appendix_rows,
        ),
        encoding="utf-8",
    )
    print(
        f"{PROJECT_APPENDIX_TABLE}: {len(project_appendix_columns)} fields, "
        f"{len(project_appendix_rows)} records, "
        f"group={group_for(PROJECT_APPENDIX_TABLE)}"
    )

    (master / "iwmn_master_menus.xml").write_text(render_menus(), encoding="utf-8")
    all_tables = ALL_EXISTING + TARGETS + [
        CUSTOMER_TABLE,
        PRODUCT_TABLE,
        CONTRACT_TABLE,
        PROJECT_TABLE,
        PROJECT_APPENDIX_TABLE,
    ]
    (addon / "object_header" / "iwmn_master_header.py").write_text(
        render_header(all_tables), encoding="utf-8"
    )
    (master / "__init__.py").write_text(render_master_init(all_tables), encoding="utf-8")
    (addon / "security" / "ir.model.access.csv").write_text(
        render_access(all_tables), encoding="utf-8"
    )
    (addon / "__manifest__.py").write_text(render_manifest(all_tables), encoding="utf-8")
    regroup_existing_views(master)


if __name__ == "__main__":
    main()
