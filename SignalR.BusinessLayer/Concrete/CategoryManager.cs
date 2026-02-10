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

    public void TAdd(Category enity)
    {
        _CategoryDal.Add(enity);
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

    public void TUpdate(Category entity)
    {
        _CategoryDal.Update(entity);
    }
}
