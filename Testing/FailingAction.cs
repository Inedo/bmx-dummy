using System;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    [ActionProperties(
        "Failing Action",
        "An action which throws an unhandled exception.")]
    [Tag("dummy")]
    public sealed class FailingAction : ActionBase
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
