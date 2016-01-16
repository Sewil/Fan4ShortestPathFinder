using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodeTransportationLimited.Testing;
using System.Text.RegularExpressions;

namespace NodeTransportationLimited.Graphs.ShortestPathFinder.Testing
{
    /// <exclude/>
    [TestClass]
    public class ApplicationTests
    {
        private static string newLine = System.Environment.NewLine;
        private static string readyStr = "Provide graph data now.";

        // Konstruktorn har lagts till bara för att kunna exkludera den från
        // projektets dokumentation. 
        /// <summary>
        /// 
        /// </summary>
        /// <exclude/>
        public ApplicationTests() { }

        /// <summary>
        /// Om en enhetstest använder StandardIORedirecter för att koppla om <i>standard
        /// input</i> och <i>output</i> så måste de återställas efteråt. Därför
        /// återställs dem av denna metod om så inte redan har skett.
        /// </summary>
        [TestCleanup]
        public void CleanUp()
        {
            if (StandardIORedirecter.IsReset() == false)
            {
                StandardIORedirecter.Reset();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_EightNodesOnALine_From0To7()
        {
            string output =
            TestUtilities.RunApp(
            "8",
            "0 1, 1 2, 2 3, 3 4, 4 5, 5 6, 6 7",
            "0 7"
            );

            Assert.AreEqual(
            output,
            readyStr +
            newLine +
            "0, 1, 2, 3, 4, 5, 6, 7" +
            newLine
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_OrdinaryGraphWithSixNodes_From0To4()
        {
            string output =
            TestUtilities.RunApp(
                "6",
                "0 1, 0 2, 1 2, 2 3, 2 4, 3 5",
                "0 4"
            );

            Assert.AreEqual(
                output,
                readyStr +
                newLine +
                "0, 2, 4" +
                newLine
            );
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_OneNode_From0To0()
        {
            string output = TestUtilities.RunApp(
                "1",
                "",
                "0 0"
            );

            Assert.AreEqual(output, ActualOutput("0"));
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_OneNodeSelfconnected_From0To0()
        {
            string output = TestUtilities.RunApp(
                "1",
                "0 0",
                "0 0"
            );

            Assert.AreEqual(output, ActualOutput("0"));
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_TwoNodes_From0To1()
        {
            string output = TestUtilities.RunApp(
                "2",
                "0 1",
                "0 1"
            );

            Assert.AreEqual(output, ActualOutput("0, 1"));
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_TwoNodesDisconnected_From0To1()
        {
            string output = TestUtilities.RunApp(
                "2",
                "",
                "0 1"
            );

            Assert.AreEqual(output, ActualOutput(""));
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_MultipleNodes_From1To5()
        {
            string output = TestUtilities.RunApp(
                "6",
                "0 1, 1 4, 4 5",
                "1 5"
            );

            Assert.AreEqual(output, ActualOutput("1, 4, 5"));
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_Interconnected_From3To0()
        {
            string output = TestUtilities.RunApp(
                "5",
                "0 0, 0 1, 0 2, 0 3, 0 4, 1 1, 1 2, 1 3, 1 4, 2 2, 2 3, 2 4, 3 3, 3 4, 4 4",
                "3 0"
            );

            Assert.AreEqual(output, ActualOutput("3, 0"));
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_Disconnected_From0To0()
        {
            string output = TestUtilities.RunApp(
                "420",
                "",
                "0 0"
            );

            Assert.AreEqual(output, ActualOutput("0"));
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_Selfconnected_From4To1()
        {
            string output = TestUtilities.RunApp(
                "420",
                "4 4, 4 2, 0 1, 1 3, 4 5, 3 2, 4 3",
                "4 1"
            );

            Assert.AreEqual(output, ActualOutput("4, 3, 1"));
        }

        /// <summary>
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_OnlySelfconnected_From4To1()
        {
            string output = TestUtilities.RunApp(
                "420",
                "4 4, 0 1, 1 3, 3 2",
                "4 1"
            );

            Assert.AreEqual(output, ActualOutput(""));
        }

        /// <summary></summary>
        /// <exclude/>
        [TestMethod]
        public void Run_OnlySelfconnected_From4To4()
        {
            string output = TestUtilities.RunApp(
                "420",
                "4 4, 0 1, 1 3, 3 2",
                "4 4"
            );

            Assert.AreEqual(output, ActualOutput("4"));
        }

        /// <summary></summary>
        /// <exclude/>
        [TestMethod]
        public void Run_DisconnectedStartNode_From4To1()
        {
            string output = TestUtilities.RunApp(
                "420",
                "0 1, 1 3, 3 2",
                "4 1"
            );

            Assert.AreEqual(output, ActualOutput(""));
        }

        /// <summary></summary>
        /// <exclude/>
        [TestMethod]
        public void Run_DisconnectedEndNode_From4To1()
        {
            string output = TestUtilities.RunApp(
                "420",
                "4 2, 4 5, 4 3, 3 2",
                "4 1"
            );

            Assert.AreEqual(output, ActualOutput(""));
        }

        /// <summary></summary>
        /// <exclude />
        [TestMethod]
        public void Run_MissingShortestPath_From0To7()
        {
            string output = TestUtilities.RunApp(
                "10",
                "0 1, 0 2, 2 3, 1 3",
                "0 7"
            );

            Assert.AreEqual(output, ActualOutput(""));
        }

        /// <summary></summary>
        /// <exclude/>
        [TestMethod]
        public void Run_MultipleSelfConnected_From4To1()
        {
            string output = TestUtilities.RunApp(
                "420",
                "4 2, 4 5, 4 3, 3 2, 1 0, 1 3, 1 1, 3 3, 2 2, 5 5",
                "4 1"
            );

            Assert.AreEqual(output, ActualOutput("4, 3, 1"));
        }

        /// <summary></summary>
        /// <exclude/>
        [TestMethod]
        public void Run_StartEndDirectlyConnected_From3To1()
        {
            string output = TestUtilities.RunApp(
                "420",
                "4 2, 4 5, 4 3, 3 2, 1 0, 1 3, 1 1, 3 3, 2 2, 5 5",
                "3 1"
            );

            Assert.AreEqual(output, ActualOutput("3, 1"));
        }

        /// <summary></summary>
        /// <exclude/>
        [TestMethod]
        public void Run_RandomGraph_From0To10()
        {
            string output = TestUtilities.RunApp(
                "12",
                "0 0, 0 1, 1 4, 4 5, 2 4, 5 10, 2 6, 8 6, 6 10, 10 11, 9 6, 8 10, 8 7, 0 11, 11 3, 11 7, 1 6, 0 9, 7 9",
                "0 10"
            );

            Assert.AreEqual(output, ActualOutput("0, 11, 10"));
        }

        /// <summary></summary>
        /// <exclude/>
        [TestMethod]
        public void Run_MultipleShortestPaths_From0To3()
        {
            string connections = "0 1, 0 2, 2 3, 1 3";
            string output = TestUtilities.RunApp(
                "4",
                connections,
                "0 3"
            );

            string[] path = Regex.Split(ShortestPathOutput(output), ", ");
            Assert.IsTrue(IsOneOfMultipleShortestPaths(path, connections, 3, "0", "3"));
        }

        /// <exclude />
        public bool IsOneOfMultipleShortestPaths(string[] calculatedPath, string connections, int shortestPathLength, string startNode, string endNode)
        {
            bool valid = calculatedPath.Length == shortestPathLength && calculatedPath[0] == startNode && calculatedPath[calculatedPath.Length - 1] == endNode;

            string compare = string.Empty;
            string compareReverse = string.Empty;
            string[] connectionsArray = Regex.Split(connections, ", ");
            for (int i = 0; i < calculatedPath.Length - 1; i++)
            { // går igenom alla kanter i den kortaste stigen och försäkrar sig om att kanterna faktiskt finns i grafen
                compare = calculatedPath[i] + " " + calculatedPath[i + 1];
                compareReverse = calculatedPath[i + 1] + " " + calculatedPath[i];

                bool found = false;
                foreach (var pair in connectionsArray)
                {
                    if (compare == pair || compareReverse == pair)
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }

        /// <exclude />
        public string ShortestPathOutput(string fullOutput)
        {
            return Regex.Split(fullOutput.Substring(readyStr.Length), "\r\n")[1];
        }

        /// <exclude />
        public string ActualOutput(string output)
        {
            return readyStr + newLine + output + newLine;
        }
    }
}
