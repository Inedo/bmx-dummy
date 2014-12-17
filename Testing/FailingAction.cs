using System;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    /// <summary>
    /// An action which throws an unhandled exception.
    /// </summary>
    [ActionProperties(
        "Failing Action",
        "An action which throws an unhandled exception.")]
    [Tag("dummy")]
    public sealed class FailingAction : ActionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailingAction"/> class.
        /// </summary>
        public FailingAction()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <remarks>
        /// This should return a user-friendly string describing what the Action does
        /// and the state of its important persistent properties.
        /// </remarks>
        public override string ToString()
        {
            return "Throw an InvalidOperationException.";
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">This is a test exception.</exception>
        /// <remarks>
        /// This method is always called on the BuildMaster server.
        /// </remarks>
        protected override void Execute()
        {
            throw new InvalidOperationException("This is a test exception.");
        }
    }
}
