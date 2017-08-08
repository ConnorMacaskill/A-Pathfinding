using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarPathfinding
{
    public class Pathfinder
    {
        private Node[,] nodeMap;
        private List<Node> closedSet;
        private List<Node> openSet;
        private Node lastNode;
        private Node currentNode;

        int mapWidth;
        int mapHeight;

        public Pathfinder(bool[,] map)
        {
            closedSet = new List<Node>();
            openSet = new List<Node>();
            mapWidth = map.GetLength(0);
            mapHeight = map.GetLength(1);

            //Initialise the node map used for searching.
            InitialiseNodeMap(map);

        }

        /// <summary>
        /// Returns a list of nodes consisting of the best path from the start to the end node.
        /// </summary>
        /// <param name="map">Map represented as a 2d array of nodes.</param>
        /// <param name="start">The start point of the path.</param>
        /// <param name="end">The desired end point of the path.</param>
        public List<Node> FindPath(Point start, Point end)
        {
            //Only bother trying to find a path if the start point and end point are actually different.
            if(start == end)
            {
                return new List<Node>();
            }

            //Reset to clear leftovers from previous path finds.
            Reset();

            //Init
            //openSet.Add(start);

            return GetFinalPath();
        }


        private List<Node> GetFinalPath()
        {
            return null;
        }

        private void InitialiseNodeMap(bool[,] map)
        {
            //Initalise nodeMap equal to the size of the map we are finding a path on.
            nodeMap = new Node[mapWidth, mapHeight];

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    nodeMap[x, y] = new Node(new Point(x, y), map[x, y]);
                }
            }

            List<Node> neighbors = new List<Node>();

            //Connect each node in the nodemap to its neighboring nodes.
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    //Add Each adjacent and diagnol neighbor for each node, a total of 8. Ensure we avoid out of bound index exceptions at the edge cases.
                    for(int i = -1; i <= 1; i++)
                    {
                        for(int j = -1; j <= 1; j++)
                        {
                            int xCood = x + i;
                            int yCood = y + j;

                            if(xCood > -1 && xCood < mapWidth)
                            {
                                if (yCood > -1 && yCood < mapHeight)
                                {
                                    //A node cannot be its own neighbor.
                                    if (i != 0 || j != 0)
                                    {
                                        neighbors.Add(nodeMap[xCood, yCood]);
                                    }
                                }
                            }
                        }
                    }

                    nodeMap[x, y].Neighbors = neighbors.ToArray();
                    //Clear the list for the next node so we don't add old neighbors.
                    neighbors.Clear();
                }
            }
        }

        private void Reset()
        {
            closedSet.Clear();
            openSet.Clear();

            for (int x = 0; x < mapWidth; x++)
            {   
                for (int y = 0; y < mapHeight; y++)
                {
                    nodeMap[x, y].DistanceFromStart = float.MaxValue;
                    nodeMap[x, y].DistaceToGoal = float.MaxValue;
                }
            }
        }

        /// <summary>
        /// Returns an estimate of the distance between the start and end node.
        /// </summary>
        private float Heuristic(Node start, Node end)
        {
            float x = start.Position.X - end.Position.Y;
            float y = start.Position.Y - end.Position.Y;

            return Math.Abs(x + y);
        }
    }
}
