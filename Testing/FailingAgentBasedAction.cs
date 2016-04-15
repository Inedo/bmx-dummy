using System;
using System.ComponentModel;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.Documentation;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    [DisplayName("Failing Agent-based Action")]
    [Description("An agent-based action which throws an unhandled exception.")]
    [Tag("dummy")]
    public sealed class FailingAgentBasedAction : AgentBasedActionBase
    {
        public override ExtendedRichDescription GetActionDescription() => new ExtendedRichDescription(new RichDescription("Throw an InvalidOperationException."));

        protected override void Execute()
        {
            throw new InvalidOperationException("This is a test exception.");
        }
    }
}
