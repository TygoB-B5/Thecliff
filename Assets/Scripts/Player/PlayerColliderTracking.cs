using UnityEngine;

public class PlayerColliderTracking : MonoBehaviour
{
    private CapsuleCollider col;
    private Camera cam;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        col.center = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y / 2, cam.transform.localPosition.z);
        col.height = cam.transform.localPosition.y;
    }
}
