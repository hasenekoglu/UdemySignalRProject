using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialController : ControllerBase
{
    private readonly ITestimonialService _testimonialService;
    private readonly IMapper _mapper;

    public TestimonialController(ITestimonialService TestimonialService, IMapper mapper)
    {
        _testimonialService=TestimonialService;
        _mapper=mapper;
    }

    [HttpGet]
    public IActionResult TestimonialList()
    {
        var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll());
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
    {
       _testimonialService.TAdd(new Testimonial()
       {
           Comment = createTestimonialDto.Comment,
           ImageUrl = createTestimonialDto.ImageUrl,
           Name = createTestimonialDto.Name,
           Title = createTestimonialDto.Title,
           Status = createTestimonialDto.Status
       });
        return Ok("Musteri Yorum bilgisi basariyla eklendi.");
    }

    [HttpDelete]
    public IActionResult DeleteTestimonial(int id)
    {
        var value = _testimonialService.TGetById(id);
        _testimonialService.TDelete(value);
        return Ok("Musteri Yorum bilgisi basariyla silindi.");
    }

    [HttpGet("GetTestimonial")]
    public IActionResult GetTestimonial(int id)
    {
        var value = _testimonialService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
    {
        _testimonialService.TUpdate(new Testimonial()
        {
            Comment = updateTestimonialDto.Comment,
            ImageUrl = updateTestimonialDto.ImageUrl,
            Name = updateTestimonialDto.Name,
            Title = updateTestimonialDto.Title,
            Status = updateTestimonialDto.Status,
            TestimonialId = updateTestimonialDto.TestimonialId
        });
        return Ok("Musteri Yorum bilgisi basariyla guncellendi.");
    }

}
