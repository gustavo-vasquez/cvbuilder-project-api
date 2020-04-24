using CVBuilder.WebAPI.Helpers.Enums;

namespace CVBuilder.WebAPI.Interfaces
{
    interface ISectionModel
    {
        string FormId { get; set; }
        FormMode FormMode { get; set; }
    }
}