using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _CategoryDal;

    public CategoryManager(ICategoryDal CategoryDal)
    {
        _CategoryDal=CategoryDal;
    }

    public int TActiveCategoryCount()
    {
        return _CategoryDal.ActiveCategoryCount();
    }

    public void TAdd(Category enity)
    {
        _CategoryDal.Add(enity);
    }

    public int TCategoryCount()
    {
        return _CategoryDal.CategoryCount();
    }

    public void TDelete(Category entity)
    {
        _CategoryDal.Delete(entity);
    }

    public List<Category> TGetAll()
    {
       return _CategoryDal.GetAll();
    }

    public Category TGetById(int id)
    {
        return _CategoryDal.GetById(id);
    }

    public int TPassiveCategoryCount()
    {
        return _CategoryDal.PassiveCategoryCount();
    }

    public void TUpdate(Category entity)
    {
        _CategoryDal.Update(entity);
    }
}
