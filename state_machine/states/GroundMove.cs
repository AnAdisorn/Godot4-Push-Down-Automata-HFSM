using Godot;

/// <summary>
/// Base state for movement on ground.
/// Handles input direction as Vector3 direction, in PhysicsUpdate.
/// Also handle transition to idle when there is no input and body comes to stop.
/// </summary>
public partial class GroundMove : OnGround
{

    public override void PhysicsUpdate(double delta)
    {
        UpdateGroundInput();
        // Update OwnerBody velocity
        // Accelerate according to input
        if (Direction != Vector3.Zero)
        {
            OwnerBody.Velocity += (Direction * TargetSpeed - GroundVelocity).Normalized() * OwnerBody.Acceleration * (float)delta;
        }
        // No input
        else
        {
            // Stop, back to previous state
            if (GroundVelocity == Vector3.Zero)
            {
                EmitSignal(SignalName.Transition, "previous");
            }
            // Decelerate
            else
            {
                OwnerBody.Velocity = GroundVelocity.Normalized() * Mathf.MoveToward(CurrentSpeed, 0, OwnerBody.Deceleration * (float)delta);
            }
        }

        base.PhysicsUpdate(delta);
        // GD.Print(OwnerBody.Velocity);
    }
}