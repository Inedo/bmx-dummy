using System;
using System.Collections.Generic;
using System.Text;
using Inedo.BuildMaster.Web.Controls.Extensions;
using Inedo.BuildMaster.Extensibility.Providers;

namespace Inedo.BuildMasterExtensions.Dummy
{
    internal sealed class DummySourceControlProviderEditor : ProviderEditorBase
    {
        public DummySourceControlProviderEditor()
        {
        }

        public override void BindToForm(ProviderBase extension)
        {
        }
        public override ProviderBase CreateFromForm()
        {
            return new DummySourceControlProvider();
        }
    }
}
