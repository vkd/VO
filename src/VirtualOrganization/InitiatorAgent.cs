
namespace VirtualOrganization
{
    /// <summary>
    /// Initiator agent
    /// </summary>
    public class InitiatorAgent : AgentBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="agentName">Name of this agent</param>
        /// <param name="nearAgents">Array of the near agents</param>
        public InitiatorAgent(string agentName, string[] nearAgents = null)
            : base(agentName, nearAgents)
        {

        }

        /// <summary>
        /// Send ACCEPT message
        /// </summary>
        /// <param name="agentName">Name of agent</param>
        public void AcceptMessage(string agentName, string task)
        {
            _routingService.Publish(agentName, "Принято: " + task);
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="text">Text</param>
        public void CreateTask(string subject, string text)
        {
            _routingService.Publish(subject, text);
        }
    }
}
