using IdentitySample.EntityLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace IdentitySample.EntityLayer.Entities
{
    public class Thing : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public List<SubThing> SubThings { get; set; }
    }
}
