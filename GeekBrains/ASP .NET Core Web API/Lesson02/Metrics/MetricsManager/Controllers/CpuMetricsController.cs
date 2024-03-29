﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers;

[Route("api/metrics/cpu")]
[ApiController]
public class CpuMetricsController : ControllerBase
{
    [HttpGet("agent/{agentId}/cluster/from/{fromTime}/to/{toTime}")]
    public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
    {
        return Ok();
    }

    [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
    public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan  toTime) 
    {
        return Ok();
    }
}
