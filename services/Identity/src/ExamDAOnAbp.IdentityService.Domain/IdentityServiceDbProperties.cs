namespace ExamDAOnAbp.IdentityService
{
    public static class IdentityServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = string.Empty;
        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "IdentityService";
    }
}
