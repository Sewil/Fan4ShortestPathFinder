using System.Collections.Generic;

namespace NodeTransportationLimited.Graphs
{
    class Node
    {
		public Node(int id)
		{
			Id = id;
            DistanceFromStart = -1;
		}

        public Node Path { get; set; }
        public List<Node> Neighbours { get; set; }
        public int DistanceFromStart { get; set; }
        public int Id { get; set; }
        public bool Visited {
            get {
                return DistanceFromStart > -1;
            }
        }
    }
}
