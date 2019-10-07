using System;

namespace IdentitySample.EntityLayer.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreationDate { get; set; }
        DateTime RemoveDate { get; set; }
    }
}
