using UnityEngine;

public class ParticleFollowPlayer : MonoBehaviour
{
    private CapsuleCollider col;

    private void Awake()
    {
        col = GetComponentInParent<CapsuleCollider>();
    }

    private void Update()
    {
        transform.localPosition = new Vector3(col.center.x, transform.localPosition.y, col.center.z);
    }
}
