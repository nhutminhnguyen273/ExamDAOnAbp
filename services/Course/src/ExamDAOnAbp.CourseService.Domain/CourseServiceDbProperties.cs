namespace ExamDAOnAbp.CourseService
{
    public static class CourseServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = string.Empty;
        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "CourseService";
    }
}
