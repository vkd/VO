
namespace VirtualOrganization
{
    /// <summary>
    /// Buyer agent
    /// </summary>
    public class BuyerAgent : AgentBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="agentName">Name of this agent</param>
        /// <param name="nearAgents">Array of the near agents</param>
        public BuyerAgent(string agentName, string[] nearAgents = null)
            : base(agentName, nearAgents)
        {

        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="text">Text</param>
        public void CreateOrder(string subject, string text)
        {
            _routingService.Publish(subject, text);
        }
    }
}
