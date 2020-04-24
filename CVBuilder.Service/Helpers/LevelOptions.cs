using System.Collections.Generic;

namespace CVBuilder.Service.Helpers
{
    public static class LevelOptions
    {
        public const string None = "none";
        public const string Beginner = "beginner";
        public const string Intermediate = "intermediate";
        public const string Advanced = "advanced";

        public static Dictionary<string, string> LevelComboBox = new Dictionary<string, string>()
        {
            { Beginner, "Principiante" },
            { Intermediate, "Intermedio" },
            { Advanced, "Avanzado" }
        };
    }
}