using Edmonds_Karp_algorithm.Models;
using Microsoft.AspNetCore.Mvc;

namespace Edmonds_Karp_algorithm.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FlowController:ControllerBase
{
    [HttpPost("Calculate")]
    public IActionResult Calculate([FromBody] GraphRequest request)
    {
        int[,] matrix = new int[request.nodeCount, request.nodeCount];
        foreach (var e in request.edges)
        {
            matrix[e.from, e.to] = e.capacity;
        }

        var core = new EdmondsKarpCore(matrix);
        return Ok(new{MaxFlow=core.Calculate(request.source, request.sink)});
    }
}