using AutoMapper;
using CVBuilder.Core.DTOs;
using CVBuilder.Domain.Models;

namespace CVBuilder.Repository.Automapper
{
    public class MapperDTOProfile : Profile
    {
        public MapperDTOProfile()
        {
            CreateMap<RegisterDTO, User>(MemberList.Source);

            CreateMap<User, UserDTO>(MemberList.Destination)
                .ForMember(dest => dest.AccessDate, act => act.MapFrom(
                    (src,dest,destMember,context) =>
                        ((System.DateTime)context.Items["AccessDate"]).ToString("dddd, dd MMMM yyyy HH:mm:ss")))
                .ForMember(dest => dest.Photo, act => act.MapFrom(
                    (src,dest,destMember,context) =>
                        ByteArrayToBase64((byte[])context.Items["PhotoArray"],(string)context.Items["PhotoMimeType"])
                ));

            CreateMap<PersonalDetailDTO, PersonalDetail>()
                .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.UploadedPhoto))
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<PersonalDetail, PersonalDetailDTO>()
                .ForMember(dest => dest.Photo, act => act.MapFrom(src => ByteArrayToBase64(src.Photo, src.PhotoMimeType)));

            CreateMap<StudyDTO, Study>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Study, StudyDTO>();

            CreateMap<CertificateDTO, Certificate>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Certificate, CertificateDTO>();

            CreateMap<WorkExperienceDTO, WorkExperience>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<WorkExperience, WorkExperienceDTO>();

            CreateMap<LanguageDTO, Language>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Language, LanguageDTO>();

            CreateMap<SkillDTO, Skill>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Skill, SkillDTO>();

            CreateMap<InterestDTO, Interest>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Interest, InterestDTO>();

            CreateMap<PersonalReferenceDTO, PersonalReference>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<PersonalReference, PersonalReferenceDTO>();

            CreateMap<CustomSectionDTO, CustomSection>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<CustomSection, CustomSectionDTO>();

            CreateMap<Template, TemplateDTO>();

            CreateMap<Curriculum, SectionVisibilityDTO>();
        }

        private string ByteArrayToBase64(byte[] file, string photoMimeType)
        {
            if (file != null && file.Length > 0)
                return System.String.Concat("data:", photoMimeType, ";base64,", System.Convert.ToBase64String(file));

            return "https://www.gravatar.com/avatar/bd353396ae638ea35966c683cc56e1f6?s=48&d=identicon&r=PG";
        }
    }
}