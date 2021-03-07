using System;
using System.Collections.Generic;
using Alakazam.Framework.Domain;

namespace Alakazam.Framework.Domain
{
    public abstract class BaseAggregate
    {
        public Guid Id { get; set; }
        protected ICollection<IDomainEvent> DomainEvents { get; private set; }

        public BaseAggregate()
        {
            Id = Guid.NewGuid();
            DomainEvents = new List<IDomainEvent>();
        }

        protected void AddEvent(IDomainEvent e)
        {
            Guard.That(e == null, new ArgumentNullException(nameof(e)));
            
            DomainEvents.Add(e);
        }
    }
}