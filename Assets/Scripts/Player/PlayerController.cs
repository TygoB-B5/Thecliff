using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = default;

    private Transform hmd;

    private void Awake()
    {
        hmd = Camera.main.transform;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 forwardDir = new Vector3(hmd.forward.x, 0, hmd.forward.z);
        Vector3 rightDir = new Vector3(hmd.right.x, 0, hmd.right.z);

        transform.position += forwardDir * VRInput.Movement.y * speed * Time.deltaTime;
        transform.position += rightDir * VRInput.Movement.x * speed * Time.deltaTime;
    }
}
