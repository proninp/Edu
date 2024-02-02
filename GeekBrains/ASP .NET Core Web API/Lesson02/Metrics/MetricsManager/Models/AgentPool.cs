namespace MetricsManager.Models;

public class AgentPool
{
    private Dictionary<int, AgentInfo> _values;

    public AgentPool()
    {
        _values = new Dictionary<int, AgentInfo>();
    }

    public void Add(AgentInfo agentInfo)
    {
        if (!_values.ContainsKey(agentInfo.AgentId)) 
        { 
            _values.Add(agentInfo.AgentId, agentInfo);
        }
    }

    public AgentInfo[] Get() => _values.Values.ToArray();

    public Dictionary<int, AgentInfo> Values 
    {
        get { return _values; }
        set { _values = value; }
    }
}
