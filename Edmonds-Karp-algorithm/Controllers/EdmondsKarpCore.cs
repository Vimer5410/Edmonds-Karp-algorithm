using System.Runtime.Intrinsics;

namespace Edmonds_Karp_algorithm.Controllers;

public class EdmondsKarpCore
{
    private int[,] _matrix;
    private int _nodeCount;
    private int _maxFlow;
    private string _path;

    public EdmondsKarpCore(int[,] inputMatrix)
    {
        _matrix = inputMatrix;
        _nodeCount = inputMatrix.GetLength(0); // кол-во вершин
    }


    public int Calculate(int source, int sink)
    {
        
        
        int[] parents = new int[_nodeCount];
        while (BFS(source, sink, parents))
        {
            // ищем максимально возможный поток среди родителей(проматывая граф назад)
            int pathFlow =Int32.MaxValue;
            for (int v2 = sink; v2 !=source; v2=parents[v2])
            {
                // где v1 и v2 - ноды графа, v1 --> родительский
                int v1 = parents[v2];
                pathFlow = Math.Min(pathFlow, _matrix[v1, v2]);
                
            }

            for (int v2 = sink; v2 !=source; v2=parents[v2])
            {
                int v1 = parents[v2];
                _matrix[v1, v2] -= pathFlow;
                _matrix[v2, v1] += pathFlow;
                _path += v1;
            }

            _maxFlow += pathFlow;
        }
        return _maxFlow;
        
    }

    public string GetPath()
    {
        string newPath = new string(_path.Reverse().ToArray());
        return newPath;

    }
    private bool BFS(int source, int sink, int[] parents)
    {
        bool[] visited = new bool[_nodeCount];
        Queue<int> queue = new Queue<int>();
        
        queue.Enqueue(source);
        visited[source] = true;               // три базовейших операции над новой нодой
        parents[source] = -1;

        while (queue.Count>0)
        {
            var node = queue.Dequeue();

            for (int v = 0; v < _nodeCount; v++)
            {
                if (!visited[v]&& _matrix[node, v]>0)
                {
                    visited[v] = true;
                    parents[v] = node;
                    if (v==sink )
                    {
                        Console.WriteLine("Путь найден");
                        _path += "\n" + 5;
                        return true;
                    }
                    
                    queue.Enqueue(v);
                    
                }
            }
        }
        return false;
    }
}