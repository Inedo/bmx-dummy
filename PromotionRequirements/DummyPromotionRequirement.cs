using System.ComponentModel;
using System.Threading.Tasks;
using Inedo.BuildMaster.Extensibility.PromotionRequirements;
using Inedo.Documentation;
using Inedo.Serialization;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [DisplayName("Dummy Promotion Requirement")]
    [Description("A promotion requirement that, depending on configuration, is always met or not met.")]
    public sealed class DummyPromotionRequirement : PromotionRequirementBase
    {
        [Persistent]
        [Category("Dummy Options")]
        [DisplayName("Is Required")]
        [Description("Specify whether this promotion requirement is required and/or met.")]
        public bool Required { get; set; }
        [Persistent]
        [Category("Dummy Options")]
        [DisplayName("Is Met")]
        public bool Met { get; set; }

        public override Task<PromotionRequirementStatus> GetStatusAsync(PromotionContext context) => Task.FromResult(this.GetStatus());
        public override RichDescription GetDescription()
        {
            return new RichDescription(
                "Always ",
                new Hilite(!this.Required ? "not applicable" : this.Met ? "met" : "not met")
            );
        }

        private PromotionRequirementStatus GetStatus()
        {
            if (!this.Required)
                return new PromotionRequirementStatus(PromotionRequirementState.NotApplicable, new RichDescription("Not required"));

            if (this.Met)
                return new PromotionRequirementStatus(PromotionRequirementState.Met, new RichDescription("Met"));
            else
                return new PromotionRequirementStatus(PromotionRequirementState.NotMet, new RichDescription("Not met"));
        }
    }
}
