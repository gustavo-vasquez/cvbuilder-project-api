namespace CVBuilder.WebAPI.Helpers.Enums
{
    public class FormIds
    {
        public static string PersonalDetail => SectionIds.PersonalDetail + Suffix;
        public static string Study => SectionIds.Study + Suffix;
        public static string Certificate => SectionIds.Certificate + Suffix;
        public static string WorkExperience => SectionIds.WorkExperience + Suffix;
        public static string Language => SectionIds.Language + Suffix;
        public static string Skill => SectionIds.Skill + Suffix;
        public static string Interest => SectionIds.Interest + Suffix;
        public static string PersonalReference => SectionIds.PersonalReference + Suffix;
        public static string CustomSection => SectionIds.CustomSection + Suffix;

        private const string Suffix = "_form";
    }
}