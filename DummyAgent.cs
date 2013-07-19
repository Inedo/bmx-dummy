using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inedo.BuildMaster.Extensibility.Agents;
using Inedo.BuildMaster.Data;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [AgentProperties("Dummy Agent",
        "An agent for testing purposes")]
    public class DummyAgent : AgentBase
    {
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
