﻿using MetricsManager.Controllers;
using MetricsManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Priority;

namespace MetricsManagerTests;

public class AgetControllerUnitTests
{
    private AgentsController _agentsController;
    private AgentPool _agentPool;

    public AgetControllerUnitTests()
    {
        _agentPool = LazyAgentPool.Instance;
        _agentsController = new AgentsController(_agentPool);
    }

    
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    [Priority(1)]
    public void RegisterAgentTest(int agentId)
    {
        AgentInfo agentInfo = new AgentInfo() { AgentId = agentId, Enable = true };
        IActionResult actionResult = _agentsController.RegisterAgent(agentInfo);
        Assert.IsAssignableFrom<ActionResult>(actionResult);
    }

    [Fact]
    [Priority(2)]
    public void GetAgentsTest()
    {
        IActionResult actionResult = _agentsController.GetAllAgents();
        OkObjectResult result = Assert.IsAssignableFrom<OkObjectResult>(actionResult);
        Assert.NotNull(result.Value as IEnumerable<AgentInfo>);
        Assert.NotEmpty((IEnumerable<AgentInfo>)result.Value);
    }
}
