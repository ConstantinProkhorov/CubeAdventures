public sealed class GameLevelViewChange : ViewChange
{
    public override void Change(int value)
    {
        Display.text = $"+{value}";
    }
}
