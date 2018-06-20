using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlyAfter : MonoBehaviour
{
    [Tooltip("The target to fly after")]
    public Transform Target;
    [Tooltip("The speed you can fly in a straight line.")]
    public float FlySpeed;
    [Tooltip("The speed at which you can turn")]
    public float TurnSpeed;
    [Tooltip("The higher this is, the less speed you lose when you turn")]
    [Range(1,float.MaxValue)]
    public float Manuverability;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();	
	}
	
	void Update ()
    {
        Quaternion directionToTarget = Quaternion.LookRotation((Target.position - transform.position).normalized);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, directionToTarget, Time.deltaTime * TurnSpeed));
        float angleToTarget = Quaternion.Angle(directionToTarget, transform.rotation);
        float turningPenalty = angleToTarget / Manuverability;
        turningPenalty = Mathf.Clamp(turningPenalty, 1, float.MaxValue);
        rb.MovePosition((transform.forward * (FlySpeed / turningPenalty) * Time.deltaTime) + transform.position);
	}
}
