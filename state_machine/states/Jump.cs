using Godot;

public partial class Jump : OnAir
{
    public override void Enter()
    {
        base.Enter();
        // Enter jump, add JumpImpulse to vertical velocity
        OwnerBody.Velocity += new Vector3(0, OwnerBody.JumpImpulse, 0);
        // Transit to fall
        EmitSignal(SignalName.Transition, "fall");
    }
}