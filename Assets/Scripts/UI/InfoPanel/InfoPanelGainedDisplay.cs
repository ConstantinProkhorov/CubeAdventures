public class InfoPanelGainedDisplay : InfoPanelDisplay
{
    public override void Display()
    {
        ScoreDisplay.text = $"+{SceneController.ScoreGainedOnLevel.ToString()}";
        DiamondsDisplay.text = $"+{SceneController.DiamondsGainedOnLevel.ToString()}";
        DynamiteDisplay.text = SceneController.Dynamite.ToString();
    }
}
