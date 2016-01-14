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
		
		public static Path RunAlgorithm(Node startNode, Node endNode)
		{
            return null;
		}
	}
}
