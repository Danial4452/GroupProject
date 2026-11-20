using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [Header("Follow")]
    public float smoothSpeed = 5f;
    public float offsetY = 1f;

    [Header("Camera Boundaries")]
    public float minX = -5f;
    public float maxX = 50f;

    private Camera cam;
    private float fixedY;
    private float fixedZ;

    void Start()
    {
        cam = GetComponent<Camera>();
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float halfWidth =
            cam.orthographicSize * cam.aspect;

        float leftLimit = minX + halfWidth;
        float rightLimit = maxX - halfWidth;

        float targetX;

        if (leftLimit > rightLimit)
        {
            targetX = (minX + maxX) / 2f;
        }
        else
        {
            targetX = Mathf.Clamp(
                target.position.x,
                leftLimit,
                rightLimit
            );
        }

        Vector3 desiredPosition = new Vector3(
            targetX,
            fixedY,
            fixedZ
        );

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            1f - Mathf.Exp(-smoothSpeed * Time.deltaTime)
        );
    }
}