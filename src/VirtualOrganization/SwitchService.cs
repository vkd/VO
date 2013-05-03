using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOrganization
{
    public class SwitchService
    {
        private string _pathA = "";
        private IMessageService _messageServiceA;

        private string _pathB = "";
        private IMessageService _messageServiceB;

        public SwitchService(string pathA, string pathB)
        {
            _pathA = pathA;
            _pathB = pathB;

            _messageServiceA = new MSMQService(_pathA);
            _messageServiceA.Publish += new AgentMessageEventHandler(_messageServiceA_Publish);
            _messageServiceB = new MSMQService(_pathB);
            _messageServiceB.Publish += new AgentMessageEventHandler(_messageServiceB_Publish);
        }

        void _messageServiceA_Publish(AgentMessageEventArgs e)
        {
            _messageServiceB.SendMessage(_pathB, e.AgentMessage);
        }

        void _messageServiceB_Publish(AgentMessageEventArgs e)
        {
            _messageServiceA.SendMessage(_pathA, e.AgentMessage);
        }
    }
}
