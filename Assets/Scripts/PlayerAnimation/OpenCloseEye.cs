using System.Collections;
using UnityEngine;

public class OpenCloseEye : MonoBehaviour // открывает и закрывает глаза
{
    Sprite ClosedEyeRenderrer;
    Sprite OpenEyeRenderrer;

    void Start()
    {
        GameObject ClosedEye = Resources.Load<GameObject>("Forms/NewLeftEyeClosed") as GameObject;
        GameObject OpenEye = Resources.Load<GameObject>("Forms/NewLeftEye") as GameObject;

        ClosedEyeRenderrer = ClosedEye.GetComponent<SpriteRenderer>().sprite;
        OpenEyeRenderrer = OpenEye.GetComponent<SpriteRenderer>().sprite;
        
        StartCoroutine(EyeChange());
    }
    public IEnumerator EyeChange()
    {
        for(; ; )
        {
            int BlinkNumber = 1;
            while (BlinkNumber < 3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ClosedEyeRenderrer;
                yield return new WaitForSeconds(0.1f);
                gameObject.GetComponent<SpriteRenderer>().sprite = OpenEyeRenderrer;
                yield return new WaitForSeconds(3f);
                BlinkNumber += 1;
            }
            while (BlinkNumber > 2 & BlinkNumber < 5)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ClosedEyeRenderrer;
                yield return new WaitForSeconds(0.1f);
                gameObject.GetComponent<SpriteRenderer>().sprite = OpenEyeRenderrer;
                yield return new WaitForSeconds(0.2f);
                gameObject.GetComponent<SpriteRenderer>().sprite = ClosedEyeRenderrer;
                yield return new WaitForSeconds(0.1f);
                gameObject.GetComponent<SpriteRenderer>().sprite = OpenEyeRenderrer;
                yield return new WaitForSeconds(2f);
                BlinkNumber += 1;
            }
        }
    }
}
