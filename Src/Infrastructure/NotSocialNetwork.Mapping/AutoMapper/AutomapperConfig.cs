﻿using AutoMapper;
using NotSocialNetwork.Application.DTOs;
using NotSocialNetwork.Application.Entities;
using System.Linq;

namespace NotSocialNetwork.Mapping.AutoMapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            UserMapper();

            PublicationMapper();

            ImageMapper();
        }

        private void UserMapper()
        {
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<UserEntity, RegistrationUserDTO>().ReverseMap();
            CreateMap<UserEntity, RegistrationResponseDTO>();
        }

        private void PublicationMapper()
        {
            CreateMap<PublicationEntity, PublicationDTO>()
                .ForMember(p => p.ImagePaths,
                           opt => opt.MapFrom(src => src.Images.Select(i => i.Title)))
                .ReverseMap();

            CreateMap<PublicationEntity, AddPublicationDTO>().ReverseMap();

            CreateMap<PublicationEntity, UpdatePublicationDTO>().ReverseMap();
        }

        public void ImageMapper()
        {
            CreateMap<ImageEntity, UpdateFileDTO>();
        }
    }
}
