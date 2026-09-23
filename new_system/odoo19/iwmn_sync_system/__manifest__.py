{
    "name": "IWMN Master Data Synchronization",
    "summary": "Synchronize allowlisted MSSQL master data into Odoo",
    "version": "19.0.1.0.0",
    "category": "Technical",
    "license": "LGPL-3",
    "depends": ["base_setup", "iwmn_base"],
    "external_dependencies": {"python": ["requests"]},
    "data": [
        "security/ir.model.access.csv",
        "views/res_config_settings_views.xml",
        "views/iwmn_sync_system_views.xml",
    ],
    "installable": True,
    "application": True,
}
