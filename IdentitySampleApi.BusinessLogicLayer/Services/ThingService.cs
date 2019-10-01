using IdentitySampleApi.BusinessLogicLayer.Helpers;
using IdentitySampleApi.BusinessLogicLayer.Interfaces;
using IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects;
using IdentitySampleApi.BusinessLogicLayer.Extentions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySampleApi.BusinessLogicLayer.Services
{
    public class ThingService : IThingService
    {
        private List<ThingDTO> _thingDTOs;

        public ThingService()
        {
            var thingCount = NumberHelper.GetRandomNumber(10);
            var subThingCount = NumberHelper.GetRandomNumber(10);

            _thingDTOs = GetThingDTOs(thingCount, subThingCount);
        }

        public ThingDTO GetThing()
        {
            return _thingDTOs.FirstOrDefault();
        }

        public string GetThingJson()
        {
            ThingDTO thingDTO = GetThing();
            string json = thingDTO.GetObjectJson();

            return json;
        }

        public List<ThingDTO> GetAllThing()
        {
            return _thingDTOs;
        }

        public string GetAllThingJson()
        {
            string json = _thingDTOs.GetObjectJson();

            return json;
        }

        public List<ThingDTO> GetThingRange(int skip, int take)
        {
            List<ThingDTO> thingDTOs = _thingDTOs.Skip(skip).Take(take).ToList();

            return thingDTOs;
        }

        public string GetThingRangeJson(int skip, int take)
        {
            List<ThingDTO> thingDTOs = GetThingRange(skip, take);
            string json = thingDTOs.GetObjectJson();

            return json;
        }

        private List<ThingDTO> GetThingDTOs(int thingDTOsCount = 1, int subThingDTOsCount = 1)
        {
            var thingDTOs = new List<ThingDTO>();

            for (int i = 0; i < thingDTOsCount; i++)
            {
                var thingDto = new ThingDTO();
                thingDto.Id = Guid.NewGuid();
                thingDto.Name = $"Name #{i}";
                thingDto.Description = $"TO{new string('O', i)} MUCH LONG DESCRIPTION #{i}.";
                thingDto.Age = NumberHelper.GetRandomNumber(100);
                thingDto.SubThings = GetSubThingDTOs(subThingDTOsCount);

                thingDTOs.Add(thingDto);
            }

            return thingDTOs;
        }

        private List<SubThingDTO> GetSubThingDTOs(int subThingDTOsCount = 1)
        {
            var subThingDTOs = new List<SubThingDTO>();

            for (int i = 0; i < subThingDTOsCount; i++)
            {
                var subThingDto = new SubThingDTO();
                subThingDto.Id = Guid.NewGuid();
                subThingDto.Name = $"Name #{i}";
                subThingDto.Description = $"TO{new string('O', i)} MUCH LONG DESCRIPTION #{i}.";

                subThingDTOs.Add(subThingDto);
            }

            return subThingDTOs;
        }
    }
}
