using AutoMapper;
using HealFit.DTO.Request;
using HealFit.Model;


namespace HealFit.DTO.Mapping;
public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<CadastraDadosDTORequest, UsuarioModel>().ReverseMap();
        CreateMap<CadastraDadosDTORequest, DadosPessoaisModel>().ReverseMap();
    }
}
