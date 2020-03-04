using UnityEngine;

public class Buttons : MonoBehaviour
{
    float x1, y1, z1;
    private void Start()
    {
        x1 = transform.localScale.x;
        y1 = transform.localScale.y;
        z1 = transform.localScale.z;
    }
    void OnMouseDown()
    {
        transform.localScale = new Vector3(x1+5f, y1+5f, z1);
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(x1, y1, z1);
    }
}
