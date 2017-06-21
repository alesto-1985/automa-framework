using AutomaFramework;
using AutomaFramework.Attributes;
using MessageSample.Messages;

namespace MessageSample
{
    class AMessageReceiver : Automa
    {

        /// <summary>
        /// Execute this state when 
        /// any automa sends a message with subject 'Alert' and body of type 'AlertMessage'.
        /// </summary>
        /// <param name="body"></param>
        [State(Description = "Manage Alert message.", Selectable = false)]
        [MessageReceived(Subject = "Alert", BodyType = "AlertMessage")]
        [NextState(state = STATE_STOP)]
        protected void AlertMessageReceived(AlertMessage body)
        {
            Print("Received 'Alert' message. " + body.ToString());
        }


        /// <summary>
        /// Execute this state when automa 'AMessageSender' 
        /// sends a message with subject 'Task' and body of type 'Task'
        /// </summary>
        /// <param name="task"></param>
        [State(Description = "Manage Task message from AMessageSender.", Selectable = false)]
        [MessageReceived(AutomaType = typeof(AMessageSender), Subject = "Task", BodyType = "Task")]
        [NextState(state = STATE_STOP)]
        protected void SpecificTask(Task task)
        {
            Print("Received 'Task'. " + task.ToString());
        }


    }
}
