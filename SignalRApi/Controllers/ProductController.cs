using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService ProductService, IMapper mapper)
    {
        _productService=ProductService;
        _mapper=mapper;
    }

    [HttpGet]
    public IActionResult ProductList()
    {
        var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
        return Ok(value);
    }
    [HttpGet("ProductListWithCategory")]
    public IActionResult ProductListWithCategory()
    {
       var context = new SignalRContext();
        var values = context.Products.Include(x => x.Category).Select(y=> new ResultProductWithCategory
        {
            Descripton = y.Descripton,
            ImageUrl = y.ImageUrl,
            Price = y.Price,
            ProductId = y.ProductId,
            ProductName = y.ProductName,
            Status = y.Status,
            CategoryName = y.Category.CategoryName
        });
        return Ok(values.ToList());
    }


    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto createProductDto)
    {
       _productService.TAdd(new Product()
       {
          ProductName = createProductDto.ProductName,
           Descripton = createProductDto.Descripton,
           ImageUrl = createProductDto.ImageUrl,
           Price = createProductDto.Price,
           Status = createProductDto.Status
       });
        return Ok("Urun basariyla eklendi.");
    }

    [HttpDelete]
    public IActionResult DeleteProduct(int id)
    {
        var value = _productService.TGetById(id);
        _productService.TDelete(value);
        return Ok("Urun basariyla silindi.");
    }

    [HttpGet("GetProduct")]
    public IActionResult GetProduct(int id)
    {
        var value = _productService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
    {
        _productService.TUpdate(new Product()
        {
            ProductId = updateProductDto.ProductId,
            ProductName = updateProductDto.ProductName,
            Descripton = updateProductDto.Descripton,
            ImageUrl = updateProductDto.ImageUrl,
            Price = updateProductDto.Price,
            Status = updateProductDto.Status
        });
        return Ok("Urun basariyla guncellendi.");
    }

}
