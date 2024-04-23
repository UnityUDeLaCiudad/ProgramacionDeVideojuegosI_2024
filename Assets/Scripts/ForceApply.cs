using System;
using UnityEngine;

public class ForceApply : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Vector3 forceDirection;
    [SerializeField] private float forceIntensity;
    [SerializeField] private ForceMode forceMode;

    [SerializeField] private Vector3 torqueDirection;
    [SerializeField] private float torqueIntensity;

    private Vector3 pendingForce;

    private void FixedUpdate()
    {
        myRigidbody.AddForce(pendingForce);
        pendingForce = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 forceToApply = forceDirection * (forceIntensity * Time.deltaTime);
            pendingForce += forceToApply;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 torqueToApply = torqueDirection * torqueIntensity;
            myRigidbody.AddTorque(torqueToApply, forceMode);
        }
    }
}