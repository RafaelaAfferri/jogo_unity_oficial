using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minXViewport = 0.2f;
    public float maxXViewport = 0.8f;
    public float minYViewport = 0.2f;
    public float maxYViewport = 0.8f;
    public float smoothTime = 0.1f;

    private Vector3 velocity = Vector3.zero;
    private Camera cam;
    private float halfHeight;
    private float halfWidth;

    void Awake()
    {
        cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = cam.orthographicSize * cam.aspect;
    }

    void LateUpdate()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(player.position);
        Vector3 targetPos = transform.position;

        if (viewPos.x < minXViewport || viewPos.x > maxXViewport)
        {
            float thresholdX = viewPos.x < minXViewport ? minXViewport : maxXViewport;
            targetPos.x = player.position.x - (thresholdX - 0.5f) * 2f * halfWidth;
        }

        if (viewPos.y < minYViewport || viewPos.y > maxYViewport)
        {
            float thresholdY = viewPos.y < minYViewport ? minYViewport : maxYViewport;
            targetPos.y = player.position.y - (thresholdY - 0.5f) * 2f * halfHeight;
        }

        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}