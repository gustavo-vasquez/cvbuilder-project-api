namespace CVBuilder.Repository.DTOs
{
    public class PersonalReferenceDTO
    {
        public int PersonalReferenceId { get; set; }
        public string Company { get; set; }
        public string ContactPerson { get; set; }
        public short? AreaCode { get; set; }
        public int? Telephone { get; set; }
        public string Email { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
    }
}
