using IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects;

using Newtonsoft.Json;
using System.Collections.Generic;

namespace IdentitySampleApi.BusinessLogicLayer.Extentions
{
    public static class GetJson
    {
        public static string GetObjectJson(this ThingDTO thingDTO)
        {
            string jsonObject = JsonConvert.SerializeObject(thingDTO);

            return jsonObject;
        }

        public static string GetObjectJson(this List<ThingDTO> thingDTOs)
        {
            string jsonObject = JsonConvert.SerializeObject(thingDTOs);

            return jsonObject;
        }
    }
}
