using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DisablePauseOnStartScene : MonoBehaviour
{
    public void DisablePauseButton()
    {
        StartCoroutine(DisableDelay());
        
    }
    public void EnablePauseButton()
    {
        GetComponent<Image>().enabled = true;
        GetComponent<Button>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
    
    IEnumerator DisableDelay()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().enabled = false;
        GetComponent<Button>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex < 2)
        {
            DisablePauseButton();
        }
    }
    
}
