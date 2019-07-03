using System;

namespace YouLearn.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewBase();
        }
        
        public virtual Guid Id { get; set; }
    }
}
