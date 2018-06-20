using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSwapper : MonoBehaviour
{
    public FlyAfter flyScript;
    public Transform[] Targets;
    [Tooltip("The index of the target to start on")]
    public int StartTargetIndex;
    private int index;

	// Use this for initialization
	void Start ()
    {
        index = StartTargetIndex;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("TurnLeft"))
        {
            if (++index >= Targets.Length)
            {
                index = 0;
            }
            flyScript.Target = Targets[index];
        }
        if (Input.GetButtonDown("TurnRight"))
        {
            if (--index < 0)
            {
                index = Targets.Length - 1;
            }
            flyScript.Target = Targets[index];
        }
    }
}
