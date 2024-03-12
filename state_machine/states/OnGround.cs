using Godot;

/// <summary>
/// Base state for states on the ground.
/// Handles jump input and transits to jump state.
/// </summary>
public partial class OnGround : ActorState
{
    public override void UnHandleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("jump"))
        {
            EmitSignal(SignalName.Transition, "jump");
        }
    }
}