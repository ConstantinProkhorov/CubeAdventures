using UnityEngine;
/// <summary>
/// Creates new Dynamite.
/// </summary>
public class DynamiteFactory : MonoBehaviour
{
    [SerializeField] private GameObject DynamitePrefab = null;
    /// <summary>
    /// Instantiates one new Dynamite. 
    /// </summary>
    public void Create()
    {
        GameObject clone = Instantiate(DynamitePrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
        // тут по идеи должен быть код приведения к нормальную размеру?
    }
}
