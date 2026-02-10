using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class DiscountManager : IDiscountService
{
    private readonly IDiscountDal _DiscountDal;

    public DiscountManager(IDiscountDal DiscountDal)
    {
        _DiscountDal=DiscountDal;
    }

    public void TAdd(Discount enity)
    {
        _DiscountDal.Add(enity);
    }

    public void TDelete(Discount entity)
    {
        _DiscountDal.Delete(entity);
    }

    public List<Discount> TGetAll()
    {
       return _DiscountDal.GetAll();
    }

    public Discount TGetById(int id)
    {
        return _DiscountDal.GetById(id);
    }

    public void TUpdate(Discount entity)
    {
        _DiscountDal.Update(entity);
    }
}
