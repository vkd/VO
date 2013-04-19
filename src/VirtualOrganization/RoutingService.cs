using System.Collections.Generic;

namespace VirtualOrganization
{
    public class RoutingService
    {
        private IMessageService _messageService;

        private Dictionary<string, List<string>> _routingTable = new Dictionary<string, List<string>>();
        private List<string> _subscribed = new List<string>();
        private List<string> _nearAgents = new List<string>();

        public event AgentMessageEventHandler ReceiveMessageEvent;

        public RoutingService(string agentName, string[] nearAgents = null)
        {
            AgentName = agentName;

            if (nearAgents != null)
            {
                foreach (var nearAgent in nearAgents)
                {
                    _nearAgents.Add(nearAgent);
                }
            }

            _messageService = new MSMQService(AgentName);
            _messageService.Publish += new AgentMessageEventHandler(MessageService_Publish);

        }

        public void AddNearAgent(string nearAgent)
        {
            _nearAgents.Add(nearAgent);

            AgentMessage msg = new AgentMessage()
            {
                MessageType = MessageType.Hello,
                SenderAgent = AgentName
            };
            _messageService.SendMessage(nearAgent, msg);
        }

        public void RemoveNearAgent(string nearAgent)
        {
            _nearAgents.Remove(nearAgent);

            AgentMessage msg = new AgentMessage()
            {
                MessageType = MessageType.Bye,
                SenderAgent = AgentName
            };
            _messageService.SendMessage(nearAgent, msg);

            List<string> removeKeys = new List<string>();
            foreach (var route in _routingTable)
            {
                route.Value.Remove(nearAgent);
                if (route.Value.Count == 0)
                    removeKeys.Add(route.Key);
            }

            foreach (var key in removeKeys)
            {
                _routingTable.Remove(key);
            }
        }

        public void Publish(string subject, string text)
        {
            AgentMessage msg = new AgentMessage()
            {
                MessageType = MessageType.Message,
                SenderAgent = AgentName,
                Subject = subject,
                Text = text
            };

            SendMessageIntoRouteTable(msg);
        }

        public void Subscribe(string subject)
        {
            AgentMessage msg = new AgentMessage()
            {
                MessageType = MessageType.Subscribe,
                SenderAgent = AgentName,
                Subject = subject
            };

            SendMessageToNearAgents(msg);
        }

        public void Unsubscribe(string subject)
        {
            AgentMessage msg = new AgentMessage()
            {
                MessageType = MessageType.Unsubscribe,
                SenderAgent = AgentName,
                Subject = subject
            };

            SendMessageToNearAgents(msg);
        }

        public List<string> GetRouting()
        {
            List<string> outList = new List<string>();

            foreach (var route in _routingTable)
            {
                string line = route.Key + ":";
                foreach (var agent in route.Value)
                {
                    line += " " + agent;
                }
                outList.Add(line);
            }

            return outList;
        }

        public List<string> GetNearAgents()
        {
            return _nearAgents;
        }

        public List<string> GetSubscribed()
        {
            return _subscribed;
        }

        private void AddRoute(string agentName, string subject)
        {
            List<string> outList;
            if (_routingTable.TryGetValue(subject, out outList))
            {
                outList.Add(agentName);
            }
            else
            {
                List<string> newList = new List<string>();
                newList.Add(agentName);
                _routingTable.Add(subject, newList);
            }
        }

        private void RemoveRoute(string agentName, string subject)
        {
            List<string> outList;
            if (_routingTable.TryGetValue(subject, out outList))
            {
                outList.Remove(subject);

                if (outList.Count <= 0)
                {
                    _routingTable.Remove(subject);
                }
            }
        }

        private void SendMessageIntoRouteTable(AgentMessage message)
        {
            List<string> outList;
            if (_routingTable.TryGetValue(message.Subject, out outList))
            {
                foreach (var agent in outList)
                {
                    if (agent != message.SenderAgent)
                        _messageService.SendMessage(agent, message);
                }
            }
        }

        private void SendMessageToNearAgents(AgentMessage message)
        {
            foreach (var agent in _nearAgents)
            {
                if (agent != message.SenderAgent)
                    _messageService.SendMessage(agent, message);
            }
        }

        private void MessageService_Publish(AgentMessageEventArgs e)
        {
            ReceiveMessage(e.AgentMessage);
        }

        private void ReceiveMessage(AgentMessage message)
        {
            ReceiveMessageEvent(new AgentMessageEventArgs(message));

            switch (message.MessageType)
            {
                case MessageType.Message:
                    SendMessageIntoRouteTable(message);
                    break;
                case MessageType.Subscribe:
                    AddRoute(message.SenderAgent, message.Subject);
                    SendMessageToNearAgents(message);
                    break;
                case MessageType.Unsubscribe:
                    RemoveRoute(message.SenderAgent, message.Subject);
                    SendMessageToNearAgents(message);
                    break;
            }
        }

        public string AgentName { get; set; }
    }
}
