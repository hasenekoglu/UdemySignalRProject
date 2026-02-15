using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;

    public ContactController(IContactService ContactService, IMapper mapper)
    {
        _contactService=ContactService;
        _mapper=mapper;
    }

    [HttpGet]
    public IActionResult ContactList()
    {
        var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateContact(CreateContactDto createContactDto)
    {
       _contactService.TAdd(new Contact()
       {
           FooterDescription = createContactDto.FooterDescription,
           Location = createContactDto.Location,
           Email = createContactDto.Email,
           PhoneNumber = createContactDto.PhoneNumber,
       });
        return Ok("Iletisim bilgisi basariyla eklendi.");
    }

    [HttpDelete]
    public IActionResult DeleteContact(int id)
    {
        var value = _contactService.TGetById(id);
        _contactService.TDelete(value);
        return Ok("Iletisim bilgisi basariyla silindi.");
    }

    [HttpGet("GetContact")]
    public IActionResult GetContact(int id)
    {
        var value = _contactService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateContact(UpdateContactDto updateContactDto)
    {
        _contactService.TUpdate(new Contact()
        {
            ContactId = updateContactDto.ContactId,
            FooterDescription = updateContactDto.FooterDescription,
            Location = updateContactDto.Location,
            Email = updateContactDto.Email,
            PhoneNumber = updateContactDto.PhoneNumber
        });
        return Ok("Iletisim bilgisi basariyla guncellendi.");
    }

}
