using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class FeatureManager : IFeatureService
{
    private readonly IFeatureDal _FeatureDal;

    public FeatureManager(IFeatureDal FeatureDal)
    {
        _FeatureDal=FeatureDal;
    }

    public void TAdd(Feature enity)
    {
        _FeatureDal.Add(enity);
    }

    public void TDelete(Feature entity)
    {
        _FeatureDal.Delete(entity);
    }

    public List<Feature> TGetAll()
    {
       return _FeatureDal.GetAll();
    }

    public Feature TGetById(int id)
    {
        return _FeatureDal.GetById(id);
    }

    public void TUpdate(Feature entity)
    {
        _FeatureDal.Update(entity);
    }
}
