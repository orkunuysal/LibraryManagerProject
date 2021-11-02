using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events
{
    public class IntegrationBaseEvent
    {
        public Guid guid { get; set; }
        public DateTime CreationDate { get; set; }

        public IntegrationBaseEvent()
        {
            guid = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
        public IntegrationBaseEvent(Guid guid, DateTime creationDate)
        {
            this.guid = guid;
            CreationDate = creationDate;
        }
    }
}
