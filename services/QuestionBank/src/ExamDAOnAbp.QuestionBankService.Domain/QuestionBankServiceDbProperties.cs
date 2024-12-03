namespace ExamDAOnAbp.QuestionBankService
{
    public static class QuestionBankServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = string.Empty;
        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "QuestionBankService";
    }
}
