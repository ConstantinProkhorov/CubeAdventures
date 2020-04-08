using System;
public interface IInfoPanel
{
    event Action<int> ScoreChanged;
    event Action<int> DiamondsChanged;
    event Action<int> DynamiteChanged;
}
