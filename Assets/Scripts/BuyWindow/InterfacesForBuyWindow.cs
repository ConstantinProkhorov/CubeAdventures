public interface IDictionarySupport
{
    IOpenCloseDictionary UnlockDictionary { get; set; }
    IPriceDictionary PriceDictionary { get; set; }
}

public interface IOpenCloseDictionary
{
    bool GetState(string Name);
    void ChangeState(string Name);
}

public interface IPriceDictionary
{
    int GetPrice(string Name);
}




