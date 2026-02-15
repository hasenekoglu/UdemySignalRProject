using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeatureController : ControllerBase
{
    private readonly IFeatureService _featureService;
    private readonly IMapper _mapper;

    public FeatureController(IFeatureService FeatureService, IMapper mapper)
    {
        _featureService=FeatureService;
        _mapper=mapper;
    }

    [HttpGet]
    public IActionResult FeatureList()
    {
        var value = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetAll());
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
    {
       _featureService.TAdd(new Feature()
       {
           Descripton1 = createFeatureDto.Descripton1,
           Descripton2 = createFeatureDto.Descripton2,
           Descripton3 = createFeatureDto.Descripton3,
           Title1 = createFeatureDto.Title1,
           Title2 = createFeatureDto.Title2,
           Title3 = createFeatureDto.Title3,
       });
        return Ok("Ozellik basariyla eklendi.");
    }

    [HttpDelete]
    public IActionResult DeleteFeature(int id)
    {
        var value = _featureService.TGetById(id);
        _featureService.TDelete(value);
        return Ok("Ozellik basariyla silindi.");
    }

    [HttpGet("GetFeature")]
    public IActionResult GetFeature(int id)
    {
        var value = _featureService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        _featureService.TUpdate(new Feature()
        {
            FeatureId = updateFeatureDto.FeatureId,
            Descripton1 = updateFeatureDto.Descripton1,
            Descripton2 = updateFeatureDto.Descripton2,
            Descripton3 = updateFeatureDto.Descripton3,
            Title1 = updateFeatureDto.Title1,
            Title2 = updateFeatureDto.Title2,
            Title3 = updateFeatureDto.Title3,
            
        });
        return Ok("Ozellik basariyla guncellendi.");
    }

}
