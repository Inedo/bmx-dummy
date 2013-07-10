using Inedo.BuildMaster.Extensibility.PromotionRequirements;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [PromotionRequirementsProperties(
        "Dummy State Managing Promotion Requirement",
        "A promotion requirement that determines whether it's met or required via state.")]
    public sealed class DummyStateManagingPromotionRequirement : PromotionRequirementBase, IPromotionRequirementStateManager
    {
        private DummyPromotionRequirementState state = new DummyPromotionRequirementState { Met = false, Required = true };

        public override string ToString()
        {
            return "Initially required and not met.";
        }

        public override bool IsRequired(PromotionContext context)
        {
            return this.state.Required;
        }

        public override bool IsMet(PromotionContext context)
        {
            return this.state.Met;
        }

        public PromotionRequirementStateBase GetInitialState(PromotionContext ctx)
        {
            return new DummyPromotionRequirementState
            {
                Met = false,
                Required = true
            };
        }

        public void SetState(PromotionRequirementStateBase state)
        {
            this.state = (DummyPromotionRequirementState)state;
        }
    }
}
