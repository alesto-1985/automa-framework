using System;
using AutomaFramework;
using AutomaFramework.Attributes;

namespace PreconditionsSample
{
    public class AExecutor2 : Automa
    {


        public const String EVENT_SECOND = "eventSecond";
        public const String EVENT_CONDITION = "eventCondition";



        public AExecutor2()
        {
            DeclareEvent(EVENT_SECOND);
            DeclareEvent(EVENT_CONDITION);
        }


        public const string STATE_FIRST = "First";

        [DefaultState]
        [State(description = "First state", selectable = false)]
        [NextState(state = STATE_SECOND)]
        protected void First()
        {
            Print("First state.");
            Sleep(2000);
        }


        public const string STATE_SECOND = "Second";

        [State(description = "Second state", selectable = false)]
        [NextState(state = STATE_THIRD)]
        protected void Second()
        {
            SignalEvent(EVENT_SECOND);
            Print("Throwed event EVENT_SECOND.");
            Print("Second state.");
            Sleep(2000);
        }


        public const string STATE_THIRD = "Third";

        [State(description = "Third state", selectable = false)]
        [NextState(state = STATE_FOURTH)]
        protected void Third()
        {
            Print("Third state.");
            Sleep(2000);
            EVENTS_GENERATOR.ThrowCustomEvent(EVENT_CONDITION, "Event Condition", "Third", 3);
            Print("Throwed EVENT_CONDITION event.");
        }


        public const string STATE_FOURTH = "Fourth";

        [State(description = "Fourth state", selectable = false)]
        [NextState(state = "Kill")]
        protected void Fourth()
        {
            Print("Fourth state.");
            Sleep(2000);
            Print("Fourth state ends.");
        }



    }
}
