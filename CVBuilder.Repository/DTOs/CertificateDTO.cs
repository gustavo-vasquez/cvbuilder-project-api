namespace CVBuilder.Repository.DTOs
{
    public class CertificateDTO
    {
        public int CertificateId { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public bool OnlineMode { get; set; }
        public bool InProgress { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int Id_Curriculum { get; set; }
    }
}
