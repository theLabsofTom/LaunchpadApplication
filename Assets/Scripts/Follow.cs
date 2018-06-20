using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Following;
    public Transform LookAt;
    public float Speed;

    private Rigidbody rb;
    private bool useRb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        useRb = rb != null;
    }

    // Update is called once per frame
    private void Update ()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, Following.position, Time.deltaTime * Speed);
        if (useRb)
        {
            rb.MovePosition(newPosition);
        }
        else
        {
            transform.position = newPosition;
        }
        if (LookAt != null)
        {
            transform.LookAt(LookAt);
        }
	}
}
