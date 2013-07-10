using Inedo.BuildMaster.Extensibility.PromotionRequirements;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;

namespace Inedo.BuildMasterExtensions.Dummy
{
    /// <summary>
    /// Editor for the dummy state managing promotion requirement.
    /// </summary>
    public sealed class DummyStateManagingPromotionRequirementEditor : PromotionRequirementEditorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyStateManagingPromotionRequirementEditor"/> class.
        /// </summary>
        public DummyStateManagingPromotionRequirementEditor()
        {
        }

        public override void BindToForm(PromotionRequirementBase extension)
        {
            EnsureChildControls();
        }

        public override PromotionRequirementBase CreateFromForm()
        {
            EnsureChildControls();
            return new DummyStateManagingPromotionRequirement();
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            CUtil.Add(this,
                new FormFieldGroup(
                    "No Options",
                    "There are no options to configure for this promotion requirement.",
                    true
                )
            );
        }
    }
}
