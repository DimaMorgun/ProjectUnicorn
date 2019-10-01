using System;
using System.Collections.Generic;

namespace IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects
{
    public class ThingDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public List<SubThingDTO> SubThings { get; set; }
    }

    public class SubThingDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
