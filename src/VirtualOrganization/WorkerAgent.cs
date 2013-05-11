
namespace VirtualOrganization
{
    /// <summary>
    /// Worker agent
    /// </summary>
    public class WorkerAgent : AgentBase
    {
        /// <summary>
        /// Cost this worker
        /// </summary>
        private int _cost;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="agentName">Name of this agent</param>
        /// <param name="nearAgents">Array of the near agents</param>
        public WorkerAgent(string agentName, int cost, string[] nearAgents = null)
            : base(agentName, nearAgents)
        {
            _cost = cost;
        }

        /// <summary>
        /// Send ACCEPT message
        /// </summary>
        /// <param name="agentName">Name of agent</param>
        public void AcceptMessage(string agentName, string task)
        {
            _routingService.Publish(agentName, "Принято [" + task + "]: " + _cost);
        }
    }
}
