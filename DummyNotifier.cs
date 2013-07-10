using Inedo.BuildMaster.Events;
using Inedo.BuildMaster.Extensibility.Notifiers;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [NotifierProperties(
        "Dummy Notifier",
        "Listens to every event, but does absolutely nothing with it.")]
    public sealed class DummyNotifier : NotifierBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyNotifier"/> class.
        /// </summary>
        public DummyNotifier()
        {
        }

        public override EventType[] Events
        {
            get { return EventTypes.ToArray(); }
        }

        public override void EventOccured(NotificationContext context)
        {
        }

        public override string ToString()
        {
            return "Listens to every event, but does absolutely nothing with it.";
        }
    }
}
