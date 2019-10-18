using System;

namespace IdentitySample.EntityLayer.Entities
{
    public class MultipleAInMultipleB
    {
        public Guid AssId { get; set; }
        public MultipleA Ass { get; set; }
        public Guid BssId { get; set; }
        public MultipleB Bss { get; set; }
    }
}
