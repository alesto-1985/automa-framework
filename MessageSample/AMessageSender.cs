using AutomaFramework;
using AutomaFramework.Attributes;
using MessageSample.Messages;

namespace MessageSample
{
    class AMessageSender : Automa
    {

        [DefaultState]
        [State(Description = "Send an Alert Message", Selectable = false)]
        [NextState(state = STATE_SendTask)]
        protected void SendAlertMessage()
        {

            AlertMessage alert = new AlertMessage()
            {
                Content = "An important message!",
                Type = "Important",
                From = Name,
                Priority = 1
            };

            // Send the 'alert' message to AMessageReceiver with subject 'Alert'
            // ATTENTION: if AMessageReceiver doesn't have a MessageReceived rule that matches
            // with this message, an Exception of type 'AutomaMessageNotAcceptedException' will be thrown
            SendMessage(typeof(AMessageReceiver), "Alert", alert);

            Print("Message 'Alert' sent to 'AMessageReceiver'.");

        }



        public const string STATE_SendTask = "SendTask";

        [State(Description = "SendTask", Selectable = false)]
        [NextState(state = STATE_STOP)]
        protected void SendTask()
        {

            Print("Executing state 'SendTask'.");

            Task task = new Task()
            {
                Name = "main",
                Priority = 2,
                Context = "default"
            };

            // Send the 'task' message to AMessageReceiver with subject 'Task'
            // ATTENTION: if AMessageReceiver doesn't have a MessageReceived rule that matches
            // with this message, an Exception of type 'AutomaMessageNotAcceptedException' will be thrown
            SendMessage(typeof(AMessageReceiver), "Task", task);

        }




        public const string STATE_SendBroadCastAlertMessage = "SendBroadCastAlertMessage";

        [State(Description = "SendBroadCastAlertMessage", Selectable = false)]
        [NextState(state = STATE_STOP)]
        protected void SendBroadCastAlertMessage()
        {
            Print("Executing state 'SendBroadCastAlertMessage'.");

            AlertMessage alert = new AlertMessage()
            {
                Content = "A broadcast message.",
                Type = "Everyone",
                From = Name,
                Priority = 5
            };

            SendBroadcastMessage("Everyone", alert);

        }


    }
}
