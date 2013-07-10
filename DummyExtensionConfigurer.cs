using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Configurers.Extension;

[assembly: ExtensionConfigurer(typeof(Inedo.BuildMasterExtensions.Dummy.DummyExtensionConfigurer))]

namespace Inedo.BuildMasterExtensions.Dummy
{
    public sealed class DummyExtensionConfigurer : ExtensionConfigurerBase
    {
        [Persistent]
        public int MyProperty { get; set; }
        [Persistent]
        public string MyProperty2 { get; set; }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
