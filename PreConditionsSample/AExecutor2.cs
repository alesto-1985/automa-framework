using System;
using AutomaFramework;
using AutomaFramework.Attributes;
using AutomaFramework.Attributes.Events;

namespace PreconditionsSample
{
    public class AExecutor2 : Automa
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

        [State(description = "Second state", selectable = false)]
        [NextState(state = STATE_THIRD)]
        protected void Second()
        {

            Print("Second state.");

            SignalEvent(EVENT_SECOND);
            Print("Throwed event EVENT_SECOND.");

            // Simulate some work
            Sleep(2000);
        }


        public const string STATE_THIRD = "Third";

        [State(description = "Third state", selectable = false)]
        [NextState(state = STATE_FOURTH)]
        protected void Third()
        {
            Print("Third state.");

            // Simulate some work
            Sleep(2000);

            SignalEvent(EVENT_CONDITION, 3);
            Print("Throwed EVENT_CONDITION event.");
        }


        public const string STATE_FOURTH = "Fourth";

        [State(description = "Fourth state", selectable = false)]
        [NextState(state = "Kill")]
        protected void Fourth()
        {
            Print("Fourth state.");

            // Simulate some work
            Sleep(2000);

            Print("Fourth state ends.");
        }



    }
}
