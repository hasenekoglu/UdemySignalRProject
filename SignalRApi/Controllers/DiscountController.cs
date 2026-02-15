using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly IDiscountService _discountService;
    private readonly IMapper _mapper;

    public DiscountController(IDiscountService DiscountService, IMapper mapper)
    {
        _discountService=DiscountService;
        _mapper=mapper;
    }

    [HttpGet]
    public IActionResult DiscountList()
    {
        var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
    {
       _discountService.TAdd(new Discount()
       {
           Amount = createDiscountDto.Amount,
           Description = createDiscountDto.Description,
           ImageUrl = createDiscountDto.ImageUrl,
           Title = createDiscountDto.Title
       });
        return Ok("Indirim bilgisi basariyla eklendi.");
    }

    [HttpDelete]
    public IActionResult DeleteDiscount(int id)
    {
        var value = _discountService.TGetById(id);
        _discountService.TDelete(value);
        return Ok("Indirim bilgisi basariyla silindi.");
    }

    [HttpGet("GetDiscount")]
    public IActionResult GetDiscount(int id)
    {
        var value = _discountService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
    {
        _discountService.TUpdate(new Discount()
        {
            DiscountId = updateDiscountDto.DiscountId,
            Amount = updateDiscountDto.Amount,
            Description = updateDiscountDto.Description,
            ImageUrl = updateDiscountDto.ImageUrl,
            Title = updateDiscountDto.Title
            
        });
        return Ok("Indirim bilgisi basariyla guncellendi.");
    }

}
