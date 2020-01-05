using System;
public enum StepType : byte // перечисление для настроек шага рандомизатора времени появления врагов
{
    FloatStep = 0,
    StaticStep,
    NoStep
}
public enum HorizontalDirection : sbyte
{
    left = -1,
    right = 1
}
public static class HorizontalDirectionExtension
{
    public static HorizontalDirection GetRandom(this HorizontalDirection direction)
    {
        Random rnd = new Random();
        int i = rnd.Next(2);
        if (i == 0)
        {
            return HorizontalDirection.left;
        }
        return HorizontalDirection.right;
    }
}
enum VerticalDirection : sbyte
{
    up = 1,
    down = -1,
}

public enum SpecialEffects : byte
{
    NoEffect = 0,
    Invincibility,
    Explosion
}


