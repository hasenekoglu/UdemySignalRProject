using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntitiyLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfOrderDal : GenericRepository<Order>, IOrderDal
{
    public EfOrderDal(SignalRContext context) : base(context)
    {
    }

    public int ActiveOrderCount()
    {
        using var context = new SignalRContext();
        return context.Orders.Where(o => o.Description == "Musteri Masada").Count();
    }

    public decimal LastOrderPrice()
    {
        using var context = new SignalRContext();
        return context.Orders.OrderByDescending(o => o.OrderId).Take(1)
            .Select(o => o.TotalPrice)
            .FirstOrDefault();
    }

    public int TotalOrderCount()
    {
        using var context = new SignalRContext();
        return context.Orders.Count();
    }
}
