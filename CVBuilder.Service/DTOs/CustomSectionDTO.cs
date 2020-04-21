namespace CVBuilder.Service.DTOs
{
    public class CustomSectionDTO
    {
        public int CustomSectionId { get; set; }
        public string SectionName { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
    }
}
