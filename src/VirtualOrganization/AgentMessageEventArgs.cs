using System;

namespace VirtualOrganization
{
    /// <summary>
    /// Delegate for agent message
    /// </summary>
    /// <param name="e">EventArgs</param>
    public delegate void AgentMessageEventHandler(AgentMessageEventArgs e);

    /// <summary>
    /// EventArgs for agent message
    /// </summary>
    public class AgentMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Message
        /// </summary>
        private AgentMessage _agentMessage;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="agentMessage">Message</param>
        public AgentMessageEventArgs(AgentMessage agentMessage)
        {
            AgentMessage = agentMessage;
        }

        /// <summary>
        /// Message
        /// </summary>
        public AgentMessage AgentMessage
        {
            get { return _agentMessage; }
            private set { _agentMessage = value; }
        }
    }
}
