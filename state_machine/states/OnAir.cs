using Godot;

public partial class OnAir : ActorState
{
    public override void PhysicsUpdate(double delta)
    {
        OwnerBody.Velocity -= new Vector3(0, OwnerBody.gravity * (float)delta, 0);
    }
}