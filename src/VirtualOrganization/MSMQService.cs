using System.Collections.Generic;
using System.Messaging;
using System;

namespace VirtualOrganization
{
    public class MSMQService : IMessageService
    {
        private const string PREFIX_PATH = @".\private$\";

        private string _pathServiceName = "";

        public MSMQService(string pathServiceName)
        {
            _pathServiceName = pathServiceName;
            BeginReceive();
        }

        public void SendMessage(string receiverAgent, AgentMessage message)
        {
            string pathAgent = PREFIX_PATH + receiverAgent;

            MessageQueue mq;
            if (MessageQueue.Exists(pathAgent))
                mq = new MessageQueue(pathAgent);
            else
                mq = MessageQueue.Create(pathAgent);

            mq.Send(message);
        }

        private void BeginReceive()
        {
            string pathAgent = PREFIX_PATH + _pathServiceName;

            MessageQueue mq;
            if (MessageQueue.Exists(pathAgent))
                mq = new MessageQueue(pathAgent);
            else
                mq = MessageQueue.Create(pathAgent);

            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(AgentMessage) });
            mq.ReceiveCompleted += new ReceiveCompletedEventHandler(MessageQueue_ReceiveCompleted);
            mq.BeginReceive();
        }

        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)sender;
            Message msg = mq.EndReceive(e.AsyncResult);
            AgentMessage agentMessage = (AgentMessage)msg.Body;
            Publish(new AgentMessageEventArgs(agentMessage));

            mq.BeginReceive();
        }

        public event AgentMessageEventHandler Publish;
    }
}
