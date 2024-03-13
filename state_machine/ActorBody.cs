using Godot;

public partial class ActorBody : CharacterBody3D
{
    public float Health { set; get; } = 100.0f;
    public float Speed { set; get; } = 5.0f;
    public float RunFactor { set; get; } = 2.0f;
    public float Acceleration { set; get; } = 50.0f;
    public float Deceleration { set; get; } = 50.0f;
    public float JumpImpulse { set; get; } = 4.5f;
    public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
}