using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeCarController : MonoBehaviour
{
    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;
    private bool isBraking;
    private bool isDrifting;

    [Header("Car Settings")]
    public float motorForce = 1500f;
    public float brakeForce = 3000f;
    public float maxSteerAngle = 25f;
    public float driftFriction = 0.3f;

    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheel, frontRightWheel;
    public WheelCollider rearLeftWheel, rearRightWheel;

    [Header("Wheel Transforms")]
    public Transform frontLeftTransform, frontRightTransform;
    public Transform rearLeftTransform, rearRightTransform;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Lower center of mass to reduce flipping
        rb.centerOfMass = new Vector3(0f, -0.6f, 0f);

        SetupFriction();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBraking = Input.GetKey(KeyCode.Space);
        isDrifting = Input.GetKey(KeyCode.LeftShift); // Drift when holding shift
    }

    private void HandleMotor()
    {
        // Apply motor torque
        frontLeftWheel.motorTorque = verticalInput * motorForce;
        frontRightWheel.motorTorque = verticalInput * motorForce;

        // Apply brake force
        float appliedBrake = isBraking ? brakeForce : 0f;
        frontLeftWheel.brakeTorque = appliedBrake;
        frontRightWheel.brakeTorque = appliedBrake;
        rearLeftWheel.brakeTorque = appliedBrake;
        rearRightWheel.brakeTorque = appliedBrake;

        // Apply drift
        ApplyDrift(isDrifting);
    }

    private void HandleSteering()
    {
        float speed = rb.linearVelocity.magnitude;
        float steerLimit = Mathf.Clamp01(1f - (speed / 50f));
        float adjustedSteer = maxSteerAngle * steerLimit;

        float steerAngle = adjustedSteer * horizontalInput;
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;
    }

    private void UpdateWheels()
    {
        UpdateWheelPose(frontLeftWheel, frontLeftTransform);
        UpdateWheelPose(frontRightWheel, frontRightTransform);
        UpdateWheelPose(rearLeftWheel, rearLeftTransform);
        UpdateWheelPose(rearRightWheel, rearRightTransform);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }

    private void SetupFriction()
    {
        SetFriction(frontLeftWheel, 2.0f);
        SetFriction(frontRightWheel, 2.0f);
        SetFriction(rearLeftWheel, 2.0f);
        SetFriction(rearRightWheel, 2.0f);
    }

    private void SetFriction(WheelCollider wheel, float stiffness)
    {
        WheelFrictionCurve f = wheel.sidewaysFriction;
        f.extremumSlip = 0.3f;
        f.asymptoteSlip = 0.5f;
        f.stiffness = stiffness;
        wheel.sidewaysFriction = f;
    }

    private void ApplyDrift(bool drifting)
    {
        float driftStiffness = drifting ? driftFriction : 2.0f;

        SetFriction(rearLeftWheel, driftStiffness);
        SetFriction(rearRightWheel, driftStiffness);
    }
}