using UnityEngine;
using UnityEngine.UI;
// определяет интерфейс для вывода изменений на инфопанель
public abstract class ViewChange : MonoBehaviour
{
    [TextArea]
    public string OptionalDescription = "Enter an optional description for this component.\nThis is for convinience only.";
    [SerializeField] protected Text Display;
    public abstract void Change(int value);
}
