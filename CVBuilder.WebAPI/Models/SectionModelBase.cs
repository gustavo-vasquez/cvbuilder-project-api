using CVBuilder.WebAPI.Helpers.Enums;
using CVBuilder.WebAPI.Interfaces;

namespace CVBuilder.WebAPI.Models
{
    public abstract class SectionModelBase : ISectionModel
    {
        public string FormId { get; set; }
        public FormMode FormMode { get; set; }
    }
}