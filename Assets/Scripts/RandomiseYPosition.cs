using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseYPosition : MonoBehaviour
{

    public float Max;
    public float Min;

    // Use this for initialization
    void Start()
    {
        transform.position += new Vector3(Random.Range(Min, Max), 0);
    }
}
