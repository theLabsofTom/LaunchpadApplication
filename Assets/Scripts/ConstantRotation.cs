using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {

    public float Speed;
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation *= Quaternion.Euler(Speed * Time.deltaTime, 0,0);
	}
}
