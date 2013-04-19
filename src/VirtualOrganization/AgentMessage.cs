
namespace VirtualOrganization
{
    /// <summary>
    /// Message
    /// </summary>
    public class AgentMessage
    {
        /// <summary>
        /// Sender agent
        /// </summary>
        public string SenderAgent { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Text message
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Type of message
        /// </summary>
        public MessageType MessageType { get; set; }
    }

    /// <summary>
    /// Type of message
    /// </summary>
    public enum MessageType
    {
        Message,
        Subscribe,
        Unsubscribe,
        Hello,
        Bye
    }
}
