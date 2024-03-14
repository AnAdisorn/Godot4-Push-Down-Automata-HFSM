using Godot;

public partial class Idle : OnGround
{
    public override void PhysicsUpdate(double delta)
    {
        UpdateGroundInput();

        if (Direction != Vector3.Zero)
        {
            EmitSignal(SignalName.Transition, "walk");
        }
        base.PhysicsUpdate(delta);
    }
}