using System;
using System.Collections.Generic;

namespace IdentitySample.EntityLayer.Entities
{
    public class MultipleB
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public ICollection<MultipleAInMultipleB> multipleAInMultipleBs { get; set; }
    }
}
