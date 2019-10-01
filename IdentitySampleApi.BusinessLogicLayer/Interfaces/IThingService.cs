using IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects;

using System.Collections.Generic;

namespace IdentitySampleApi.BusinessLogicLayer.Interfaces
{
    public interface IThingService
    {
        ThingDTO GetThing();
        string GetThingJson();
        List<ThingDTO> GetAllThing();
        string GetAllThingJson();
        List<ThingDTO> GetThingRange(int skip, int take);
        string GetThingRangeJson(int skip, int take);
    }
}
