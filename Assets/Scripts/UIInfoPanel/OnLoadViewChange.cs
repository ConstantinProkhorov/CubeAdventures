public sealed class OnLoadViewChange : ViewChange
{
    public override void Change(int value) => Display.text = value.ToString();
}
