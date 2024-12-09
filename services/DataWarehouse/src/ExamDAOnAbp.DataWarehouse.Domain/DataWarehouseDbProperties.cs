namespace ExamDAOnAbp.DataWarehouse
{
    public static class DataWarehouseDbProperties
    {
        public static string DbTablePrefix { get; set; } = string.Empty;
        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "DataWarehouse";
    }
}
