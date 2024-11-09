using AutoMapper;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Models; 

namespace ClinicaSepriceAPI.Profiles
{
    public class AutoMapperProfileService: Profile
    {
        public AutoMapperProfileService()
        {
            //Mapeo del paciente
            CreateMap<Persona, PacienteDTO>().ForMember(
                dto => dto.Nombre, 
                opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido}"));

            //Mapeo de las obras sociales
            CreateMap<ObraSocial, ObraSocialDTO>();
            CreateMap<ObraSocialDTO, ObraSocial>();

            //Mapeo de los roles
            CreateMap<RolDTO, Rol>();

          
            
                
        }
    }
}
