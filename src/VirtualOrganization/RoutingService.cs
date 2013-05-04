using System.Collections.Generic;

namespace VirtualOrganization
{
    /// <summary>
    /// Routing service
    /// </summary>
    public class RoutingService
    {
        /// <summary>
        /// Message service
        /// </summary>
        private IMessageService _messageService;

        /// <summary>
        /// Routing table
        /// </summary>
        private Dictionary<string, List<string>> _routingTable = new Dictionary<string, List<string>>();

        /// <summary>
        /// List of subscried
        /// </summary>
        private List<string> _subscribed = new List<string>();

        /// <summary>
        /// List of near agents
        /// </summary>
        private List<string> _nearAgents = new List<string>();

        /// <summary>
        /// Event of receive message
        /// </summary>
        public event AgentMessageEventHandler ReceiveMessageEvent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="agentName">Name of this agent</param>
        /// <param name="nearAgents">Array of near agents</param>
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

        /// <summary>
        /// Add near agent
        /// </summary>
        /// <param name="nearAgent">Name of the near agent</param>
        public void AddNearAgent(string nearAgent)
        {
            if (!_nearAgents.Exists(a => a == nearAgent))
            {
                _nearAgents.Add(nearAgent);

                AgentMessage msg = new AgentMessage()
                {
                    MessageType = MessageType.Hello,
                    SenderAgent = AgentName
                };
                _messageService.SendMessage(nearAgent, msg);

                SubscribeAll(nearAgent);
            }
        }

        /// <summary>
        /// Remove near agent
        /// </summary>
        /// <param name="nearAgent">Name of the near agent</param>
        public void RemoveNearAgent(string nearAgent)
        {
            if (_nearAgents.Exists(a => a == nearAgent))
            {
                _nearAgents.Remove(nearAgent);

                AgentMessage msg = new AgentMessage()
                {
                    MessageType = MessageType.Bye,
                    SenderAgent = AgentName
                };
                _messageService.SendMessage(nearAgent, msg);

                RemoveAgentFromRoutingTable(nearAgent);
            }
        }

        /// <summary>
        /// Publish
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="text">Text</param>
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

