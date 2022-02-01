using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Graph
    {

        // No. of vertices    
        private int _V;

        //Adjacency Lists
        LinkedList<int>[] _adj;

        public Graph(int V)
        {
            _adj = new LinkedList<int>[V];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
            _V = V;
        }

        // Function to add an edge into the graph
        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);

        }

        // Prints BFS traversal from a given source s
        public void BFS(int s)
        {

            // Mark all the vertices as not visited
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();

            // Mark the current node as
            // visited and enqueue it
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Any())
            {

                // Dequeue a vertex from queue
                // and print it
                s = queue.First();
                Console.Write(s + " ");
                queue.Dequeue();

                // Get all adjacent vertices of the
                // dequeued vertex s. If a adjacent
                // has not been visited, then mark it
                // visited and enqueue it
                LinkedList<int> list = _adj[s];

                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.Enqueue(val);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Graph graph = new Graph(5);

                graph.AddEdge(0, 1);
                graph.AddEdge(0, 2);
                graph.AddEdge(2, 0);
                graph.AddEdge(2, 3);
                graph.AddEdge(3, 4);
                graph.AddEdge(5, 1);

                Console.Write("Following is Breadth First Traversal(starting from vertex 2)\n");
                graph.BFS(2);
            }
            // catch the error if the range is out of bounds
            // in adding vertices. the bound is 5 find in line 80
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentException(null, ex);
            }
        }
    }
}
