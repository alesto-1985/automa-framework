---------------------------------
AutomaFramework by alesto1985
---------------------------------

Quick Guide:

Create your first simple Automa with a state called "First".
This state will be executed when the command "Start" will be called on your Automa.

See more code samples on GitHub: https://github.com/alesto-1985/automa-framework.

using AutomaFramework;
using AutomaFramework.Attributes;

class ASimple : Automa
{

    [DefaultState]
    [State(Description = "First", Selectable = false)]
    [NextState(state = STATE_STOP, arguments = new object[] { })]
    protected void First()
    {
        Print("Executing state 'First'.");
        Sleep(1000);
    }

}


Initialize your dynamic environment, with this method all Automas and Tools 
declared in your Assembly will be loaded automatically.
With "Start" command the execution starts.
Specifying the type of our Automa "ASimple" class as parameter of "ADynamicEnvironment" constructor 
this Automa will be started, so it's state marked with attribute "DefaultState" will be executed.

using AutomaFramework;
using System;

class Program
{
    static void Main(string[] args)
    {
        new ADynamicEnvironment(typeof(ASimple)).Start();
        Console.ReadLine();
    }
}

---------------------------------
Automa
---------------------------------

An Automa represents the base Actor of AutomaFramework.

Main features are:
- Throw Events
- Send Messages
- Automate State Sequences

The behavior is composed by a list of States.
Every state is a method marked with attribute "AutomaFramework.Attributes.State".
A state can have a list of preconditions and postconditions,
for each of them there is a reserved attribute.

PreCondition Attributes (namespace "AutomaFramework.Attributes.PreConditions"):
- PreConditionStart
- PreConditionKill
- PreConditionStop
- PreConditionStartState
- PreConditionEndState
- PreConditionEvent
- PreConditionEventValue
- MessageReceived
- PreConditionConcept
- PreConditionToolEvent
- PreConditionToolEventValue
- PreConditionToolStartOperation
- PreConditionToolEndOperation

PostCondition Attributes:
- AutomaFramework.Attributes.NextState
- AutomaFramework.Attributes.PostConditions.PostConditionField
- AutomaFramework.Attributes.PostConditions.PostConditionConcept

Every Automa has got its own thread and executes one state at a time.
All the state execution requests are stored into an internal message queue sorted by received date.
The Automa executes all the requests stored into the message queue according to its order.
