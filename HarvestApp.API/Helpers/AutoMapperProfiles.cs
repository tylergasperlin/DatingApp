using System.Linq;
using AutoMapper;
using HarvestApp.API.Dtos;
using HarvestApp.API.Models;

namespace HarvestApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>()
                .ForMember(dest => dest.PhotoUrl,opt=>{
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url);
                })
                .ForMember(dest =>dest.Age, opt=>{
                    opt.ResolveUsing(d=>d.DateOfBirth.CalculateAge());
                });

            CreateMap<User,UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl,opt=>{
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url);
                })
                .ForMember(dest =>dest.Age, opt=>{
                    opt.ResolveUsing(d=>d.DateOfBirth.CalculateAge());
                });
            CreateMap<User,EmailDataDto>();
            CreateMap<Photo,PhotosForDetailsDto>();
            CreateMap<UserForUpdateDto,User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto,Photo>();
            CreateMap<UserForRegisterDto,User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m=>m.SenderPhotoUrl, opt => opt
                    .MapFrom(u=>u.Sender.Photos.FirstOrDefault(p=>p.IsMain).Url))
                .ForMember(m=>m.RecipientPhotoUrl, opt => opt
                    .MapFrom(u=>u.Recipient.Photos.FirstOrDefault(p=>p.IsMain).Url));



            
        }



    }
}