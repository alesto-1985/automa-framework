using System;
using AutomaFramework;
using AutomaFramework.Attributes;
using AutomaFramework.Attributes.PreConditions;

namespace PreconditionsSample
{
    public class AListener : Automa
    {


        /// <summary>
        /// Execute this state when automa AExecutor is stopped OR automa AExecutor2 is stopped.
        /// </summary>
        [State(description = "Subscribe to Stop events.", selectable = false)]
        [PreConditionStop(automa = "AExecutor")]
        [PreConditionStop(automa = "AExecutor2")]
        [NextState(state = STATE_STOP)]
        protected void PreConditionStopTest()
        {
            Print("PreConditionStopTest state.");
            // Simulate some work
            Sleep(2000);
        }


        /// <summary>
        /// Execute this state when: 
        /// the state of automa AExecutor is changed to STATE_FIRST 
        /// OR 
        /// the state of automa AExecutor is changed to STATE_THIRD
        /// OR
        /// the state of automa AExecutor2 is changed to STATE_THIRD
        /// </summary>
        [State(description = "Subscribe to ChangeStateTo events.", selectable = false)]
        [PreConditionChangeState(automa = "AExecutor", state = AExecutor.STATE_FIRST)]
        [PreConditionChangeState(automa = "AExecutor", state = AExecutor.STATE_THIRD)]
        [PreConditionChangeState(automa = "AExecutor2", state = AExecutor2.STATE_THIRD)]
        [NextState(state = STATE_STOP)]
        protected void PreConditionChangeStateTest()
        {
            Print("PreConditionChangeStateTest state.");
            // Simulate some work
            Sleep(2000);
        }


        /// <summary>
        /// Execute this state when:
        /// Automa AExecutor signals event EVENT_SECOND
        /// OR
        /// Automa AExecutor2 signals event EVENT_SECOND
        /// </summary>
        [State(description = "Subscribe to custom events.", selectable = false)]
        [PreConditionEvent(automa = "AExecutor", name = AExecutor.EVENT_SECOND)]
        [PreConditionEvent(automa = "AExecutor2", name = AExecutor.EVENT_SECOND)]
        [NextState(state = STATE_STOP)]
        protected void PreConditionEventTest()
        {
            Print("PreConditionEventTest state.");
            // Simulate some work
            Sleep(2000);
        }


        /// <summary>
        /// Execute this state when:
        /// Automa AExecutor was killed
        /// OR
        /// Automa AExecutor2 was killed
        /// </summary>
        [State(description = "Subscribe to Kill event.", selectable = false)]
        [PreConditionKill(automa = "AExecutor")]
        [PreConditionKill(automa = "AExecutor2")]
        [NextState(state = STATE_STOP)]
        protected void PreConditionKillTest()
        {
            Print("PreConditionKillTest state.");
            // Simulate some work
            Sleep(2000);
        }


        /// <summary>
        /// Execute this state when automa AExecutor2 ends the execution of state STATE_FOURTH.
        /// </summary>
        [State(description = "Subscribe to EndState event.", selectable = false)]
        [PreConditionEndState(automa = "AExecutor2", state = AExecutor2.STATE_FOURTH)]
        [NextState(state = STATE_STOP)]
        protected void PreConditionEndStateTest()
        {
            Print("PreConditionEndStateTest state, state Fourth ends.");
            // Simulate some work
            Sleep(2000);
        }


        /// <summary>
        /// Execute this state when:
        /// Automa AExecutor was killed
        /// AND
        /// Automa AExecutor2 was killed
        /// AND
        /// Automa AExecutor3 ends the execution of state STATE_AEXECUTOR2KILLED
        /// 
        /// The state is executed only when all above events was happened.
        /// When one of the above events happens, a flag is stored, so when the last
        /// of the three events was happened the state will be executed.
        /// After the execution all the flags are destroyed and the state waits for all the events again.
        /// </summary>
        [State(description = "Subscribe to Kill and EndState events.", selectable = false)]
        [PreConditionKill(automa = "AExecutor")]
        [PreConditionKill(automa = "AExecutor2")]
        [PreConditionEndState(automa = "AExecutor3", state = AExecutor3.STATE_AEXECUTOR2KILLED)]
        [PreConditionsEvaluation(EvaluationType.AND)]
        [NextState(state = STATE_STOP)]
        protected void PreConditionKillEndStateAndTest()
        {
            Print("PreConditionKillEndStateAndTest state.");
            // Simulate some work
            Sleep(2000);
        }


        /// <summary>
        /// Execute this state when automa AExecutor3 starts the execution of state 'ExecutorFinal'. 
        /// </summary>
        [State(description = "PreConditionStartStateTest", selectable = false)]
        [PreConditionStartState(automa = "AExecutor3", state = "ExecutorFinal")]
        [NextState(state = STATE_STOP)]
        protected void PreConditionStartStateTest()
        {
            Print("PreConditionStartStateTest state: started state 'ExecutorFinal'.");
            // Simulate some work
            Sleep(2000);
        }



        public const String STATE_PreConditionEventValueTest = "PreConditionEventValueTest";

        /// <summary>
        /// Execute this state when automa AExecutor signals event EVENT_CONDITION and the event parameter equals to 3.
        /// </summary>
        /// <param name="value"></param>
        [State(description = "Listens to value event.", selectable = false)]
        [PreConditionEventValue(automa = "AExecutor", eventName = AExecutor.EVENT_CONDITION, condition = EventCondition.EQUAL, value = "3")]
        [NextState(state = STATE_STOP)]
        protected void PreConditionEventValueTest(int number)
        {
            Print("Executing state 'PreConditionEventValueTest'. Value = " + number);
            // Simulate some work
            Sleep(1000);
        }



        public const String STATE_PreConditionEventValuesTest = "PreConditionEventValuesTest";

        /// <summary>
        /// Execute this state when automa AExecutor signals event EVENT_CONDITION_VALUES
        /// AND
        /// first parameter of event is greater than 0
        /// AND
        /// second parameter of event equals to 'Values'
        /// </summary>
        /// <param name="number"></param>
        /// <param name="word"></param>
        /// <param name="total"></param>
        [State(description = "Listens to values event.", selectable = false)]
        [PreConditionEventValues(automa = "AExecutor", eventName = AExecutor.EVENT_CONDITION_VALUES,
                                 eventParameterCondition0 = PreConditionEventValues.ParameterIndex.INDEX_0, condition0 = EventCondition.GREATER, value0 = "0",
                                 eventParameterCondition1 = PreConditionEventValues.ParameterIndex.INDEX_1, condition1 = EventCondition.EQUAL, value1 = "Values"
                                )]
        [NextState(state = STATE_STOP)]
        protected void PreConditionEventValuesTest(int number, String word, int total)
        {
            Print("Executing state 'PreConditionEventValuesTest'. number = " + number + ", word = " + word + ", total = " + total);
            // Simulate some work
            Sleep(1000);
        }


        public new void Print(string s)
        {
            base.Print(s);
        }


        public new void Sleep(int millis)
        {
            base.Sleep(millis);
        }


    }
}
