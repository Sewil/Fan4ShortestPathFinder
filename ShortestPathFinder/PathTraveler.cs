using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeTransportationLimited.Graphs
{/// <summary>
 /// Den här klassen innehåller algoritmen som traverserar grafen
 /// </summary>
    static class PathTraveler
    {
        /// <summary>
        /// Bredden först algoritm (BFS)
        /// </summary>
        public static string RunAlgorithm(Node startNode, Node endNode)
        {
            Queue<Node> nodeQueue = new Queue<Node>();

            startNode.DistanceFromStart = 0;

            nodeQueue.Enqueue(startNode);

            while (nodeQueue.Any())
            {
                var currentNode = nodeQueue.Dequeue();

                if (currentNode.Id == endNode.Id)
                {
                    var pathStack = new Stack<Node>();
                    Node temporaryNode = currentNode;
                    while (temporaryNode.PreviousNode != null)
                    {
                        pathStack.Push(temporaryNode);
                        temporaryNode = temporaryNode.PreviousNode;
                    }
                    pathStack.Push(startNode);

                    string pathString = string.Empty;
                    while (pathStack.Any())
                    {
                        var node = pathStack.Pop();
                        pathString += node.Id;

                        if (node.Id != endNode.Id)
                        {
                            pathString += ", ";
                        }
                    }

                    return pathString;
                }
                else
                {
                    foreach (var nodeNeighbour in currentNode.Neighbours)
                    {
                        if (!nodeNeighbour.IsVisited)
                        {
                            nodeNeighbour.DistanceFromStart = currentNode.DistanceFromStart + 1;
                            nodeNeighbour.PreviousNode = currentNode;
                            nodeQueue.Enqueue(nodeNeighbour);
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
