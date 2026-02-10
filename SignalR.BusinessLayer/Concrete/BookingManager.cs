using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class BookingManager : IBookingService
{
    private readonly IBookingDal _BookingDal;

    public BookingManager(IBookingDal BookingDal)
    {
        _BookingDal=BookingDal;
    }

    public void TAdd(Booking enity)
    {
        _BookingDal.Add(enity);
    }

    public void TDelete(Booking entity)
    {
        _BookingDal.Delete(entity);
    }

    public List<Booking> TGetAll()
    {
       return _BookingDal.GetAll();
    }

    public Booking TGetById(int id)
    {
        return _BookingDal.GetById(id);
    }

    public void TUpdate(Booking entity)
    {
        _BookingDal.Update(entity);
    }
}
