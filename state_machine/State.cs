using Godot;
using System;

public partial class State : Node
{
    [Signal]
    public delegate void TransitionEventHandler(string nextStateName);

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput(InputEvent @event)
    {
    }

    public virtual void UnHandleInput(InputEvent @event)
    {
    }

    public virtual void Update(double delta)
    {
    }

    public virtual void PhysicsUpdate(double delta)
    {
    }

    public virtual void OnAnimationFinished(string animationName)
    {
    }

}