using Godot;
using System.Collections.Generic;

public partial class StateMachine : Node
{
    [Export]
    public State InitialState { get; set; }
    private State CurrentState { get; set; }
    private Stack<State> StatesStack { get; set; } = new Stack<State>();
    private Dictionary<string, State> StatesMap { get; set; } = new Dictionary<string, State>();

    public override void _Ready()
    {
        foreach (Node child in GetChildren())
        {
            if (child is State state)
            {
                StatesMap[state.Name.ToString().ToLower()] = state;
                state.Transition += ChangeState; // Connect transition signal to ChangeState function
            }
        }

        StatesStack.Push(InitialState);
        CurrentState = StatesStack.Peek();
    }

    public override void _Input(InputEvent @event)
    {
        CurrentState.HandleInput(@event);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        CurrentState.UnHandleInput(@event);
    }

    public override void _Process(double delta)
    {
        CurrentState.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        CurrentState.PhysicsUpdate(delta);
    }

    private void ChangeState(string stateName)
    {
        if (StatesMap.ContainsKey(stateName) || stateName == "previous")
        {
            CurrentState.Exit();

            if (stateName == "previous")
            // Pop current state out
            {
                StatesStack.Pop();
            }
            else
            // Push new state in
            {
                StatesStack.Push(StatesMap[stateName.ToLower()]);
            }

            CurrentState = StatesStack.Peek();

            if (stateName != "previous")
            {
                CurrentState.Enter();
            }
        }
    }
}