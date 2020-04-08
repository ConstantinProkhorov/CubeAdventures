using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectActivation : MonoBehaviour
{
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine("Activate");
        StartCoroutine("Inactivate");
    }
    
    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(1.0f);
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private IEnumerator Inactivate()
    {
        yield return new WaitForSeconds(2.4f);
        gameObject.SetActive(false);
    }
}
