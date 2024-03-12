using Godot;

public partial class Idle : OnGround
{
    public override void UnHandleInput(InputEvent @event)
    {
        base.UnHandleInput(@event);
        if (@event.IsActionPressed("left") || @event.IsActionPressed("right") || @event.IsActionPressed("up") || @event.IsActionPressed("down"))
        {
            EmitSignal(SignalName.Transition, "walk");
        }
    }
}