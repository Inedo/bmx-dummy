using Inedo.BuildMaster.Data;
using Inedo.BuildMaster.Extensibility.Agents;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [AgentProperties("Dummy Agent", "An agent for testing purposes")]
    public sealed class DummyAgent : AgentBase
    {
        public override AgentDescription GetAgentDescription()
        {
            return new AgentDescription("dummy", false);
        }

        protected override TService GetAgentServiceInternal<TService>()
        {
            return this as TService;
        }

        protected override string GetAgentStatusInternal(IHostedAgentContext context)
        {
            return Domains.ServerStatus.Ready;
        }
    }
}
