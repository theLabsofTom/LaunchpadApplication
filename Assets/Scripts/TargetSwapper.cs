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
    private bool ignoreAxis;

    // Use this for initialization
    void Start()
    {
        index = StartTargetIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("ControllerTurn") < 0 && !ignoreAxis)
        {
            ignoreAxis = true;
            NextIndex();
        }
        if (Input.GetAxis("ControllerTurn") > 0 && !ignoreAxis)
        {
            ignoreAxis = true;
            PreviousIndex();
        }
        if (Input.GetAxis("ControllerTurn") == 0)
        {
            ignoreAxis = false;
        }
        if (Input.GetButtonDown("TurnLeft"))
        {
            NextIndex();
        }
        if (Input.GetButtonDown("TurnRight"))
        {
            PreviousIndex();
        }
    }

    private void PreviousIndex()
    {
        if (--index < 0)
        {
            index = Targets.Length - 1;
        }
        flyScript.Target = Targets[index];
    }

    private void NextIndex()
    {
        if (++index >= Targets.Length)
        {
            index = 0;
        }
        flyScript.Target = Targets[index];
    }
}
