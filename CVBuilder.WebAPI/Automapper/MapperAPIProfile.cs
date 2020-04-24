using System.IO;
using AutoMapper;
using CVBuilder.Repository.DTOs;
using CVBuilder.Service.Helpers;
using CVBuilder.WebAPI.Helpers.Enums;
using CVBuilder.WebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace CVBuilder.WebAPI.Automapper
{
    public class MapperAPIProfile : Profile
    {
        public MapperAPIProfile()
        {
            CreateMap<PersonalDetailModel, PersonalDetailDTO>()
                .ForMember(dest => dest.UploadedPhoto, act => act.MapFrom(src => PostedFileToByteArray(src.UploadedPhoto)))
                .ForMember(dest => dest.MimeType, act => act.MapFrom(src => src.UploadedPhoto != null ? src.UploadedPhoto.ContentType : null))
                .ForMember(dest => dest.Photo, act => act.Ignore());

            CreateMap<PersonalDetailDTO, PersonalDetailModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<StudyModel, StudyDTO>()
                .ForMember(dest => dest.StartYear, act => act.MapFrom(src => src.StartMonth == MonthOptions.NotShow ? 0 : src.StartYear))
                .ForMember(dest => dest.EndYear, act => act.MapFrom(src => src.EndMonth == MonthOptions.NotShow || src.EndMonth == MonthOptions.Present ? 0 : src.EndYear));

            CreateMap<StudyDTO, StudyModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<CertificateModel, CertificateDTO>();

            CreateMap<CertificateDTO, CertificateModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<WorkExperienceModel, WorkExperienceDTO>()
                .ForMember(dest => dest.StartYear, act => act.MapFrom(src => src.StartMonth == MonthOptions.NotShow ? 0 : src.StartYear))
                .ForMember(dest => dest.EndYear, act => act.MapFrom(src => src.EndMonth == MonthOptions.NotShow || src.EndMonth == MonthOptions.Present ? 0 : src.EndYear));

            CreateMap<WorkExperienceDTO, WorkExperienceModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<LanguageModel, LanguageDTO>();

            CreateMap<LanguageDTO, LanguageModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<SkillModel, SkillDTO>();

            CreateMap<SkillDTO, SkillModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<InterestModel, InterestDTO>();

            CreateMap<InterestDTO, InterestModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<PersonalReferenceModel, PersonalReferenceDTO>();

            CreateMap<PersonalReferenceDTO, PersonalReferenceModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<CustomSectionModel, CustomSectionDTO>();

            CreateMap<CustomSectionDTO, CustomSectionModel>()
                .ForMember(dest => dest.FormMode, act => act.MapFrom(src => FormMode.EDIT));

            CreateMap<SummaryBlockDTO, SummaryBlockModel>();

            CreateMap<TemplateDTO, FinishedModel>();

            CreateMap<PersonalDetailDTO, PersonalDetailsDisplay>()
                .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.Photo ?? GlobalVariables.DEFAULT_AVATAR_PATH))
                .ForMember(dest => dest.LinePhone, act => act.MapFrom(src => src.LinePhone != null && src.AreaCodeLP != null ? "(+" + src.AreaCodeLP + ") " + src.LinePhone : null))
                .ForMember(dest => dest.MobilePhone, act => act.MapFrom(src => src.MobilePhone != null && src.AreaCodeMP != null ? "(+" + src.AreaCodeMP + ") " + src.MobilePhone : null))
                .ForMember(dest => dest.Location, act => act.MapFrom(src => GenerateLocation(src.Address, src.City, src.Country, src.PostalCode)));

            CreateMap<StudyDTO, StudiesDisplay>()
                .ForMember(dest => dest.StateInTime, act => act.MapFrom(src => GenerateTimePeriodCV(src.StartMonth, src.StartYear, src.EndMonth, src.EndYear)));

            CreateMap<WorkExperienceDTO, WorkExperiencesDisplay>()
                .ForMember(dest => dest.StateInTime, act => act.MapFrom(src => GenerateTimePeriodCV(src.StartMonth, src.StartYear, src.EndMonth, src.EndYear)));

            CreateMap<CertificateDTO, CertificatesDisplay>();

            CreateMap<LanguageDTO, LanguagesDisplay>();

            CreateMap<SkillDTO, SkillsDisplay>();

            CreateMap<InterestDTO, InterestsDisplay>();

            CreateMap<PersonalReferenceDTO, PersonalReferencesDisplay>()
                .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.Telephone != null && src.AreaCode != null ? "(+" + src.AreaCode + ") " + src.Telephone : null));

            CreateMap<CustomSectionDTO, CustomSectionsDisplay>();

            CreateMap<FinishedDTO, FinishedModel>();

            CreateMap<SectionVisibilityDTO, SectionVisibilityModel>();
        }

        private byte[] PostedFileToByteArray(IFormFile file)
        {
            if(file != null && file.Length > 0)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                return ms.ToArray();
            }

            return null;
        }

        private string GenerateLocation(string address, string city, string country, int? postalCode)
        {
            string location = string.Empty;

            if (address != null)
            {
                location = address;

                if (postalCode != null)
                    location += " (" + postalCode + ")";

                location += ", ";
            }   

            if (city != null)
                location += city;

            if (country != null)
                location += ", " + country;

            

            if (location == string.Empty)
                return null;
            else
                return location;
        }

        public string GenerateTimePeriodCV(string startMonth, int? startYear, string endMonth, int? endYear)
        {
            string timePeriod = GlobalVariables.GenerateStateInTimeFormat(startMonth, startYear, endMonth, endYear);

            return timePeriod.Substring(1, timePeriod.Length - 2);
        }
    }
}