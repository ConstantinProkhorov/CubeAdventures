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
        int a = 1;
        while (a > 0)
        {
            int n = 1;
            while (n < 3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ClosedEyeRenderrer;
                yield return new WaitForSeconds(0.1f);
                gameObject.GetComponent<SpriteRenderer>().sprite = OpenEyeRenderrer;
                yield return new WaitForSeconds(3f);
                n += 1;
            }
            while (n > 2 & n < 5)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ClosedEyeRenderrer;
                yield return new WaitForSeconds(0.1f);
                gameObject.GetComponent<SpriteRenderer>().sprite = OpenEyeRenderrer;
                yield return new WaitForSeconds(0.2f);
                gameObject.GetComponent<SpriteRenderer>().sprite = ClosedEyeRenderrer;
                yield return new WaitForSeconds(0.1f);
                gameObject.GetComponent<SpriteRenderer>().sprite = OpenEyeRenderrer;
                yield return new WaitForSeconds(2f);
                n += 1;
            }
        }
    }
}
