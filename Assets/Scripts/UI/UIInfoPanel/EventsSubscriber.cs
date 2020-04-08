/// <summary>
///  События в ответ на которые инфопанель обновляется определены в IInfoPanel.
///  Для каждого обновляемого поля определено отдельное событие.
///  Класс EventSubscriber подписывает компоненты инфопанели на события, используя Behaviour EventsHolder. 
///  EventsHolder обязан реализовывать интерфейс IInfoPanel.
///  Конкретная стратегия представления информации содержится в потомках класса ViewChange, который предоставляет только интерфейс, 
///  без конкретной реализации.
/// </summary>
using UnityEngine;

public class EventsSubscriber : MonoBehaviour
{
    [SerializeField] private Behaviour EventsHolder;
    [SerializeField] private ViewChange Score;
    [SerializeField] private ViewChange Diamonds;
    [SerializeField] private ViewChange Dynamite;
    void Start()
    {
        if (EventsHolder is IInfoPanel)
        {
            IInfoPanel eventsHolder = (IInfoPanel)EventsHolder;
            eventsHolder.ScoreChanged += (int scoreDelta) => Score.Change(scoreDelta);
            eventsHolder.DiamondsChanged += (int scoreDelta) => Diamonds.Change(scoreDelta);
            eventsHolder.DynamiteChanged += (int scoreDelta) => Dynamite.Change(scoreDelta);
        }
    }
}
