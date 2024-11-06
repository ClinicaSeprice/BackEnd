using AutoMapper;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Models; 

namespace ClinicaSepriceAPI.Profiles
{
    public class AutoMapperProfileService: Profile
    {
        public AutoMapperProfileService()
        {

            CreateMap<Persona, PacienteDTO>().ForMember(
                dto => dto.Nombre, 
                opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido}"));


            CreateMap<ObraSocial, ObraSocialDTO>();
            CreateMap<ObraSocialDTO, ObraSocial>();

                
        }

     
    }
}
