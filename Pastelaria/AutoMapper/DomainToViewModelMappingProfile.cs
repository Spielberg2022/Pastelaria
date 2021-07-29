using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Pastelaria.ViewModels;
using Pastelaria.Domain.Usuario.Dto;

namespace Pastelaria.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioViewModel, UsuarioDto>();
        }
    }
}