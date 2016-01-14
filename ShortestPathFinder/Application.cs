// VARNING: NI FÅR INTE GÖRA NÅGRA ÄNDRINGAR TILL DENNA FIL FÖRRUTOM DE DELAR
// DÄR DET EXPLICIT STÅR ATT NI FÅR MODIFIERA.

// SPECIELLT FÅR NI *INTE* ÄNDRA NAMNRYMDEN (eng. namespace) ELLER KLASSENS
// HUVUDDEFINITION. 

// OM NI GÖR OTILLÅTNA ÄNDRINGAR TILL DENNA FIL SÅ BLIR NI OMGÅENDE UNDERKÄNDA
// I KURSENS PROJEKT.

// Skapa nya klasser i denna Visual Studio-projekt som heter ShortestPathFinder
// och anropa sedan de klassernas metoder från metoden Application.Run() som
// finns i denna fil.

using System;
using System.Text.RegularExpressions;

namespace NodeTransportationLimited.Graphs.ShortestPathFinder
{
    /// <summary>
    /// Denna klass startar Shortest Path Finder-programmet. <b>VARNING: Inga
    /// ändringar får göras till denna klass förrutom där det anges att det är
    /// tillåtet i dokumentationen.</b>
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// Startar exekveringen av Shortest Path Finder-programmet. Metoden anropas
        /// från Application.Main() för att starta programmet, men den anropas även
        /// vid testning. Då projektet överlämnas till Lernia Consulting AB så ger
        /// metoden korrekt utdata för endast två testfall. Detta är enbart för
        /// ett demonstrationssyfte och ska tas bort.<br/><br/>
        /// 
        /// <b>VARNING: Ändringar får göras i metodens <i>kropp</i>
        /// (eng. <i>body</i>) men i övrigt får metoden inte ändras.</b>
        /// </summary>
        public static void Run()
        {
            System.Console.WriteLine("Provide graph data now.");

            int nodeLength = int.Parse(System.Console.ReadLine());
            Node[] nodes = new Node[nodeLength];

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node(i);
            }
            
            string[] connectionsString = System.Text.RegularExpressions.Regex.Split(System.Console.ReadLine(), ", "); // "0 1, 1 2, 2 3"            

            foreach (var connection in connectionsString)
            {
                string[] nodeArray = connection.Split(' ');
                Node nodeOne = nodes[int.Parse(nodeArray[0])];
                Node nodeTwo = nodes[int.Parse(nodeArray[1])];

                nodeOne.Neighbours.Add(nodeTwo);
                nodeTwo.Neighbours.Add(nodeOne);

                
            }

            string[] shortestPathString = Regex.Split(Console.ReadLine(), " "); // 0 4
            //Path shortestPath = PathTraveler.RunAlgorithm(nodes[int.Parse(shortestPathString[0])], nodes[int.Parse(shortestPathString[1])]);
            //string output = string.Empty;

            //for (int i = 0; i < shortestPath.listOfPath.Count; i++)
            //{
            //    var connection = shortestPath.listOfPath[i];
            //    output += connection.Node1.Id;

            //    if (i < shortestPath.listOfPath.Count - 1)
            //    {
            //        output += ", ";
            //    }
            //}

            //Console.WriteLine(output);

            // Ni får *inte* göra några fler ändringar efter denna linje utanför denna
            // metods kropp.
        }

        /// <summary>
        /// Anropas när programmet startas.<br/><br/>
        /// 
        /// <b>VARNING: Denna metod får inte ändrans på något sätt.</b>
        /// </summary>
        /// <exclude/>
        public static void Main()
        {
            Run();
        }
    }
}
