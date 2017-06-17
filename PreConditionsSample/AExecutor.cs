using System;
using AutomaFramework;
using AutomaFramework.Attributes;
using AutomaFramework.Attributes.Events;

namespace PreconditionsSample
{
    public class AExecutor : Automa
    {

        /// <summary>
        /// Declare events with attribute [Event]
        /// </summary>
        [Event]
        public const String EVENT_SECOND = "eventSecond";

        /// <summary>
        /// This event has got a parameter of type "int" named "number".
        /// </summary>
        [Event]
        [EventParam(Name = "number", Type = typeof(int))]
        public const String EVENT_CONDITION = "eventCondition";

        /// <summary>
        /// This event has got 3 parameters. Each parameter is positional.
        /// </summary>
        [Event]
        [EventParam(Name = "number", Type = typeof(int))]
        [EventParam(Name = "word", Type = typeof(string))]
        [EventParam(Name = "total", Type = typeof(int))]
        public const String EVENT_CONDITION_VALUES = "eventConditionValues";



        public const string STATE_FIRST = "First";

        /// <summary>
        /// Mark this state as Default so when this automa is started this state will be executed first.
        /// </summary>
        [DefaultState]
        [State(description = "First state", selectable = false)]
        [NextState(state = STATE_SECOND)]
        protected void First()
        {
            Print("First state.");

            // Simulate some work
            Sleep(2000);
        }


        public const string STATE_SECOND = "Second";

        [State(description = "Second state where automa signals EVENT_SECOND.", selectable = false)]
        [NextState(state = STATE_THIRD)]
        protected void Second()
        {
            Print("Second state.");

            // Signal event EVENT_SECOND
            SignalEvent(EVENT_SECOND);

            Print("Throwed event EVENT_SECOND.");

            // Simulate some work
            Sleep(2000);
        }


        public const string STATE_THIRD = "Third";

        [State(description = "Third state", selectable = false)]
        [NextState(state = STATE_KILL)]
        protected void Third()
        {
            Print("Third state.");

            // Signal event EVENT_CONDITION with the first parameter of value 3
            SignalEvent(EVENT_CONDITION, 3);

            // Signal event EVENT_CONDITION_VALUES with first parameter of value 3,
            // second parameter of value 'Values', third parameter of value 20
            SignalEvent(EVENT_CONDITION_VALUES, 3, "Values", 20);

            Print("Throwed EVENT_CONDITION event.");

            // Simulate some work
            Sleep(2000);
        }



    }
}
