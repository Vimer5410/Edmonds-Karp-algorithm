namespace Edmonds_Karp_algorithm.Controllers;

public class EdmondsKarpCore
{
    private int[,] _matrix;
    private int _nodeCount;

    public EdmondsKarpCore(int[,] inputMatrix)
    {
        _matrix = inputMatrix;
        _nodeCount = inputMatrix.GetLength(0); // кол-во вершин
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
                       
                        return true;
                    }
                    
                    queue.Enqueue(v);
                    
                }
            }
        }
        return false;
    }
}