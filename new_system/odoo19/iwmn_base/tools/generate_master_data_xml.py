"""Generate Odoo master-data XML files from the legacy MSSQL script."""

from __future__ import annotations

import argparse
import base64
import re
from decimal import Decimal
from pathlib import Path
from xml.sax.saxutils import escape, quoteattr


TABLES = {
    "R81BAREMPHOI": ("iwmn.r81baremphoi", "Ident00"),
    "R81DMBANVE": ("iwmn.r81dmbanve", "Ma_BanVe"),
    "R81BANGCANDOI": ("iwmn.r81bangcandoi", "Ident00"),
    "R81BANGCANDOI_NEW": ("iwmn.r81bangcandoi_new", "Ident00"),
    "R81BANGCANDOITHEP": ("iwmn.r81bangcandoithep", "Ident00"),
    "R81DMBAREMS": ("iwmn.r81dmbarems", "Ident00"),
}

INSERT_PATTERN = re.compile(
    r"^INSERT \[dbo\]\.\[(?P<table>[^]]+)\] "
    r"\((?P<columns>.+)\) VALUES \((?P<values>.+)\)$",
    re.IGNORECASE,
)
DATETIME_PATTERN = re.compile(
    r"^CAST\(N?'(?P<value>(?:''|[^'])*)'\s+AS\s+DateTime\)$",
    re.IGNORECASE,
)
STRING_PATTERN = re.compile(r"^N?'(?P<value>(?:''|[^'])*)'$", re.DOTALL)
INTEGER_FIELDS = {"nam"}


def split_sql_list(value: str) -> list[str]:
    parts: list[str] = []
    start = 0
    depth = 0
    in_string = False
    index = 0

    while index < len(value):
        character = value[index]
        if in_string:
            if character == "'":
                if index + 1 < len(value) and value[index + 1] == "'":
                    index += 1
                else:
                    in_string = False
        elif character == "'":
            in_string = True
        elif character == "(":
            depth += 1
        elif character == ")":
            depth -= 1
        elif character == "," and depth == 0:
            parts.append(value[start:index].strip())
            start = index + 1
        index += 1

    parts.append(value[start:].strip())
    return parts


def parse_sql_value(value: str) -> tuple[str | None, bool]:
    if value.upper() == "NULL":
        return None, False

    datetime_match = DATETIME_PATTERN.match(value)
    if datetime_match:
        parsed = datetime_match.group("value").replace("''", "'")
        parsed = parsed.replace("T", " ")
        return re.sub(r"\.\d+$", "", parsed), False

    string_match = STRING_PATTERN.match(value)
    if string_match:
        return string_match.group("value").replace("''", "'"), False

    if value.lower().startswith("0x"):
        return base64.b64encode(bytes.fromhex(value[2:])).decode("ascii"), True

    return value, False


def xml_id(table: str, key: str) -> str:
    safe_key = re.sub(r"[^a-zA-Z0-9_]+", "_", key).strip("_").lower()
    return f"iwmn_{table.lower()}_{safe_key}"


def normalize_field_value(field_name: str, raw_value: str) -> str | None:
    parsed_value, _is_binary = parse_sql_value(raw_value)
    if parsed_value in (None, "") or field_name not in INTEGER_FIELDS:
        return parsed_value

    decimal_value = Decimal(parsed_value)
    if decimal_value != decimal_value.to_integral_value():
        raise ValueError(f"Field {field_name} must contain an integer: {raw_value}")
    return str(int(decimal_value))


def build_xml(table: str, model: str, key_field: str, rows: list[dict[str, str]]) -> str:
    lines = [
        '<?xml version="1.0" encoding="utf-8"?>',
        "<odoo>",
        '    <data noupdate="1">',
    ]

    for row in rows:
        record_id = xml_id(table, row[key_field.lower()])
        lines.append(f'        <record id={quoteattr(record_id)} model={quoteattr(model)}>')
        for field_name, raw_value in row.items():
            parsed_value = normalize_field_value(field_name, raw_value)
            if parsed_value in (None, ""):
                lines.append(f'            <field name={quoteattr(field_name)} eval="False"/>')
            else:
                lines.append(
                    f'            <field name={quoteattr(field_name)}>'
                    f"{escape(parsed_value)}</field>"
                )
        lines.append("        </record>")

    lines.extend(["    </data>", "</odoo>", ""])
    return "\n".join(lines)


def extract_rows(sql_path: Path) -> dict[str, list[dict[str, str]]]:
    rows_by_table: dict[str, list[dict[str, str]]] = {table: [] for table in TABLES}
    sql_bytes = sql_path.read_bytes()
    encoding = "utf-16" if sql_bytes.startswith((b"\xff\xfe", b"\xfe\xff")) else "utf-8-sig"

    for line in sql_bytes.decode(encoding).splitlines():
        match = INSERT_PATTERN.match(line.strip())
        if not match or match.group("table") not in TABLES:
            continue

        columns = [column.strip().strip("[]").lower() for column in split_sql_list(match.group("columns"))]
        values = split_sql_list(match.group("values"))
        if len(columns) != len(values):
            raise ValueError(f"Column/value count mismatch: {line}")
        rows_by_table[match.group("table")].append(dict(zip(columns, values, strict=True)))

    return rows_by_table


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("sql_path", type=Path)
    parser.add_argument("output_directory", type=Path)
    args = parser.parse_args()

    rows_by_table = extract_rows(args.sql_path)
    args.output_directory.mkdir(parents=True, exist_ok=True)

    for table, (model, key_field) in TABLES.items():
        output_path = args.output_directory / f"iwmn_{table.lower()}_data.xml"
        output_path.write_text(
            build_xml(table, model, key_field, rows_by_table[table]),
            encoding="utf-8",
        )
        print(f"{table}: {len(rows_by_table[table])} records -> {output_path}")


if __name__ == "__main__":
    main()
