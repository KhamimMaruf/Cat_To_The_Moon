using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform; // Camera utama
    public float parallaxEffect = 0.5f; // 0 = diam, 1 = sama cepat kamera

    private Vector3 lastCameraPosition;

    void Start()
    {
        if(cameraTransform != null)
            lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        if(cameraTransform != null)
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * parallaxEffect, deltaMovement.y * parallaxEffect, 0);
            lastCameraPosition = cameraTransform.position;
        }
    }
}
