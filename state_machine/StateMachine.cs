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
        GD.Print(CurrentState.Name);
        CurrentState.PhysicsUpdate(delta);
    }

    private void ChangeState(string stateName)
    {
        GD.Print($"{CurrentState.Name} transits to {stateName}");
        // Check if stateName is valid
        if (StatesMap.ContainsKey(stateName) || stateName == "previous")
        {
            CurrentState.Exit();

            // Pop current state out if next state is previous
            if (stateName == "previous")
            {
                StatesStack.Pop();
            }
            // Push new state in if next state is not previous
            else
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