using Godot;

public partial class ActorState: State
{
    public ActorBody OwnerBody;

    public override void _Ready()
    {
        OwnerBody = GetOwner<ActorBody>();
    }
}