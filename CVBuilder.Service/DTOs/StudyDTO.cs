namespace CVBuilder.Service.DTOs
{
    public class StudyDTO
    {
        public int StudyId { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string City { get; set; }
        public string StartMonth { get; set; }
        public int StartYear { get; set; }
        public string EndMonth { get; set; }
        public int EndYear { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
    }
}
