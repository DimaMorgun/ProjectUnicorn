using System;
using System.Collections.Generic;

namespace IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects
{
    public class GetThingDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public List<GetThingDTOSubThingDTOViewItem> SubThings { get; set; }
    }

    public class GetThingDTOSubThingDTOViewItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
