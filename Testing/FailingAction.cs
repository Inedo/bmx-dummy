using System;
using System.ComponentModel;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.Documentation;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    [DisplayName("Failing Action")]
    [Description("An action which throws an unhandled exception.")]
    [Tag("dummy")]
    public sealed class FailingAction : ActionBase
    {
        public override ExtendedRichDescription GetActionDescription() => new ExtendedRichDescription(new RichDescription("Throw an InvalidOperationException."));

        protected override void Execute()
        {
            throw new InvalidOperationException("This is a test exception.");
        }
    }
}
