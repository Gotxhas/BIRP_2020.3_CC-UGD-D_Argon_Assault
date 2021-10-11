using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("Set In Inspector - General")]
    [Tooltip("In ms^-1")] [SerializeField] private float speed;
    [SerializeField] private float xRange;
    [SerializeField] private float yRange;
    [SerializeField] private ParticleSystem[] guns;
    
    [Header("Set In Inspector - Screen-Position Based")]
    [SerializeField] private float positionPitchFactor = -1f;
    [SerializeField] private float positionYawFactor = 2f;
    
    [Header("Set In Inspector - Control-throw Based")]
    [SerializeField] private float controlRollFactor = -20f;
    [SerializeField] private float controlPitchFactor = -20f;
    
    private float _xThrow, _yThrow;
    private bool _isControlEnable = true;
    
    // Update is called once per frame
    void Update()
    {
        if (_isControlEnable)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }
    
    private void ProcessRotation()
    {
        Vector3 localPos = transform.localPosition;
        
        float pitch = localPos.y * positionPitchFactor + _yThrow * controlPitchFactor;
        float yaw = localPos.x * positionYawFactor;
        float roll = _xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
        Vector3 localPos = transform.localPosition;

        _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        _yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = _yThrow * speed * Time.deltaTime;
        float rawYPos = localPos.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        float xOffset = _xThrow * speed * Time.deltaTime;
        float rawXPos = localPos.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, localPos.z);
    }
    
    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {

            SetGunsActive(true);

        }

        else
        {
            SetGunsActive(false);
        }
    }
    
    private void SetGunsActive(bool isActive)
    {
        foreach (var gun in guns)
        {
            var emission = gun.emission;
            emission.enabled = isActive;
        }
    }
    

    
    private void OnPlayerDeath() //called by string reference
    {
        _isControlEnable = false;
    }
    
}
