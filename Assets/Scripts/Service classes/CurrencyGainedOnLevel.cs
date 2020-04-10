/// <summary>
/// Container for any currency which can be gained for temporary storage
/// </summary>
public class CurrencyGainedOnLevel
{
    public int Amount { get; private set; } = 0;
    /// <summary>
    /// Adds non-negative amount to temporary container
    /// </summary>
    public void AddToAmount(int amount = 10)
    {
        if (amount >= 0)
        {
             Amount += amount;
        }
    }
    /// <summary>
    /// Overwrites target field with value stored in this class
    /// </summary>
    /// <param name="targetField"></param>
    public void Save(ref int targetField)
    {
        targetField = Amount;
    }
    public override string ToString() => Amount.ToString();
}
