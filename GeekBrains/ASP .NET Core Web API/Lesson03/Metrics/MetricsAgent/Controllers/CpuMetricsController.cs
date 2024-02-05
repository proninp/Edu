using MetricsAgent.Models;
using MetricsAgent.Models.Requests;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;

namespace MetricsAgent.Controllers;

[Route("api/metrics/cpu")]
[ApiController]
public class CpuMetricsController : ControllerBase
{
    private ICpuMetricsRepository _cpuMetricsRepository;

    public CpuMetricsController(ICpuMetricsRepository cpuMetricsRepository)
    {
        _cpuMetricsRepository = cpuMetricsRepository;
    }

    [HttpGet("sql-test")]
    public IActionResult TryToSqlLite()
    {
        string cs = "Data Source=:memory:";
        string stm = "SELECT SQLITE_VERSION()";
        using var con = new SQLiteConnection(cs);
        con.Open();
        using var cmd = new SQLiteCommand(stm, con);
        string version = cmd.ExecuteScalar().ToString();
        return Ok(version);
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] CpuMetricCreateRequest request)
    {
        CpuMetric cpuMetric = new CpuMetric
        {
            Time = request.Time,
            Value = request.Value
        };

        _cpuMetricsRepository.Create(cpuMetric); //  Сохраняем в БД

        // TODO 1. Логирование параметров

        return Ok();
    }

    [HttpGet("all")]
    public IActionResult GetAll()
    {
        var metrics = _cpuMetricsRepository.GetAll();
        var response = new AllCpuMetricsResponse()
        {
            Metrics = new List<CpuMetric>()
        };
        foreach(var metric in metrics)
        {
            response.Metrics.Add(new CpuMetric
            {
                Time = metric.Time,
                Value = metric.Value,
                Id = metric.Id
            });
        }
        return Ok(response);
    }

    [HttpGet("agent/{agentId}/cluster/from/{fromTime}/to/{toTime}")]
    public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
    {
        return Ok();
    }

    [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
    public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
    {
        return Ok();
    }
}
