using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Flap : MonoBehaviour
{
    private Rigidbody rb;
    private bool allowFlap = true;
    private float wingResistance = 8f;
    private float timeBetweenFlaps = 0.2f;

    [SerializeField]
    [Tooltip("The total magnitide of the force applied to each")]
    private float flapPower = 150;
    [SerializeField]
    [Tooltip("The speed that must be attained in order to glide comfortably without needing to flap")]
    private float glideSpeed;
    [SerializeField]
    [Tooltip("The maximum angle that this is allowed to roll to.")]
    private float maxRoll;
    [SerializeField]
    [Tooltip("The maximum angle that this is allowed to pitch to.")]
    private float maxPitch;
    [SerializeField]
    private float rollSpeed;
    [SerializeField]
    private float pitchSpeed;
    [SerializeField]
    private float yawSpeed;

    public Vector3 forwardAxis;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ElevationAndStrafe();
        Rotation();
    }

    private void ElevationAndStrafe()
    {
        var verticalAxis = Input.GetAxis("Vertical"); // How much of the force of each flap goes into propelling the bird forwards.
        var horizontalAxis = Input.GetAxis("Horizontal"); // How much of the force of each flap does into propelling the bird sideways.
        Vector3 upVector = transform.up * (2 - (Mathf.Abs(verticalAxis) + Mathf.Abs(horizontalAxis))); // the amount you travel upwards scales down the more you try to travel sideways/ forwards.
        upVector += transform.forward * 0.01f; // Birds can't take off perfectly vertically.
        if (Input.GetButtonDown("Jump"))
        {
            FlapWings(verticalAxis, horizontalAxis, upVector);
        }
        else
        {
            ApplyGravity();
        }
    }

    private void FlapWings(float verticalAxis, float horizontalAxis, Vector3 upVector)
    {
        //TODO!!! Play animation
        if (allowFlap)
        {
            Vector3 forwardVector = transform.forward * verticalAxis;
            Vector3 rightVector = transform.right * horizontalAxis;
            rb.AddForce(((upVector + forwardVector + rightVector).normalized * flapPower) + Physics.gravity);
            Invoke("AllowFlap", timeBetweenFlaps);
            allowFlap = false;
        }
    }

    private void ApplyGravity()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        float wingEffectiveness = Mathf.Clamp(localVelocity.z / glideSpeed, 0, 1); // Your wings don't keep you up if you're flying too slowly.
        rb.AddForce(Physics.gravity + (transform.up * wingResistance * wingEffectiveness), ForceMode.Acceleration);
    }

    private void Rotation()
    {
        var input = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")).normalized; // without this normalised vector2, diagonal input comes out with a higher magnitude than straight input

        transform.rotation = Quaternion.Euler(-input.x * Time.deltaTime * rollSpeed * transform.forward) *
                        Quaternion.Euler(input.y * Time.deltaTime * pitchSpeed * transform.right) *
                        Quaternion.Euler(Input.GetAxis("Yaw") * Time.deltaTime * yawSpeed *transform.up) *
                        transform.rotation;
    }

    private void AllowFlap()
    {
        allowFlap = true;
    }
}
