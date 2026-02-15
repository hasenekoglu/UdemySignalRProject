using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _ProductDal;

    public ProductManager(IProductDal ProductDal)
    {
        _ProductDal=ProductDal;
    }

    public void TAdd(Product enity)
    {
        _ProductDal.Add(enity);
    }

    public void TDelete(Product entity)
    {
        _ProductDal.Delete(entity);
    }

    public List<Product> TGetAll()
    {
       return _ProductDal.GetAll();
    }

    public Product TGetById(int id)
    {
        return _ProductDal.GetById(id);
    }

    public List<Product> TGetProductsWithCategories()
    {
        return _ProductDal.GetProductsWithCategories();
    }

    public void TUpdate(Product entity)
    {
        _ProductDal.Update(entity);
    }
}
