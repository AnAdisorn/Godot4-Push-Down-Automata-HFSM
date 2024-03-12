using Godot;

public partial class Jump : OnAir
{
    public override void Enter()
    {
        base.Enter();
        OwnerBody.Velocity += new Vector3(0, OwnerBody.JumpImpulse, 0);
    }
    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        OwnerBody.MoveAndSlide();

        if (OwnerBody.IsOnFloor())
        {
            EmitSignal(SignalName.Transition, "previous");
        }
    }
}