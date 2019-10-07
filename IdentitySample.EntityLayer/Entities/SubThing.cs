using IdentitySample.EntityLayer.Interfaces;
using System;

namespace IdentitySample.EntityLayer.Entities
{
    public class SubThing : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
