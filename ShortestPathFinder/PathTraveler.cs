using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeTransportationLimited.Graphs
{
	static class PathTraveler
	{
		//get nr of Nodes, do something!
		//get endNode, save
		//get edges, add to Stack<Connection>

		//go to startNode

		//add startNode to queue, call it currentNode

		//LINE 1: is currentNode endNode?
		//if no
		//visit node2 (other end of edge) (Check if currentNode has edges, go to node2). do while(currentNode has edges)
		//go back to currentNode
		//is node2 endNode? If no -> add node2 to queue, mark node1 as previous node
		//repeat for all node2. 

		//node1 becomes currentNode
		//repeat from line 1. 

		//is currentNode EndNode?
		//if yes
		//add node2 to stack
		//get previous node
		//previous node becomes currentNode
		//add nameOfNode to string
		//repeat until startNode

		//how do we know that this is the shortest? 
		
		public static void RunAlgorithm(Node s, Node endNode)
		{
			Queue<Node> nodeQueue = new Queue<Node>();
			
			s.DistanceFromStart = 0;
			s.PreviuosNode = s;

			nodeQueue.Enqueue(s);
			
			while (nodeQueue.Any())
			{
				var v = nodeQueue.Dequeue();

                if (v.Id == endNode.Id)
                {


                    return; 
                }

				foreach (var w in v.Neighbours)
				{
					if (!w.IsVisited)
					{
						w.DistanceFromStart = v.DistanceFromStart + 1;
						w.PreviuosNode = v;
						nodeQueue.Enqueue(w);
						Console.WriteLine("Found node" + w.Id + ". With distance " + w.DistanceFromStart + " added to queue");
					}
				}
			}

			//return null;
		}
	}
}
