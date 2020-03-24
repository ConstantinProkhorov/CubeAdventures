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
        yield return new WaitForSeconds(0.9f);
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<Image>().enabled = false;
    }
    private IEnumerator Inactivate()
    {
        yield return new WaitForSeconds(1.8f);
        gameObject.SetActive(false);
    }
}
