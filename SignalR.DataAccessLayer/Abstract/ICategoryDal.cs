using SignalR.EntitiyLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract;

public interface ICategoryDal : IGenericDal<Category>
{
    public int CategoryCount();
    int ActiveCategoryCount();
    int PassiveCategoryCount();
}
    