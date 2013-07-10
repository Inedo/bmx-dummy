using System.Web.UI.WebControls;
using Inedo.BuildMaster.Extensibility.PromotionRequirements;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;

namespace Inedo.BuildMasterExtensions.Dummy
{
    /// <summary>
    /// Editor for the dummy promotion requirement state.
    /// </summary>
    public sealed class DummyPromotionRequirementStateEditor : PromotionRequirementStateEditorBase
    {
        private CheckBox chkIsRequired;
        private CheckBox chkIsMet;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyPromotionRequirementStateEditor"/> class.
        /// </summary>
        public DummyPromotionRequirementStateEditor()
        {
        }

        public override void BindToForm(PromotionRequirementStateBase extension)
        {
            EnsureChildControls();

            var dummy = (DummyPromotionRequirementState)extension;
            this.chkIsRequired.Checked = dummy.Required;
            this.chkIsMet.Checked = dummy.Met;
        }

        public override PromotionRequirementStateBase CreateFromForm()
        {
            EnsureChildControls();

            return new DummyPromotionRequirementState()
            {
                Required = this.chkIsRequired.Checked,
                Met = this.chkIsMet.Checked
            };
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation
        /// to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.chkIsRequired = new CheckBox()
            {
                Text = "Is Required"
            };

            this.chkIsMet = new CheckBox()
            {
                Text = "Is Met"
            };

            CUtil.Add(this,
                new FormFieldGroup(
                    "Dummy Promotion Requirement Options",
                    "Specify whether this promotion requirement is required and/or met.",
                    true,
                    new StandardFormField(string.Empty, this.chkIsRequired),
                    new StandardFormField(string.Empty, this.chkIsMet)
                )
            );
        }
    }
}
