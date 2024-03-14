using Godot;

/// <summary>
/// Base state for states on the ground.
/// Handles jump input and transits to jump state.
/// </summary>
public partial class OnGround : ActorState
{
    public Vector3 Direction;
    public Vector3 GroundVelocity;
    public float CurrentSpeed;
    public float TargetSpeed;
    public override void PhysicsUpdate(double delta)
    {
        if (OwnerBody.IsOnFloor())
        {
            if (Input.IsActionPressed("jump"))
            {
                EmitSignal(SignalName.Transition, "jump");
            }
        }
        // Not on floor
        else
        {
            EmitSignal(SignalName.Transition, "fall");
        }
        OwnerBody.MoveAndSlide();
    }
    private protected void UpdateGroundInput()
    {
        Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
        Direction = new Vector3(inputDir.X, 0, inputDir.Y).Normalized();

        // Calculate Gound velocity and Current ground speed
        GroundVelocity = new Vector3(OwnerBody.Velocity.X, 0, OwnerBody.Velocity.Z);
        CurrentSpeed = GroundVelocity.Length();
    }
}