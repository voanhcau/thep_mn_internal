namespace IntegrationHub.Application.Modules.MasterData.Sync;

public static class MasterDataEntityCatalog
{
    private static readonly HashSet<string> AllowedEntities = new(StringComparer.OrdinalIgnoreCase)
    {
        "r81bangcandoi", "r81bangcandoi_new", "r81bangcandoithep", "r81baremphoi",
        "r81dmbanve", "r81dmbarems", "r81dmbl", "r81dmbp", "r81dmbpct",
        "r81dmcanchuan", "r81dmcant", "r81dmcckqkd", "r81dmcksl", "r81dmcl",
        "r81dmcotinh", "r81dmctauto", "r81dmcumtb", "r81dmdinhmucnl",
        "r81dmdinhmucth", "r81dmdmkygui", "r81dmdt", "r81dmdt_xncn", "r81dmhd",
        "r81dmctrinh", "r81dmplctrinh",
        "r81dmjob",
        "r81dmkho", "r81dmkhoct", "r81dmkhoct_kg", "r81dmkhokg", "r81dmkm",
        "r81dmkv", "r81dmlaisuat", "r81dmloaihang", "r81dmlopdt", "r81dmlots",
        "r81dmmacthep", "r81dmmacthepct", "r81dmme", "r81dmmonan",
        "r81dmngachluong", "r81dmngayle", "r81dmnhcckqkd", "r81dmnhdt",
        "r81dmnhhd", "r81dmnhlopdt", "r81dmnhvt", "r81dmnvu", "r81dmqdcan",
        "r81dmqdct", "r81dmsize", "r81dmsohd", "r81dmstandard", "r81dmsuco",
        "r81dmthue", "r81dmtk", "r81dmtokhaihq", "r81dmtphh", "r81dmttccong",
        "r81dmvt", "r81dmvttd", "r81dmvtthtx", "r81dmvttt", "r81dmxervc",
        "r81equipment", "r81equipment_chamcong", "r81equipmentinfo",
        "r81equipmentinfoct", "r81formular_scale", "r81hschayhao", "r81laisuat",
        "r81ngaylecty", "r81ngaylecty_ct", "r81vtptchamlc", "r81vtrilddn"
    };

    public static IReadOnlyList<string> All { get; } = AllowedEntities
        .Select(entity => entity.ToLowerInvariant())
        .Order(StringComparer.Ordinal)
        .ToArray();

    public static bool Contains(string entity) => AllowedEntities.Contains(entity);
}