        /// <summary>
        /// Subscribe
        /// </summary>
        /// <param name="subject">Subject</param>
        public void Subscribe(string subject)
        {
            if (!_subscribed.Exists(s => s == subject))
            {
                _subscribed.Add(subject);

                AgentMessage msg = new AgentMessage()
                {
                    MessageType = MessageType.Subscribe,
                    SenderAgent = AgentName,
                    Subject = subject
                };

                SendMessageToNearAgents(msg);
            }
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <param name="subject">Subject</param>
        public void Unsubscribe(string subject)
        {
            if (_subscribed.Exists(s => s == subject))
            {
                _subscribed.Remove(subject);

                AgentMessage msg = new AgentMessage()
                {
                    MessageType = MessageType.Unsubscribe,
                    SenderAgent = AgentName,
                    Subject = subject
                };

                SendMessageToNearAgents(msg);
            }
        }

        /// <summary>
        /// Get routing table
        /// </summary>
        /// <returns>List of the routing table</returns>
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

        /// <summary>
        /// Get near agents
        /// </summary>
        /// <returns>List of near agents</returns>
        public List<string> GetNearAgents()
        {
            return _nearAgents;
        }

        /// <summary>
        /// Get subscribed
        /// </summary>
        /// <returns>List of subscribed</returns>
        public List<string> GetSubscribed()
        {
            return _subscribed;
        }

        /// <summary>
        /// Remove the agent from the routing table
        /// </summary>
        /// <param name="nearAgent">Name of the near agent</param>
        private void RemoveAgentFromRoutingTable(string nearAgent)
        {
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

        /// <summary>
        /// Add route in routing table
        /// </summary>
        /// <param name="agentName">Name of the agent</param>
        /// <param name="subject">Subject</param>
        private void AddRoute(string agentName, string subject)
        {
            List<string> outList;
            if (_routingTable.TryGetValue(subject, out outList))
            {
                if (!outList.Exists(r => r == agentName))
                    outList.Add(agentName);
            }
            else
            {
                List<string> newList = new List<string>();
                newList.Add(agentName);
                _routingTable.Add(subject, newList);
            }
        }

        /// <summary>
        /// Remove from the routing table
        /// </summary>
        /// <param name="agentName">Name of the agent</param>
        /// <param name="subject">Subject</param>
        private void RemoveRoute(string agentName, string subject)
        {
            List<string> outList;
            if (_routingTable.TryGetValue(subject, out outList))
            {
                outList.Remove(agentName);

                if (outList.Count <= 0)
                {
                    _routingTable.Remove(subject);
                }
            }
        }

        /// <summary>
        /// Send message into route table
        /// </summary>
        /// <param name="message">Message</param>
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

        /// <summary>
        /// Send message to near agents
        /// </summary>
        /// <param name="message"></param>
        private void SendMessageToNearAgents(AgentMessage message)
        {
            foreach (var agent in _nearAgents)
            {
                if (agent != message.SenderAgent)
                    _messageService.SendMessage(agent, message);
            }
        }

        /// <summary>
        /// Receive message method
        /// </summary>
        /// <param name="e">AgentMessaegEventArgs</param>
        private void MessageService_Publish(AgentMessageEventArgs e)
        {
            ReceiveMessage(e.AgentMessage);
        }

        /// <summary>
        /// Receivee message
        /// </summary>
        /// <param name="message">Message</param>
        private void ReceiveMessage(AgentMessage message)
        {
            ReceiveMessageEvent(new AgentMessageEventArgs(message));

            switch (message.MessageType)
            {
                case MessageType.Message:
                    UnsubscribeIfNeed(message);
                    SendMessageIntoRouteTable(message);
                    break;
                case MessageType.Subscribe:
                    AddNearAgentIfNotExists(message.SenderAgent);
                    AddRoute(message.SenderAgent, message.Subject);
                    SendMessageToNearAgents(message);
                    break;
                case MessageType.Unsubscribe:
                    RemoveRoute(message.SenderAgent, message.Subject);
                    //SendMessageToNearAgents(message);
                    break;
                case MessageType.Hello:
                    AddNearAgentIfNotExists(message.SenderAgent);
                    //SubscribeAll(message.SenderAgent);
                    break;
                case MessageType.Bye:
                    RemoveAgentFromRoutingTable(message.SenderAgent);
                    _nearAgents.Remove(message.SenderAgent);
                    //RemoveNearAgent(message.SenderAgent);
                    break;
            }
        }

        /// <summary>
        /// Unsubscrie if need
        /// </summary>
        /// <param name="message">Message</param>
        private void UnsubscribeIfNeed(AgentMessage message)
        {
            List<string> outList;
            if (!_routingTable.TryGetValue(message.Subject, out outList))
            {
                if (!_subscribed.Exists(s => s == message.Subject))
                {
                    AgentMessage msg = new AgentMessage()
                    {
                        MessageType = MessageType.Unsubscribe,
                        SenderAgent = AgentName,
                        Subject = message.Subject
                    };
                    _messageService.SendMessage(message.SenderAgent, msg);
                }
            }
        }

        /// <summary>
        /// Send all subscribe to near agent
        /// </summary>
        /// <param name="nearAgent">Name of the near agent</param>
        private void SubscribeAll(string nearAgent)
        {
            foreach (var route in _routingTable)
            {
                AgentMessage msg = new AgentMessage()
                {
                    MessageType = MessageType.Subscribe,
                    SenderAgent = AgentName,
                    Subject = route.Key
                };
                _messageService.SendMessage(nearAgent, msg);
            }

            foreach (var sub in _subscribed)
            {
                AgentMessage msg = new AgentMessage()
                {
                    MessageType = MessageType.Subscribe,
                    SenderAgent = AgentName,
                    Subject = sub
                };
                _messageService.SendMessage(nearAgent, msg);
            }
        }

        /// <summary>
        /// Add near agent if not exists
        /// </summary>
        /// <param name="nearAgent">Name of the near agent</param>
        private void AddNearAgentIfNotExists(string nearAgent)
        {
            if (!_nearAgents.Exists(a => a == nearAgent))
            {
                AddNearAgent(nearAgent);
            }
        }

        /// <summary>
        /// Name of this agent
        /// </summary>
        public string AgentName { get; set; }
    }
}
