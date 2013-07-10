using System;
using System.Collections.Generic;
using System.Text;
using Inedo.BuildMaster.Extensibility.PromotionRequirements;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Web;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [PromotionRequirementsProperties(
        "Dummy State Managing Promotion Requirement",
        "A promotion requirement that determines whether it's met or required via state.")]
    [CustomEditor(typeof(DummyStateManagingPromotionRequirementEditor))]
    public sealed class DummyStateManagingPromotionRequirement 
        : PromotionRequirementBase
        , IPromotionRequirementStateManager
    {
        DummyPromotionRequirementState _state = new DummyPromotionRequirementState
            {
                Met = false,
                Required = true
            };

        public override string ToString()
        {
            return "Initially required and not met.";
        }

        public override bool IsRequired(PromotionContext context)
        {
            return _state.Required;
        }

        public override bool IsMet(PromotionContext context)
        {
            return _state.Met;
        }

        #region IPromotionRequirementStateManager Members

        PromotionRequirementStateBase IPromotionRequirementStateManager.GetInitialState(PromotionContext ctx)
        {
            return new DummyPromotionRequirementState
            {
                Met = false,
                Required = true
            };
        }

        public void SetState(PromotionRequirementStateBase state)
        {
            _state = (DummyPromotionRequirementState)state;
        }

        #endregion
    }
}
