using Godot;

public partial class OnAir : ActorState
{
    public override void PhysicsUpdate(double delta)
    {
        // Still in the air, falling
        if (!OwnerBody.IsOnFloor())
        {
            OwnerBody.Velocity -= new Vector3(0, OwnerBody.gravity * (float)delta, 0);
        }
        // On the floor, transit to previous state
        else
        {
            EmitSignal(SignalName.Transition, "previous");
        }
        OwnerBody.MoveAndSlide();
    }
}