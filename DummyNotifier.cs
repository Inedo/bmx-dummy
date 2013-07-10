using System;
using System.Collections.Generic;
using System.Text;
using Inedo.BuildMaster.Extensibility.Notifiers;
using Inedo.BuildMaster.Events;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [NotifierProperties("Dummy Notifier", "Listens to every event, but does absolutely nothing with it.")]
    public class DummyNotifier : NotifierBase
    {
        public override EventType[] Events
        {
            get { return EventTypes.ToArray(); }
        }

        public override void EventOccured(NotificationContext context)
        {
            throw new Exception();
        }

        public override string ToString()
        {
            return "Listens to every event, but does absolutely nothing with it.";
        }
    }
}
