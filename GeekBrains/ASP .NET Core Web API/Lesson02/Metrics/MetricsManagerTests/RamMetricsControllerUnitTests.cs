using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManagerTests;

public class NetworkMetricsControllerUnitTests
{
    private NetworkMetricsController _controller;

    public NetworkMetricsControllerUnitTests()
    {
        _controller = new NetworkMetricsController();
    }

    [Fact]
    public void GetMetricsFromAgent_ReturnsOk()
    {
        var agentId = 1;
        var fromTime = TimeSpan.FromSeconds(0);
        var toTime = TimeSpan.FromSeconds(100);

        var result = _controller.GetMetricsFromAgent(agentId, fromTime, toTime);

        Assert.IsAssignableFrom<IActionResult>(result);
    }

    [Fact]
    public void GetMetricsFromAllCluster_ReturnsOk()
    {
        var fromTime = TimeSpan.FromSeconds(0);
        var toTime = TimeSpan.FromSeconds(100);

        var result = _controller.GetMetricsFromAllCluster(fromTime, toTime);

        Assert.IsAssignableFrom<IActionResult>(result);
    }
}