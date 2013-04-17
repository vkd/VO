using System;
using System.Messaging;

namespace VirtualOrganization
{
    /// <summary>
    /// Service for send and receive messages from MSMQ
    /// </summary>
    class MSMQService : IMessageService
    {
        /// <summary>
        /// Prefix for path of agent
        /// </summary>
        private const string PREFIX_PATH = @".\private$\";

        /// <summary>
        /// Path of this agent
        /// </summary>
        private string _pathService = "";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pathService">Path of this agent</param>
        public MSMQService(string pathService)
        {
            _pathService = pathService;
            BeginReceive(_pathService);
        }

        /// <summary>
        /// Send message to another agent
        /// </summary>
        /// <param name="receiverAgent">Receiver agent</param>
        /// <param name="message">Message</param>
        public void SendMessage(string receiverAgent, AgentMessage message)
        {
            string pathAgent = PREFIX_PATH + receiverAgent;

            MessageQueue mq;
            if (MessageQueue.Exists(pathAgent))
                mq = new MessageQueue(pathAgent);
            else
                mq = MessageQueue.Create(pathAgent);

            message.SenderAgent = _pathService;
            mq.Send(message);
        }

        /// <summary>
        /// Initiates an asynchronous receive operation
        /// </summary>
        private void BeginReceive(string senderAgent)
        {
            string pathAgent = PREFIX_PATH + senderAgent;

            MessageQueue mq;
            if (MessageQueue.Exists(pathAgent))
                mq = new MessageQueue(pathAgent);
            else
                mq = MessageQueue.Create(pathAgent);

            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(AgentMessage) });
            mq.ReceiveCompleted += new ReceiveCompletedEventHandler(MessageQueue_ReceiveCompleted);
            mq.BeginReceive();
        }

        /// <summary>
        /// Receive messages
        /// </summary>
        /// <param name="sender">MessageQueue</param>
        /// <param name="e">ReceiveCompletedEventArgs</param>
        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)sender;
            Message msg = mq.EndReceive(e.AsyncResult);
            AgentMessage agentMessage = (AgentMessage)msg.Body;
            Publish(new AgentMessageEventArgs(agentMessage));

            mq.BeginReceive();
        }

        /// <summary>
        /// Event of publish message
        /// </summary>
        public event AgentMessageEventHandler Publish;
    }
}
