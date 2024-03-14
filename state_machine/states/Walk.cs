using Godot;

public partial class Walk : GroundMove
{
    public override void Enter()
    {
        base.Enter();
        TargetSpeed = OwnerBody.Speed;
    }
    public override void UnHandleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("run"))
        {
            EmitSignal(SignalName.Transition, "run");
        }
        base.UnHandleInput(@event);
    }
}