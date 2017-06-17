using AutomaFramework;
using AutomaFramework.Attributes;
using AutomaFramework.Attributes.PreConditions;

namespace PreconditionsSample
{
    public class AExecutor3 : Automa
    {


        public const string STATE_AEXECUTOR2KILLED = "AExecutor2Killed";

        [State(description = "Execute this state when automa AExecutor2 was killed.", selectable = false)]
        [PreConditionKill(automa = "AExecutor2")]
        [NextState(state = STATE_STOP)]
        protected void AExecutor2Killed()
        {
            Print("AExecutor2Killed state.");
            // Simulate some work
            Sleep(2000);
        }




    }
}
