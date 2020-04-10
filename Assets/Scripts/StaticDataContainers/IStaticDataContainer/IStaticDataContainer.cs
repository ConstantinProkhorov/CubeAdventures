/// <summary>
/// Interface for access to static get only data.
/// In theory should provide safe and convinient way to access data which is immutable during runtime.
/// </summary>
public interface IStaticDataContainer
{
    /// <summary>
    /// Returns data as string. 
    /// </summary>
    string Get(string dataName);
    /// <summary>
    /// Returns data as string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="result">If data could be converted to int puts it in result. If not result will always be 0.</param>
    /// <returns></returns>
    string Get(string dataName, out int result);
}
