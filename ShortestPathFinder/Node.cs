using System.Collections.Generic;

namespace NodeTransportationLimited.Graphs
{
    class Node
    {
		public Node(int id)
		{
			Id = id;
            DistanceFromStart = -1;
            Neighbours = new List<Node>();
		}

        public Node PreviuosNode { get; set; }
        public List<Node> Neighbours { get; set; }
        public int DistanceFromStart { get; set; }
        public int Id { get; set; }
        public bool IsVisited {
            get {
                return DistanceFromStart > -1;
            }
        }
    }
}
