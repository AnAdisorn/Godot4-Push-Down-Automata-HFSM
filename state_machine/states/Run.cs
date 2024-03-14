using Godot;

public partial class Run : GroundMove
{
    public override void Enter()
    {
        base.Enter();
        TargetSpeed = OwnerBody.Speed * OwnerBody.RunFactor;
    }
    public override void UnHandleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("run"))
        {
            EmitSignal(SignalName.Transition, "previous");
        }
        base.UnHandleInput(@event);

    }
}