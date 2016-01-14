using System;
using System.Text.RegularExpressions;

namespace NodeTransportationLimited.Graphs.ShortestPathFinder
{
    /// <summary>
    /// Denna klass startar Shortest Path Finder-programmet.
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// Startar exekveringen av Shortest Path Finder-programmet. Metoden anropas
        /// från Application.Main() för att starta programmet, men den anropas även
        /// vid testning. 
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Provide graph data now.");

            int nodeLength = int.Parse(System.Console.ReadLine());
            Node[] nodes = new Node[nodeLength];

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node(i);
            }

            string connectionsLine = Console.ReadLine();
            if (!string.IsNullOrEmpty(connectionsLine))
            {
                string[] connectionsString = Regex.Split(connectionsLine, ", "); // "0 1, 1 2, 2 3"
                foreach (var connection in connectionsString)
                {
                    string[] nodeArray = connection.Split(' ');
                    Node nodeOne = nodes[int.Parse(nodeArray[0])];
                    Node nodeTwo = nodes[int.Parse(nodeArray[1])];

                    nodeOne.Neighbours.Add(nodeTwo);
                    nodeTwo.Neighbours.Add(nodeOne);
                }
            }

            string[] shortestPathString = Regex.Split(Console.ReadLine(), " "); // 0 4
            string output = PathTraveler.RunAlgorithm(nodes[int.Parse(shortestPathString[0])], nodes[int.Parse(shortestPathString[1])]);

            Console.WriteLine(output);            
        }

        /// <summary>
        /// Anropas när programmet startas.<br/><br/>
        /// </summary>
        /// <exclude/>
        public static void Main()
        {
            Run();
        }
    }
}
