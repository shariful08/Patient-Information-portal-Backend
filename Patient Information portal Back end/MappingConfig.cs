using AutoMapper;
using Patient_Information_portal_Back_end.Models;
using Patient_Information_portal_Back_end.Models.Dto;

namespace Patient_Information_portal_Back_end
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PatientModel, PatientDTO>().ReverseMap();
            CreateMap<PatientModel, CreatePatientDTO>().ReverseMap();
            CreateMap<PatientModel, UpdatePatientDTO>().ReverseMap();
        }
    }
}
