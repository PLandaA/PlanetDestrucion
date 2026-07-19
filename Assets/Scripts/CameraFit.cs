using UnityEngine;

/// <summary>Keeps the full play area visible on any aspect ratio (WebGL runs on many screens).</summary>
[RequireComponent(typeof(Camera))]
public class CameraFit : MonoBehaviour
{
    [SerializeField] float minHalfWidth = 8.4f;
    [SerializeField] float minHalfHeight = 5f;

    Camera cam;

    void Awake ()
    {
        cam = GetComponent<Camera>();
    }

    void Update ()
    {
        // Browser windows resize and phones rotate, so keep this in sync.
        float needed = Mathf.Max(minHalfHeight, minHalfWidth / cam.aspect);
        if (!Mathf.Approximately(cam.orthographicSize, needed))
        {
            cam.orthographicSize = needed;
        }
    }
}
