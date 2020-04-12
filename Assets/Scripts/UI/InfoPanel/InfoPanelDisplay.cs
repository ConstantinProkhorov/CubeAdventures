using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Implements interface and shared members for infoPanel display strategy.
/// </summary>
public abstract class InfoPanelDisplay : MonoBehaviour
{
    [SerializeField] protected Text ScoreDisplay;
    [SerializeField] protected Text DiamondsDisplay;
    [SerializeField] protected Text DynamiteDisplay;
    /// <summary>
    /// Outputs data to infoPanel three text fields. 
    /// </summary>
    public abstract void Display();
}
