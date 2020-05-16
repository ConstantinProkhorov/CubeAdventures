public class InfoPanelTotalDisplay : InfoPanelDisplay
{
    public override void Display()
    {
        ScoreDisplay.text = SceneController.Score.ToString();
        DiamondsDisplay.text = SceneController.Diamonds.ToString();
        DynamiteDisplay.text = SceneController.Dynamite.ToString();
    }
}
