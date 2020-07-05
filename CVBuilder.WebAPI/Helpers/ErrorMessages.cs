namespace CVBuilder.WebAPI.Helpers
{
    internal static class ErrorMessages
    {
        public const string REQUIRED = "Campo obligatorio";
        public const string MAX_LENGTH_50 = "Máximo 50 caracteres";
        public const string MAX_LENGTH_100 = "Máximo 100 caracteres";
        public const string MAX_LENGTH_200 = "Máximo 200 caracteres";
        public const string MAX_LENGTH_300 = "Máximo 300 caracteres";
        public const string MAX_RANGE_4 = "Máximo 4 números";
        public const string MAX_RANGE_5 = "Máximo 5 números";
        public const string MAX_RANGE_10 = "Máximo 10 números";
        public const string MIN_LENGTH_6 = "Mínimo 6 caracteres";
        public const string COMPARE_PASSWORD = "Las contraseñas no coinciden";
        public const string TERMS_AND_CONDITIONS = "Debes aceptar para continuar";

        // Mensajes de las validaciones personalizadas
        public const string MONTH_PERIOD_REQUIRED = "Elija un mes";
        public const string YEAR_PERIOD_REQUIRED = "Elija un año";
        public const string START_YEAR_LESS_THAN = "El año de inicio es mayor que la finalización";
        public const string END_YEAR_GREATER_THAN = "El año de finalización es menor que el inicio";
        public const string MAX_FILE_SIZE = "El archivo es superior a 1 MB";
        public const string POSTED_FILE_EXTENSIONS = "Permitido: jpg, jpeg y png";
        public const string LEVEL_REQUIRED = "Nivel obligatorio";
    }
}