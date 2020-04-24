namespace CVBuilder.WebAPI.Models
{
    public class SummaryBlockModel
    {
        public int SummaryId { get; set; }
        public string Title { get; set; }
        public string StateInTime { get; set; }
        public bool IsVisible { get; set; }
    }
}