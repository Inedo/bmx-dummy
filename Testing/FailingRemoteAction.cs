using System;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.Documentation;
using Inedo.Serialization;

namespace Inedo.BuildMasterExtensions.Dummy.Testing
{
    [DisplayName("Failing Remote Action")]
    [Description("A remote action which throws an unhandled exception.")]
    [Tag("dummy")]
    public sealed class FailingRemoteAction : RemoteActionBase
    {
        [Persistent]
        [DisplayName("Exception Type")]
        [Category("Exception Type")]
        [Description("Specify the type of exception to throw while executing a remote command.")]
        public ExceptionType ExceptionType { get; set; }

        public override ExtendedRichDescription GetActionDescription()
        {
            var desc = string.Empty;

            switch (this.ExceptionType)
            {
                case ExceptionType.Standard:
                    desc = "Throw an InvalidOperationException.";
                    break;
                case ExceptionType.Unserializable:
                    desc = "Throw an exception that is not serializable.";
                    break;
                case ExceptionType.PresentOnlyOnRemote:
                    desc = "Throw an exception of a type that is available only on the remote server.";
                    break;
            }

            return new ExtendedRichDescription(new RichDescription(desc));
        }

        protected override void Execute() => this.ExecuteRemoteCommand(null);

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
