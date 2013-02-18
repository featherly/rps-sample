using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    /// <summary>
    ///This is a test class for StorageTest and is intended
    ///to contain all StorageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StorageTest
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
        public void ConvertToHistoryEnumListHandleEmptyList()
        {
            //initialize
            Storage target = new Storage();
            string asString = string.Empty;
            List<OutcomeEnum> expected = null;
            List<OutcomeEnum> actual;

            //setup
            actual = target.ConvertToHistoryEnumList(asString);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary></summary>
        [TestMethod()]
        public void ConvertToHistoryEnumListHandleValidList()
        {
            //initialize
            Storage target = new Storage();
            string asString = "Rr";
            List<OutcomeEnum> expected = new List<OutcomeEnum>() { OutcomeEnum.WinWithRock, OutcomeEnum.LoseWithRock };
            List<OutcomeEnum> actual;

            //setup
            actual = target.ConvertToHistoryEnumList(asString);

            //assert
            for (int index = 0; index < Math.Min(expected.Count, actual.Count); index++)
            {
                Assert.AreEqual(expected[index], actual[index]);
            }
        }

        /// <summary></summary>
        [TestMethod()]
        [DeploymentItem("Assembly-CSharp.dll")]
        public void getHistoryCharRepresentationTest()
        {
            //initialize
            Storage_Accessor target = new Storage_Accessor();
            OutcomeEnum outcome = OutcomeEnum.WinWithRock;
            char expected = 'R';
            char actual;

            //setup
            actual = target.getHistoryCharRepresentation(outcome);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary></summary>
        [TestMethod()]
        [DeploymentItem("Assembly-CSharp.dll")]
        public void getHistoryEnumRepresentationTest()
        {
            //initialize
            Storage_Accessor target = new Storage_Accessor();
            char outcome = 'R';
            OutcomeEnum expected = OutcomeEnum.WinWithRock;
            OutcomeEnum actual;

            //setup
            actual = target.getHistoryEnumRepresentation(outcome);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}