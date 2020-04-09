public class CurrencyGainedOnLevel
{
    public int Amount { get; private set; } = 0;
    public void Add(int amount = 10) => Amount += amount;
    public void Save(ref int targetField)
    {
        targetField = Amount;
    }
    public override string ToString() => Amount.ToString();
}
