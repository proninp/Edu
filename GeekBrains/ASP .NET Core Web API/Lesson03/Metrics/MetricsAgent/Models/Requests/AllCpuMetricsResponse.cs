using System.Net;

namespace MetricsAgent.Models.Requests;

public class AllCpuMetricsResponse
{
    public List<CpuMetric> Metrics { get; set; }
}
