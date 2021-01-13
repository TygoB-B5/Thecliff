using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private bool isJumping;
    [SerializeField] private float jumpForce = default;

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        IsGrounded = CheckIfGrounded();

        if (VRInput.Jump && IsGrounded)
            Jump();
    }

    private bool CheckIfGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, transform.localScale.y + 0.1f))
            return true;
        else
            return false;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isJumping)
            return;

        GetComponentInChildren<ParticleSystem>().Play();
        isJumping = false;
    }
}
