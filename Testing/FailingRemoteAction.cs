using System;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    /// <summary>
    /// A remote action which throws an unhandled exception.
    /// </summary>
    [ActionProperties(
        "Failing Remote Action",
        "A remote action which throws an unhandled exception.",
        "Dummy")]
    public sealed class FailingRemoteAction : RemoteActionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailingRemoteAction"/> class.
        /// </summary>
        public FailingRemoteAction()
        {
        }

        /// <summary>
        /// Specifies the type of exception to throw.
        /// </summary>
        [Persistent]
        [DisplayName("Exception Type")]
        [Category("Exception Type")]
        [Description("Specify the type of exception to throw while executing a remote command.")]
        public ExceptionType ExceptionType { get; set; }

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
            switch (this.ExceptionType)
            {
                case ExceptionType.Standard:
                    return "Throw an InvalidOperationException.";

                case ExceptionType.Unserializable:
                    return "Throw an exception that is not serializable.";

                case ExceptionType.PresentOnlyOnRemote:
                    return "Throw an exception of a type that is available only on the remote server.";

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <remarks>
        /// This method is always called on the BuildMaster server.
        /// </remarks>
        protected override void Execute()
        {
            this.ExecuteRemoteCommand(null);
        }

        /// <summary>
        /// When implemented in a derived class, processes an arbitrary command
        /// on the appropriate server.
        /// </summary>
        /// <param name="name">Name of command to process.</param>
        /// <param name="args">Optional command arguments.</param>
        /// <returns>
        /// Result of the command.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">This is a test exception.</exception>
        /// <exception cref="Inedo.BuildMasterExtensions.Dummy.Testing.UnserializableException"></exception>
        /// <remarks>
        /// This method is always invoked on the remote server by the system and should
        /// never be called directly. To begin remote execution from the <see cref="M:Inedo.BuildMaster.Extensibility.Actions.ActionBase.Execute" />
        /// method, call <see cref="M:Inedo.BuildMaster.Extensibility.Actions.RemoteActionBase.ExecuteRemoteCommand(System.String,System.String[])" />.
        /// </remarks>
        protected override string ProcessRemoteCommand(string name, string[] args)
        {
            switch (this.ExceptionType)
            {
                case ExceptionType.Standard:
                    throw new InvalidOperationException("This is a test exception.");

                case ExceptionType.Unserializable:
                    throw new UnserializableException();

                case ExceptionType.PresentOnlyOnRemote:
                    throw BuildNewException();
            }

            return null;
        }

        private static Exception BuildNewException()
        {
            var asmName = Guid.NewGuid().ToString();
            var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(asmName), AssemblyBuilderAccess.RunAndCollect);
            var mod = asm.DefineDynamicModule(asmName);
            var type = mod.DefineType("RemoteOnlyException", TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Serializable, typeof(Exception));

            var ctor1 = type.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            var il = ctor1.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldstr, "This is a test exception available only on the remote server.");
            il.Emit(OpCodes.Call, typeof(Exception).GetConstructor(new[] { typeof(string) }));
            il.Emit(OpCodes.Ret);

            var ctor2 = type.DefineConstructor(MethodAttributes.Family, CallingConventions.Standard, new[] { typeof(SerializationInfo), typeof(StreamingContext) });
            il = ctor2.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Call, typeof(Exception).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(SerializationInfo), typeof(StreamingContext) }, null));
            il.Emit(OpCodes.Ret);

            var builtType = type.CreateType();
            return (Exception)Activator.CreateInstance(builtType);
        }
    }
}
