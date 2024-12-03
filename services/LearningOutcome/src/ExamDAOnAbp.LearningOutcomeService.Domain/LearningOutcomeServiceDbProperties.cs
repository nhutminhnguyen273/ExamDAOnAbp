namespace ExamDAOnAbp.LearningOutcomeService
{
    public static class LearningOutcomeServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = string.Empty;
        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "LearningOutcomeService";
    }
}
