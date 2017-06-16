---------------------------------
AutomaFramework by alesto1985
---------------------------------

Quick Guide:

Create your first simple Automa with a state called "First".
This state will be executed when the command "Start" will be called on your Automa.

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
