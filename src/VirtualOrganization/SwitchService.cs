using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOrganization
{
    /// <summary>
    /// Join two network
    /// </summary>
    public class SwitchService
    {
        /// <summary>
        /// Path of A network
        /// </summary>
        private string _pathA = "";

        /// <summary>
        /// Message service to A network
        /// </summary>
        private IMessageService _messageServiceA;

        /// <summary>
        /// Path of B network
        /// </summary>
        private string _pathB = "";

        /// <summary>
        /// Message service to B network
        /// </summary>
        private IMessageService _messageServiceB;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pathA">Path of A network</param>
        /// <param name="pathB">Path of B nerwork</param>
        public SwitchService(string pathA, string pathB)
        {
            _pathA = pathA;
            _pathB = pathB;

            _messageServiceA = new MSMQService(_pathA);
            _messageServiceA.Publish += new AgentMessageEventHandler(_messageServiceA_Publish);
            _messageServiceB = new MSMQService(_pathB);
            _messageServiceB.Publish += new AgentMessageEventHandler(_messageServiceB_Publish);
        }

        /// <summary>
        /// Publish method from service A
        /// </summary>
        /// <param name="e">AgentMessageEventArgs</param>
        private void _messageServiceA_Publish(AgentMessageEventArgs e)
        {
            _messageServiceB.SendMessage(_pathB, e.AgentMessage);
        }

        /// <summary>
        /// Publish method from service B
        /// </summary>
        /// <param name="e">AgentMessageEventArgs</param>
        private void _messageServiceB_Publish(AgentMessageEventArgs e)
        {
            _messageServiceA.SendMessage(_pathA, e.AgentMessage);
        }
    }
}
