using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    private const int MaxRoll = 100; // just over 90 to feel like you're ballancing while knife edging (flying sideways)
    public float Speed = 10;
    private float rotation;

    // Update is called once per frame
    void Update()
    {
        rotation = Mathf.Lerp(rotation, Input.GetAxis("Roll") * MaxRoll, Speed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }
}
