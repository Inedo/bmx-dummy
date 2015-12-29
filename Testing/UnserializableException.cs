using System;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    public sealed class UnserializableException : Exception
    {
        public UnserializableException()
            : base("This is a test exception that is not serializable.")
        {
        }
    };
}
