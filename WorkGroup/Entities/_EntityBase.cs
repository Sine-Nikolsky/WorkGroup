using System;

namespace WorkGroup.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }
        
        public DateTime? DeleteDate { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            ModifyDate = CreateDate;
        }
    }
}
