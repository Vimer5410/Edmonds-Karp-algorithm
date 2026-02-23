namespace Edmonds_Karp_algorithm.Models;

public class JsonViewModel
{
    
}

public class GraphRequest
{
    public int source { get; set; }
    public int sink { get; set; }
    public int nodeCount { get; set; }
    public List<EdgeTo> edges { get; set; }
}

public class EdgeTo
{
    public int from { get; set; }
    public int to { get; set; }
    public int capacity { get; set; }
}