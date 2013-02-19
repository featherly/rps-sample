using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    /// <summary>
    ///This is a test class for RefereeTest and is intended
    ///to contain all RefereeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RefereeTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary></summary>
        [TestMethod()]
        [DeploymentItem("Assembly-CSharp.dll")]
        public void GetGameOutcomeTestWin()
        {
            //initialize
            Referee target = new Referee();
            RpsEnum player = RpsEnum.Rock;
            RpsEnum ai = RpsEnum.Scissors;
            OutcomeEnum expected = OutcomeEnum.WinWithRock;
            OutcomeEnum actual;

            //setup
            actual = target.GetGameOutcome(player, ai);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary></summary>
        [TestMethod()]
        [DeploymentItem("Assembly-CSharp.dll")]
        public void GetGameOutcomeTestTie()
        {
            //initialize
            Referee target = new Referee();
            RpsEnum player = RpsEnum.Rock;
            RpsEnum ai = RpsEnum.Rock;
            OutcomeEnum expected = OutcomeEnum.TieWithRock;
            OutcomeEnum actual;

            //setup
            actual = target.GetGameOutcome(player, ai);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary></summary>
        [TestMethod()]
        [DeploymentItem("Assembly-CSharp.dll")]
        public void HandleOutcomeTestWinNoHistory()
        {
            //initialize
            Referee target = new Referee() { IsTest = true };
            OutcomeEnum outcomeOfRound = OutcomeEnum.WinWithRock;
            List<OutcomeEnum> gameOutcomes = null;
            string expectedGameHistoryUpdate = "R";
            string actualGameHistoryUpdate;
            string expected = System.Environment.NewLine + "You " + Referee_Accessor.won;
            string actual;

            //setup
            actual = target.HandleOutcome(outcomeOfRound, ref gameOutcomes, out actualGameHistoryUpdate);

            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedGameHistoryUpdate, actualGameHistoryUpdate);
        }

        /// <summary></summary>
        [TestMethod()]
        [DeploymentItem("Assembly-CSharp.dll")]
        public void HandleOutcomeTestWinWithHistory()
        {
            //initialize
            Referee target = new Referee() { IsTest = true };
            OutcomeEnum outcomeOfRound = OutcomeEnum.WinWithRock;
            List<OutcomeEnum> gameOutcomes = new List<OutcomeEnum>();
            string expectedGameHistoryUpdate = "R";
            string actualGameHistoryUpdate;
            string expected = System.Environment.NewLine + "You " + Referee_Accessor.won;
            string actual;

            //setup
            actual = target.HandleOutcome(outcomeOfRound, ref gameOutcomes, out actualGameHistoryUpdate);

            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedGameHistoryUpdate, actualGameHistoryUpdate);
        }
    }
}