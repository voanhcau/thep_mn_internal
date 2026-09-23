{
    "name": "IWMN Customer Credit Dashboard",
    "summary": "Portal dashboard for customer debt and credit limits",
    "version": "19.0.1.41.0",
    "category": "Website/Portal",
    "license": "LGPL-3",
    "depends": ["iwmn_base", "portal", "website", "sale"],
    "data": [
        "security/ir.model.access.csv",
        "data/customer_order_sequence.xml",
        "data/customer_order_sync_cron.xml",
        "views/res_partner_views.xml",
        "views/res_config_settings_views.xml",
        "views/customer_order_views.xml",
        "report/customer_order_report.xml",
        "views/portal_dashboard_templates.xml",
        "views/portal_order_templates.xml",
    ],
    "assets": {
        "web.assets_frontend": [
            "iwmn_customer_dashboard/static/src/scss/customer_dashboard.scss",
            "iwmn_customer_dashboard/static/src/js/customer_order_form.js",
        ],
    },
    "installable": True,
    "application": False,
}
