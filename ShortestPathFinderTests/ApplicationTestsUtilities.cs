using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShortestPathFinderTests
{
    static class ApplicationTestsUtilities
    {
        public static string ShortestPathOutput(string readyStr,string fullOutput)
        {
            return Regex.Split(fullOutput.Substring(readyStr.Length), "\r\n")[1];
        }

        public static string ActualOutput(string readyStr, string output)
        {
            return readyStr + Environment.NewLine + output + Environment.NewLine;
        }

        public static bool IsOneOfMultipleShortestPaths(string[] calculatedPath, string connections, int shortestPathLength, string startNode, string endNode)
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
    }
}
