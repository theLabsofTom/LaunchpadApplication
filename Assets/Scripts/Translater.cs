using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translater : MonoBehaviour
{
    public Transform Leader;
    public bool takeVerticalInput = true;

	// Update is called once per frame
	void Update ()
    {
        if (Leader != null)
        {
            if (takeVerticalInput)
            {
                transform.position = (Leader.position + new Vector3(0, Input.GetAxis("Vertical"), 0));
            }
            else
            {
                transform.position = new Vector3(Leader.position.x, transform.position.y, Leader.position.z);
            }
        }
	}
}
