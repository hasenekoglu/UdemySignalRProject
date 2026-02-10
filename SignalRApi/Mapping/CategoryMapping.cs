using AutoMapper;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Mapping;

public class CategoryMapping:Profile
{
    public CategoryMapping()
    {
        CreateMap<Category,ResultCategoryDto>().ReverseMap();
        CreateMap<Category,GetCategoryDto>().ReverseMap();
        CreateMap<Category,CreateCategoryDto>().ReverseMap();
        CreateMap<Category,UpdateCategoryDto>().ReverseMap();
    }
}
