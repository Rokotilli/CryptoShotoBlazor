﻿using AutoMapper;
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


        public void CreateMapperPostFromDTO(ref IMapper mapper)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>()
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                    .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));
            });

            mapper = configuration.CreateMapper();
        }
    }
}