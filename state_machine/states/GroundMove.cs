using Godot;

/// <summary>
/// Base state for movement on ground.
/// Handles input direction as Vector3 direction, in PhysicsUpdate.
/// Also handle transition to idle when there is no input and body comes to stop.
/// </summary>
public partial class GroundMove: OnGround
{
    public Vector3 Direction;
    public Vector3 GroundVelocity;
    public float CurrentSpeed;
    public float TargetSpeed;
    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);        
        Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
        Direction = new Vector3(inputDir.X, 0, inputDir.Y).Normalized();

        GroundVelocity = new Vector3(OwnerBody.Velocity.X, 0, OwnerBody.Velocity.Z);
        CurrentSpeed = GroundVelocity.Length();
        GD.Print(GroundVelocity);

        // Update OwnerBody velocity
        if (Direction != Vector3.Zero)
        {
            OwnerBody.Velocity += (Direction*TargetSpeed-GroundVelocity).Normalized() * OwnerBody.Acceleration * (float)delta;
        }
        else
        {
            OwnerBody.Velocity = OwnerBody.Velocity.Normalized() * Mathf.MoveToward(CurrentSpeed, 0, OwnerBody.Acceleration * (float)delta);
        }

        if (Direction == Vector3.Zero && GroundVelocity == Vector3.Zero)
        {
            EmitSignal(SignalName.Transition, "previous");
        }

        OwnerBody.MoveAndSlide();
    }
}