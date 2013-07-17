namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    /// <summary>
    /// Indicates a type of exception to throw.
    /// </summary>
    public enum ExceptionType
    {
        /// <summary>
        /// Throw a standard <see cref="System.InvalidOperationException"/>.
        /// </summary>
        Standard,
        /// <summary>
        /// Throw a <see cref="UnserializableException"/>.
        /// </summary>
        Unserializable,
        /// <summary>
        /// Throw an exception that is available only on the remote side of the agent.
        /// </summary>
        PresentOnlyOnRemote
    }
}
