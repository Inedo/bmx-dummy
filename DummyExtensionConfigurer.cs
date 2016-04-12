using Inedo.BuildMaster.Extensibility.Configurers.Extension;
using Inedo.Serialization;

[assembly: ExtensionConfigurer(typeof(Inedo.BuildMasterExtensions.Dummy.DummyExtensionConfigurer))]

namespace Inedo.BuildMasterExtensions.Dummy
{
    public sealed class DummyExtensionConfigurer : ExtensionConfigurerBase
    {
        [Persistent]
        public int MyProperty { get; set; }
        [Persistent]
        public string MyProperty2 { get; set; }
    }
}
