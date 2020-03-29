using UnityEngine;
using System.Collections;
using System;
public class DynamiteMovement : MonoBehaviour
{
    [SerializeField] float DynamiteSpeed;
    [SerializeField] float RotationSpeed;
    private GameObject ForRay;

    private void Start()
    {
        StartCoroutine(SlowScale());
        ForRay = GameObject.Find("ForRay");
        ForRay.GetComponent<TimeDilation>().Fast();
    }
    void Update()
    {
        transform.Translate(0, DynamiteSpeed * Time.deltaTime, 0, Space.World);
        transform.Rotate(0, 0, RotationSpeed);
    }
    IEnumerator SlowScale()
    {
        for (float q = 1f; q < 2.0f; q += .03f)
        {
            transform.localScale = new Vector3(q, q, q);
            yield return new WaitForSeconds(.02f);
        }
        yield return new WaitForSeconds(0.1f);
        for (float q = 1.9f; q > 1.5f; q -= .03f)
        {
            transform.localScale = new Vector3(q, q, q);
            yield return new WaitForSeconds(.02f);
        }
    }
}

