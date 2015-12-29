using System;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    [ActionProperties(
        "Failing Agent-based Action",
        "An agent-based action which throws an unhandled exception.")]
    [Tag("dummy")]
    public sealed class FailingAgentBasedAction : AgentBasedActionBase
    {
        public override ActionDescription GetActionDescription()
        {
            return new ActionDescription(
                new ShortActionDescription("Throw an InvalidOperationException.")
            );
        }

        protected override void Execute()
        {
            throw new InvalidOperationException("This is a test exception.");
        }
    }
}
