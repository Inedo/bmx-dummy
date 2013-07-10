using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

using Inedo.BuildMaster.Extensibility.Providers;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;

namespace Inedo.BuildMasterExtensions.Dummy
{
    public sealed class DummyDatabaseProviderEditor : 
        Inedo.BuildMaster.Web.Controls.Extensions.ProviderEditorBase
    {
        CheckBox chkIsInitialized, chkThrowNotImplementedExceptions;

        public DummyDatabaseProviderEditor()
        {
            Init += new EventHandler(DummyDatabaseProviderEditor_Init);
        }

        void DummyDatabaseProviderEditor_Init(object sender, EventArgs e)
        {
            chkIsInitialized = new CheckBox();
            chkIsInitialized.Text = "Initialized";

            chkThrowNotImplementedExceptions = new CheckBox();
            chkThrowNotImplementedExceptions.Text = "Throw NotImplementedExceptions";

            Controls.Add(new FormFieldGroup(
                "Dummy Options",
                new StandardFormField(null, chkIsInitialized),
                new StandardFormField(null, chkThrowNotImplementedExceptions)
                ));
        }

        public override void BindToForm(ProviderBase extension)
        {
            var provider = (DummyDatabaseProvider)extension;
            chkIsInitialized.Checked = provider.IsInitialized;
            chkThrowNotImplementedExceptions.Checked = provider.ThrowNotImplementedExceptions;            
        }

        public override ProviderBase CreateFromForm()
        {
            var provider = new DummyDatabaseProvider();
            provider.IsInitialized = chkIsInitialized.Checked;
            provider.ThrowNotImplementedExceptions = chkThrowNotImplementedExceptions.Checked;
            return provider;

        }
    }
}
