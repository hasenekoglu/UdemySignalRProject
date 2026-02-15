using SignalR.EntitiyLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract;

public interface IProductDal : IGenericDal<Product>
{
    List<Product> GetProductsWithCategories();
}
