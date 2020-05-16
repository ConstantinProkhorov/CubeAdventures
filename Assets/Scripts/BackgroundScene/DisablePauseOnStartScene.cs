using UnityEngine;
using UnityEngine.UI;
public class DisablePauseOnStartScene : MonoBehaviour
{
    public void DisablePauseButton()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<Button>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
    public void EnablePauseButton()
    {
        GetComponent<Image>().enabled = true;
        GetComponent<Button>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
}
