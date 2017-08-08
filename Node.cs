namespace AStarPathfinding
{
    public class Node
    {
        private Point position;
        private bool walkable;
        private Node[] neighbors;
        private Node parent;
        private float distanceFromStart;
        private float distaceToGoal;

        public Node(Point position, bool walkable)
        {
            this.position = position;
            this.walkable = walkable;
            distaceToGoal = float.MaxValue;
            distanceFromStart = float.MaxValue;
        }

        public Point Position
        {
            get
            {
                return position;
            }
        }

        public bool Walkable
        {
            get
            {
                return walkable;
            }
        }

        public Node[] Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }

        public Node Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public float DistanceFromStart
        {
            get
            {
                return distanceFromStart;
            }
            set
            {
                distanceFromStart = value;
            }
        }

        public float DistaceToGoal
        {
            get
            {
                return distaceToGoal;
            }
            set
            {
                distaceToGoal = value;
            }
        }
    }
}
