using AutoMapper;
using DAL.Models;

namespace CryptoShoto.DTO
{
    public class DTOService
    {

        public void CreateMapperPost(ref IMapper mapper)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, Post>()
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                    .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));
            });
            mapper = configuration.CreateMapper();
        }

        public void CreateMapperUser(ref IMapper mapper)
        {
			var configuration = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<RegistrationDTO, User>()
					.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
					.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
					.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
			});
			mapper = configuration.CreateMapper();
		}
    }
}
