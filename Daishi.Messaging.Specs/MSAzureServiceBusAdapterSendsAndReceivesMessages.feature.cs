#region Includes

#endregion

#pragma warning disable

namespace Daishi.Messaging.Specs {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("MSAzureServiceBusAdapterSendsAndReceivesMessages")]
    public partial class MSAzureServiceBusAdapterSendsAndReceivesMessagesFeature {
        private static TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "MSAzureServiceBusAdapterSendsAndReceivesMessages.feature"
#line hidden

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup() {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            var featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "MSAzureServiceBusAdapterSendsAndReceivesMessages", "In order to send and receive messages\nAs an MSAzureServiceBusAdapter\nI want to se" +
                                                                                                                                                                   "nd and receive messages", ProgrammingLanguage.CSharp, ((string[]) (null)));
            testRunner.OnFeatureStart(featureInfo);
        }

        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown() {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }

        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize() {}

        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown() {
            testRunner.OnScenarioEnd();
        }

        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo) {
            testRunner.OnScenarioStart(scenarioInfo);
        }

        public virtual void ScenarioCleanup() {
            testRunner.CollectScenarioErrors();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send and receive messages")]
        public virtual void SendAndReceiveMessages() {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send and receive messages", ((string[]) (null)));
#line 6
            this.ScenarioSetup(scenarioInfo);
#line 7
            testRunner.Given("I have initialised an MSAzureServiceBusAdapter", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 8
            testRunner.When("I send a message", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 9
            testRunner.Then("I should be able to receive that message", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}

#pragma warning restore

#endregion