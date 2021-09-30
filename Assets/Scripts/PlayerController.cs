using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float turnSpeed;
    [SerializeField] private float xValueToClamp;
    [SerializeField] private float yValueToClamp;
    [SerializeField] private float positionPitchFactor = -1f;
    [SerializeField] private float controlPitchFactor = -20f;
    [SerializeField] private float positionRollFactor = -20f;
    [SerializeField] private float positionYawFactor = 2f;
    [Tooltip("In ms^-1")] [SerializeField] private float speed;

    private float _xThrow, _yThrow;
    
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        Vector3 localPos = transform.localPosition;
        
        float pitch = localPos.y * positionPitchFactor + _yThrow * controlPitchFactor;
        float yaw = localPos.x * positionYawFactor;
        //float roll = localPos.x * positionRollFactor + _xThrow * controlRollFactor;
        float roll = _xThrow * positionRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
        Vector3 localPos = transform.localPosition;

        _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        _yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = _yThrow * speed * Time.deltaTime;
        float rawYPos = localPos.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yValueToClamp, yValueToClamp);

        float xOffset = _xThrow * speed * Time.deltaTime;
        float rawXPos = localPos.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xValueToClamp, xValueToClamp);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, localPos.z);

        //transform.Rotate(Vector3.forward, Time.deltaTime * turnSpeed * horizontalThrow);
        //transform.Rotate(Vector3.right, Time.deltaTime * turnSpeed * verticalThrow);
    }

    private void OnCollisionEnter(Collision other)
    {
        print("Player collided Something");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Player Triggered Something");
    }
}
