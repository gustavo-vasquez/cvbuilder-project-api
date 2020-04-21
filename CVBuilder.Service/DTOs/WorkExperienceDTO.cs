namespace CVBuilder.Service.DTOs
{
    public class WorkExperienceDTO
    {
        public int WorkExperienceId { get; set; }
        public string Job { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string StartMonth { get; set; }
        public int StartYear { get; set; }
        public string EndMonth { get; set; }
        public int EndYear { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
    }
}
