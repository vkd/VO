using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOrganization
{
    public class Agent
    {
        RoutingService _routingService;

        public Agent(string agentName, string[] nearAgents = null)
        {
            AgentName = agentName;
            _routingService = new RoutingService(AgentName, nearAgents);

            _routingService.ReceiveMessageEvent += new AgentMessageEventHandler(RoutingService_ReceiveMessageEvent);
        }

        void RoutingService_ReceiveMessageEvent(AgentMessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void AddNearAgent(string nearAgent)
        {
            _routingService.AddNearAgent(nearAgent);
        }

        public string AgentName { get; private set; }
    }
}
