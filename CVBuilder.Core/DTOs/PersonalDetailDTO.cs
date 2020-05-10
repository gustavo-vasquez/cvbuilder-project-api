namespace CVBuilder.Core.DTOs
{
    public class PersonalDetailDTO
    {
        public int PersonalDetailId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public byte[] UploadedPhoto { get; set; }
        public string Photo { get; set; }
        public string MimeType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }
        public short? AreaCodeLP { get; set; }
        public int? LinePhone { get; set; }
        public short? AreaCodeMP { get; set; }
        public int? MobilePhone { get; set; }
        public string Summary { get; set; }
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }
        public string WebPageUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public int Id_Curriculum { get; set; }
    }
}
