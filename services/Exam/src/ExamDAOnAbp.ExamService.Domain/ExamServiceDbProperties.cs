namespace ExamDAOnAbp.ExamService
{
    public static class ExamServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = string.Empty;
        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "ExamService";
    }
}
