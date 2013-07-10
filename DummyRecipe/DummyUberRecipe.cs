using Inedo.BuildMaster.Extensibility.Recipes;

namespace Inedo.BuildMasterExtensions.Dummy.DummyRecipe
{
    public sealed class DummyUberRecipe : RecipeBase,
        Inedo.BuildMaster.Extensibility.Recipes.IEnvironmentRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IServerRecipe,

        Inedo.BuildMaster.Extensibility.Recipes.IDeploymentPlanRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IActionGroupRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IActionRecipe,

        Inedo.BuildMaster.Extensibility.Recipes.IApplicationGroupRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IApplicationRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IReleaseRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IBuildRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IBuildPromotionRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IExecutionRecipe,

        Inedo.BuildMaster.Extensibility.Recipes.IWorkflowRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IWorkflowStepRecipe,

        Inedo.BuildMaster.Extensibility.Recipes.IChangeControlRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IConfigurationFileRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IDatabaseChangeScriptRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IDatabaseProviderRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IIssueTrackingProviderRecipe,
        Inedo.BuildMaster.Extensibility.Recipes.IScmRecipe
    {
        public override void Execute() { }

        public int EnvironmentId { get; set; }
        public int ServerId { get; set; }

        public int DeploymentPlanId { get; set; }
        public int ActionGroupId { get; set; }
        public int ActionSequence { get; set; }

        public int ApplicationGroupId { get; set; }
        public int ApplicationId { get; set; }
        public string ReleaseNumber { get; set; }
        public int BuildNumber { get; set; }
        public int ExecutionId { get; set; }

        public int WorkflowId { get; set; }
        public int StepSequence { get; set; }

        public int ChangeControlId { get; set; }
        public int ConfigurationFileId { get; set; }
        public int DatabaseChangeScriptId { get; set; }
        public int DatabaseProviderId { get; set; }
        public int IssueTrackingProviderId { get; set; }
        public string ScmPath { get; set; }
        public int ScmProviderId { get; set; }
    }
}

