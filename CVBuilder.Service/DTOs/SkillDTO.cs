namespace CVBuilder.Service.DTOs
{
    public class SkillDTO
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
    }
}
