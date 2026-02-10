using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class ContactManager : IContactService
{
    private readonly IContactDal _ContactDal;

    public ContactManager(IContactDal ContactDal)
    {
        _ContactDal=ContactDal;
    }

    public void TAdd(Contact enity)
    {
        _ContactDal.Add(enity);
    }

    public void TDelete(Contact entity)
    {
        _ContactDal.Delete(entity);
    }

    public List<Contact> TGetAll()
    {
       return _ContactDal.GetAll();
    }

    public Contact TGetById(int id)
    {
        return _ContactDal.GetById(id);
    }

    public void TUpdate(Contact entity)
    {
        _ContactDal.Update(entity);
    }
}
