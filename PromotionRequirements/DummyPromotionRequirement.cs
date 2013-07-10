using System;
using System.Collections.Generic;
using System.Text;
using Inedo.BuildMaster.Extensibility.PromotionRequirements;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Web;

namespace Inedo.BuildMasterExtensions.Dummy
{
    /// <summary>
    /// A promotion requirement that, depending on configuration, is always met or not met.
    /// </summary>
    [PromotionRequirementsProperties(
        "Dummy Promotion Requirement", 
        "A promotion requirement that, depending on configuration, is always met or not met.")]
    [CustomEditor(typeof(DummyPromotionRequirementEditor))]
    public sealed class DummyPromotionRequirement : PromotionRequirementBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyPromotionRequirement"/> class.
        /// </summary>
        public DummyPromotionRequirement()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return 
                (Required ? "" : "Not ") + "Required" +
                " and " +
                (Met ? "" : "Not ") + "Met";
        }

        /// <summary>
        /// Gets or sets a value indicating whether this promotion requirement is required.
        /// </summary>
        [Persistent]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this promotion requirement is met.
        /// </summary>
        [Persistent]
        public bool Met { get; set; }

        /// <summary>
        /// Determines whether this is required to be met in order to promote
        /// </summary>
        /// <param name="context">context of the promotion to test</param>
        /// <returns></returns>
        public override bool IsRequired(PromotionContext context)
        {
            return Required;
        }

        /// <summary>
        /// Determines whether this has been met
        /// </summary>
        /// <param name="context">context of the promotion</param>
        /// <returns></returns>
        public override bool IsMet(PromotionContext context)
        {
            return Met;
        }
    }
}
