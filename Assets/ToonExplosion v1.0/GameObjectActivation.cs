using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectActivation : MonoBehaviour
{
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        //gameObject.SetActive(false);
        StartCoroutine("Activate");
        StartCoroutine("Inactivate");

    }
    
    private IEnumerator Activate()
    {
        
        yield return new WaitForSeconds(0.9f);
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<Image>().enabled = false;
        //gameObject.SetActive(true);
        //Vector3 position = thisSceneController.Player.transform.position - thisSceneController.Player.transform.lossyScale / 2;
    }
    private IEnumerator Inactivate()
    {
        yield return new WaitForSeconds(1.8f);
        gameObject.SetActive(false);
    }
}
