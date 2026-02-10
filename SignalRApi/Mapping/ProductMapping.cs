using AutoMapper;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Mapping;

public class ProductMapping:Profile
{
    public ProductMapping()
    {
        CreateMap<Contact,ResultContactDto>().ReverseMap();
        CreateMap<Contact,GetContactDto>().ReverseMap();
        CreateMap<Contact,CreateContactDto>().ReverseMap();
        CreateMap<Contact,UpdateContactDto>().ReverseMap();
    }
}
