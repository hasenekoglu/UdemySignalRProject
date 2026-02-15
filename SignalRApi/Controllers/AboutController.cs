using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService=aboutService;
    }

    [HttpGet]
    public IActionResult AboutList()
    {
        var values = _aboutService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateAbout(CreateAboutDto createAboutDto)
    {
        About about = new About()
        {
            ImageUrl = createAboutDto.ImageUrl,
            Title = createAboutDto.Title,
            Description = createAboutDto.Description
        };
        _aboutService.TAdd(about);
        return Ok("Hakkimda kismi basariyla eklendi.");
    }


    [HttpDelete]
    public IActionResult DeleteAbout(int id)
    {
        var value = _aboutService.TGetById(id);
        _aboutService.TDelete(value);
        return Ok("Hakkimda kismi basariyla silindi.");
    }

    [HttpPut]
    public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        About about = new About()
        {
            AboutId = updateAboutDto.AboutId,
            ImageUrl = updateAboutDto.ImageUrl,
            Title = updateAboutDto.Title,
            Description = updateAboutDto.Description
        };
        _aboutService.TUpdate(about);
        return Ok("Hakkimda kismi basariyla guncellendi.");
    }

    [HttpGet("GetAbout")]
    public IActionResult GetAbout(int id)
    {
        var value = _aboutService.TGetById(id);
        return Ok(value);
    }
}