using System;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    /// <summary>
    /// Test exception that is not serializable.
    /// </summary>
    public sealed class UnserializableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnserializableException"/> class.
        /// </summary>
        public UnserializableException()
            : base("This is a test exception that is not serializable.")
        {
        }
    };
}
