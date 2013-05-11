
namespace VirtualOrganization
{
    /// <summary>
    /// Interface of publish and receive service
    /// </summary>
    interface IMessageService
    {
        /// <summary>
        /// Send message to another agent
        /// </summary>
        /// <param name="receiverAgent">Receiver agent</param>
        /// <param name="message">Message</param>
        void SendMessage(string receiverAgent, AgentMessage message);

        /// <summary>
        /// Event of publish message
        /// </summary>
        event AgentMessageEventHandler Publish;
    }
}
