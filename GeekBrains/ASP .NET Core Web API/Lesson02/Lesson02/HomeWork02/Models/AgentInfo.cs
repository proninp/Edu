namespace HomeWork02.Models;

public class AgentInfo
{
    public int AgentId { get; set; }
    public Uri AgentAddress { get; set; }
    public bool Enable { get; set; }

    public AgentInfo(int agentId, Uri agentAddress, bool enable)
    {
        AgentId = agentId;
        AgentAddress = agentAddress;
        Enable = enable;
    }

}
