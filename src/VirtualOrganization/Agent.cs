using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOrganization
{
    public class Agent
    {
        RoutingService _routingService;

        public event AgentMessageEventHandler ReceiveMessage;

        public Agent(string agentName, string[] nearAgents = null)
        {
            AgentName = agentName;
            _routingService = new RoutingService(AgentName, nearAgents);

            _routingService.ReceiveMessageEvent += new AgentMessageEventHandler(RoutingService_ReceiveMessageEvent);
        }

        void RoutingService_ReceiveMessageEvent(AgentMessageEventArgs e)
        {
            ReceiveMessage(new AgentMessageEventArgs(e.AgentMessage));
        }

        public void AddNearAgent(string nearAgent)
        {
            _routingService.AddNearAgent(nearAgent);
        }

        public void Publish(string subject, string text)
        {
            _routingService.Publish(subject, text);
        }

        public void Subscribe(string subject)
        {
            _routingService.Subscribe(subject);
        }

        public void Unsubscribe(string subject)
        {
            _routingService.Unsubscribe(subject);
        }

        public List<string> GetRoutingList()
        {
            return _routingService.GetRouting();
        }

        public List<string> GetNearAgents()
        {
            return _routingService.GetNearAgents();
        }

        public List<string> GetSubscribed()
        {
            return _routingService.GetSubscribed();
        }

        public string AgentName { get; private set; }
    }
}
