{
    "name": "IWMN API Gateway",
    "summary": "Execute authenticated Odoo ORM calls as the originating user",
    "version": "19.0.1.0.0",
    "category": "Technical",
    "license": "LGPL-3",
    "depends": ["base"],
    "data": [
        "security/iwmn_api_gateway_security.xml",
    ],
    "installable": True,
    "application": False,
}
