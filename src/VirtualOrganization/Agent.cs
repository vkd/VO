
namespace VirtualOrganization
{
    public class Agent
    {
        private IMessageService _messageService;

        private string _agentName = "";

        event AgentMessageEventHandler Publish;

        public Agent(string agentName)
        {
            _agentName = agentName;

            _messageService = new MSMQService(_agentName);
            _messageService.Publish += new AgentMessageEventHandler(MessageService_Publish);

        }

        void MessageService_Publish(AgentMessageEventArgs e)
        {
            Publish(new AgentMessageEventArgs(e.AgentMessage));


        }

        public string AgentName
        {
            get { return _agentName; }
            set { _agentName = value; }
        }
    }
}
