using IdentitySampleApi.BusinessLogicLayer.Extentions;
using IdentitySampleApi.BusinessLogicLayer.Helpers;
using IdentitySampleApi.BusinessLogicLayer.Interfaces;
using IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySampleApi.BusinessLogicLayer.Services
{
    public class ThingService : IThingService
    {
        private List<GetThingDTO> _thingDTOs;

        public ThingService()
        {
            var thingCount = NumberHelper.GetRandomNumber(10);
            var subThingCount = NumberHelper.GetRandomNumber(10);

            _thingDTOs = GetThingDTOs(thingCount, subThingCount);
        }

        public GetThingDTO GetThing()
        {
            return _thingDTOs.FirstOrDefault();
        }

        public string GetThingJson()
        {
            GetThingDTO thingDTO = GetThing();
            string json = thingDTO.GetObjectJson();

            return json;
        }

        public List<GetThingDTO> GetAllThing()
        {
            return _thingDTOs;
        }

        public string GetAllThingJson()
        {
            string json = _thingDTOs.GetObjectJson();

            return json;
        }

        public List<GetThingDTO> GetThingRange(int skip, int take)
        {
            List<GetThingDTO> thingDTOs = _thingDTOs.Skip(skip).Take(take).ToList();

            return thingDTOs;
        }

        public string GetThingRangeJson(int skip, int take)
        {
            List<GetThingDTO> thingDTOs = GetThingRange(skip, take);
            string json = thingDTOs.GetObjectJson();

            return json;
        }

        private List<GetThingDTO> GetThingDTOs(int thingDTOsCount = 1, int subThingDTOsCount = 1)
        {
            var thingDTOs = new List<GetThingDTO>();

            for (int i = 0; i < thingDTOsCount; i++)
            {
                var thingDto = new GetThingDTO();
                thingDto.Id = Guid.NewGuid();
                thingDto.Name = $"Name #{i}";
                thingDto.Description = $"TO{new string('O', i)} MUCH LONG DESCRIPTION #{i}.";
                thingDto.Age = NumberHelper.GetRandomNumber(100);
                thingDto.SubThings = GetSubThingDTOs(subThingDTOsCount);

                thingDTOs.Add(thingDto);
            }

            return thingDTOs;
        }

        private List<GetThingDTOSubThingDTOViewItem> GetSubThingDTOs(int subThingDTOsCount = 1)
        {
            var subThingDTOs = new List<GetThingDTOSubThingDTOViewItem>();

            for (int i = 0; i < subThingDTOsCount; i++)
            {
                var subThingDto = new GetThingDTOSubThingDTOViewItem();
                subThingDto.Id = Guid.NewGuid();
                subThingDto.Name = $"Name #{i}";
                subThingDto.Description = $"TO{new string('O', i)} MUCH LONG DESCRIPTION #{i}.";

                subThingDTOs.Add(subThingDto);
            }

            return subThingDTOs;
        }
    }
}
