﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        /// Tests that it returns the same node when start and end node is the same
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_OrdinaryGraphWithSameNodePath()
        {
            string output = TestUtilities.RunApp(
                "10",
                "",
                "1 1"
            );

            Assert.AreEqual(output, ActualOutput("1"));
        }

        /// <summary>
        /// Tests that it returns the same node when start and end node is the same and it has a connection to itself
        /// </summary>
        /// <exclude/>
        [TestMethod]
        public void Run_OrdinaryGraphWithSameNodePath2()
        {
            string output = TestUtilities.RunApp(
                "30",
                "2 2",
                "2 2"
            );

            Assert.AreEqual(output, ActualOutput("2"));
        }

        /// <summary>
        /// Tests that it can handle having multiple shortest paths and give one of them as a result
        /// </summary>
        [TestMethod]
        public void Run_OrdinaryGraphWithMultipleShortestPaths()
        {
            string connections = "0 1, 0 2, 2 3, 1 3";
            string[] connectionsArray = Regex.Split(connections, ", ");

            string output = TestUtilities.RunApp(
                "4",
                "0 1, 0 2, 2 3, 1 3",
                "0 3"
            );

            string[] path = Regex.Split(ShortestPathOutput(output), ", ");
          
            string compare = string.Empty;
            string compareReverse = string.Empty;

            bool isFound = false;

            for (int i = 0; i < path.Length - 1; i++)
            {
                compare = path[i] + " " + path[i + 1];
                compareReverse = path[i + 1] + " " + path[i];

                foreach (var pair in connectionsArray)
                {
                    if (compare == pair || compareReverse == pair)
                    {
                        isFound = true;
                    }
                }

                if (!isFound)
                {
                    Assert.Fail(" 1 ");
                }

                isFound = false;
            }


            if (path.Length != 3)
            {
                Assert.Fail(" 2 ");
            }

            Assert.IsTrue(path.Length == 3 && path[0] == "0" && path[path.Length - 1] == "3");

        }

        /// <exclude />
        [TestMethod]
        public void RUN_NoConnection()
        {
            string connections = "0 1, 0 2, 2 3, 1 3";
            string[] connectionsArray = Regex.Split(connections, ", ");

            string output = TestUtilities.RunApp(
                "10",
                "0 1, 0 2, 2 3, 1 3",
                "0 7"
            );

            Assert.AreEqual(output, ActualOutput(""));


        }

        /// <exclude />
        public string ShortestPathOutput(string fullOutput)
        {
            return Regex.Split(fullOutput.Substring(readyStr.Length),"\r\n")[1];
        }

        /// <exclude />
        public string ActualOutput(string output)
        {
            return readyStr + newLine + output + newLine;
        }
    }
}
