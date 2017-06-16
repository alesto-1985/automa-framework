using AutomaFramework.Attributes;
using AutomaFramework.Attributes.PreConditions;
using AutomaFramework.Attributes.PostConditions;
using AutomaFramework.Attributes.Factory;

namespace PreconditionsSample
{
    public class Work3Module
    {



        private AListener automa;



        public Work3Module(AListener automa)
        {
            this.automa = automa;
        }



        [Concept(Description = "Test Concept")]
        protected bool TestConcept()
        {
            return true;
        }


        [State(description = "Work 3", selectable = false)]
        [PreConditionKill(automa = "AExecutor")]
        [PreConditionConcept(concept = "TestConcept")]
        [PostConditionConcept(concept = "PostConcept", trueState = "TruePost", falseState = "FalsePost")]
        protected void Work3()
        {
            automa.Print("Work 3!!! With Concept!");
            automa.Sleep(2000);
        }



        [State(description = "PostConditionConcept true state.", selectable = false)]
        [NextState(state = "Stop")]
        protected void TruePost()
        {
            automa.Print("PostConditionConcept true state 'TruePost' executed.");
        }


        [State(description = "PostConditionConcept false state.", selectable = false)]
        [NextState(state = "Stop")]
        protected void FalsePost()
        {
            automa.Print("PostConditionConcept false state 'FalsePost' executed.");
        }


        [Concept(Description = "PostConditionConcept Test")]
        protected bool PostConcept()
        {
            return true;
        }




    }
}
