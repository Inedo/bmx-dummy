using System.ComponentModel;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.PromotionRequirements;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [PromotionRequirementsProperties(
        "Dummy Promotion Requirement", 
        "A promotion requirement that, depending on configuration, is always met or not met.")]
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

        public override bool IsRequired(PromotionContext context) => this.Required;
        public override bool IsMet(PromotionContext context) => this.Met;
        public override string ToString()
        {
            return
                (this.Required ? "" : "Not ") + "Required" +
                " and " +
                (this.Met ? "" : "Not ") + "Met";
        }
    }
}
