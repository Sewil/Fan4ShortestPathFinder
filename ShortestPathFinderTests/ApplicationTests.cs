using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodeTransportationLimited.Testing;
using System.Text.RegularExpressions;

namespace NodeTransportationLimited.Graphs.ShortestPathFinder.Testing
{
    /// <summary>
    /// Denna klass är till för att visa hur enhetstester kan skrivas för att testa
    /// Shortest Path Finder-programmet. Klassen innehåller två enhetstester som
    /// lyckas om testerna körs när projektet överlämnas till
    /// <i>Lernia Consulting AB</i>. Detta beror på att programmet ger i nuläget
    /// korrekt utdata för just de två enhetstesterna.<br/><br/>
    /// 
    /// Klassen får utökas med fler enhetstester, och andra klasser innehållande 
    /// tester får också skapas.<br/><br/>
    /// 
    /// Observera att de två enhetstesterna använder sig av en metod för att köra
    /// programmet för de parametrar som önskas, och denna metod kan också användas
    /// fortsättningsvis.
    /// </summary>
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
            string output = TestUtilities.RunApp(
                "4",
                "0 1, 0 2, 2 3, 1 3",
                "0 3"
            );

            string[] nodes = Regex.Split(ShortestPathOutput(output), ", ");

            Assert.IsTrue(nodes.Length == 3 && nodes[0] == "0" && nodes[nodes.Length-1] == "3");
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
