using System;
using AutomaFramework;
using AutomaFramework.Attributes;

namespace PreconditionsSample
{
    public class AExecutor : Automa
    {


        public const String EVENT_SECOND = "eventSecond";
        public const String EVENT_CONDITION = "eventCondition";
        public const String EVENT_CONDITION_VALUES = "eventConditionValues";



        public AExecutor()
        {
            DeclareEvent(EVENT_SECOND);
            DeclareEvent(EVENT_CONDITION);
            DeclareEvent(EVENT_CONDITION_VALUES);
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

        [State(description = "Second state where is throwed EVENT_SECOND.", selectable = false)]
        [NextState(state = STATE_THIRD)]
        protected void Second()
        {
            Print("Second state.");
            SignalEvent(EVENT_SECOND);
            Print("Throwed event EVENT_SECOND.");            
            Sleep(2000);
        }


        public const string STATE_THIRD = "Third";

        [State(description = "Third state", selectable = false)]
        [NextState(state = STATE_KILL)]
        protected void Third()
        {
            Print("Third state.");            
            SignalEvent(EVENT_CONDITION, 3);
            SignalEvent(EVENT_CONDITION_VALUES, 3, "Values", 20);
            Print("Throwed EVENT_CONDITION event.");
            Sleep(2000);
        }



    }
}
