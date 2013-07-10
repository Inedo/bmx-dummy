using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.PromotionRequirements;
using Inedo.BuildMaster.Web;

namespace Inedo.BuildMasterExtensions.Dummy
{
    /// <summary>
    /// Editor for the dummy promotion requirement state.
    /// </summary>
    [CustomEditor(typeof(DummyPromotionRequirementStateEditor))]
    public sealed class DummyPromotionRequirementState : PromotionRequirementStateBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyPromotionRequirementState"/> class.
        /// </summary>
        public DummyPromotionRequirementState()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether the promotion requirement is currently required.
        /// </summary>
        [Persistent]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the promotion requirement is currently met.
        /// </summary>
        [Persistent]
        public bool Met { get; set; }

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
    }
}
