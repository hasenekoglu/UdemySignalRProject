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

    public int TProductCount()
    {
       return _ProductDal.ProductCount();
    }

    public int TProductCountByCategoryNameDrink()
    {
        return _ProductDal.ProductCountByCategoryNameDrink();
    }

    public int TProductCountByCategoryNameHamburger()
    {
        return _ProductDal.ProductCountByCategoryNameHamburger();
    }

    public string TProductNameByMaxPrice()
    {
       return _ProductDal.ProductNameByMaxPrice();
    }

    public string TProductNameByMinPrice()
    {
        return _ProductDal.ProductNameByMinPrice();
    }

    public decimal TProductPriceAvg()
    {
        return _ProductDal.ProductPriceAvg();
    }

    public decimal TProductAvgPriceByHamburger()
    {
        return _ProductDal.ProductAvgPriceByHamburger();
    }

    public void TUpdate(Product entity)
    {
        _ProductDal.Update(entity);
    }
}
