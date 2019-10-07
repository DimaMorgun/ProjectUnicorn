using IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects;

using System.Collections.Generic;

namespace IdentitySampleApi.BusinessLogicLayer.Interfaces
{
    public interface IThingService
    {
        GetThingDTO GetThing();
        string GetThingJson();
        List<GetThingDTO> GetAllThing();
        string GetAllThingJson();
        List<GetThingDTO> GetThingRange(int skip, int take);
        string GetThingRangeJson(int skip, int take);
    }
}
