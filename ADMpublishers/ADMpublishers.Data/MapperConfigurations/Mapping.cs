using ADMpublishers.Data.Dto;
using ADMpublishers.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.MapperConfigurations
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(des => des.city,opts => opts.MapFrom(source => source.city.name))
                .ForMember(des => des.state, opts => opts.MapFrom(source => source.city.state.name));

            CreateMap<AuthorDto, AuthorFile>();
              


        }
    }


    //var destination = Mapping.Mapper.Map<Destination>(yourSourceInstance);
}
