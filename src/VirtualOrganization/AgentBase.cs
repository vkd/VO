﻿using System.Collections.Generic;

namespace VirtualOrganization
{
    /// <summary>
    /// Abstract class of agent
    /// </summary>
    public abstract class AgentBase
    {
        /// <summary>
        /// Routing service
        /// </summary>
        protected RoutingService _routingService;

        /// <summary>
        /// Event of receive message
        /// </summary>
        public event AgentMessageEventHandler ReceiveMessage;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="agentName">Name of this agent</param>
        /// <param name="nearAgents">Array of the near agents</param>
        public AgentBase(string agentName, string[] nearAgents = null)
        {
            AgentName = agentName;
            _routingService = new RoutingService(AgentName, nearAgents);

            _routingService.ReceiveMessageEvent += new AgentMessageEventHandler(RoutingService_ReceiveMessageEvent);
        }

        /// <summary>
        /// Receive message method
        /// </summary>
        /// <param name="e">AgentMessageEventArgs</param>
        private void RoutingService_ReceiveMessageEvent(AgentMessageEventArgs e)
        {
            ReceiveMessage(new AgentMessageEventArgs(e.AgentMessage));
        }

        /// <summary>
        /// Add near agent
        /// </summary>
        /// <param name="nearAgent">Name near agent</param>
        public void AddNearAgent(string nearAgent)
        {
            _routingService.AddNearAgent(nearAgent);
        }


        /// <summary>
        /// Remove near agent
        /// </summary>
        /// <param name="nearAgent">Name removed agent</param>
        public void RemoveNearAgent(string nearAgent)
        {
            _routingService.RemoveNearAgent(nearAgent);
        }

        /// <summary>
        /// Get near agents
        /// </summary>
        /// <returns>List of near agents</returns>
        public List<string> GetNearAgents()
        {
            return _routingService.GetNearAgents();
        }

        /// <summary>
        /// Subscribe
        /// </summary>
        /// <param name="subject">Subject</param>
        public void Subscribe(string subject)
        {
            _routingService.Subscribe(subject);
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <param name="subject">Subject</param>
        public void Unsubscribe(string subject)
        {
            _routingService.Unsubscribe(subject);
        }

        /// <summary>
        /// Publish
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="text">Message</param>
        public void Publish(string subject, string text)
        {
            _routingService.Publish(subject, text);
        }


        /// <summary>
        /// Get routing list
        /// </summary>
        /// <returns>Routing list</returns>
        public List<string> GetRoutingList()
        {
            return _routingService.GetRouting();
        }

        /// <summary>
        /// Get subscribed
        /// </summary>
        /// <returns>List of subscribed</returns>
        public List<string> GetSubscribed()
        {
            return _routingService.GetSubscribed();
        }

        /// <summary>
        /// Name of this agent
        /// </summary>
        public string AgentName { get; private set; }
    }
}
