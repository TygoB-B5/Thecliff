using UnityEngine;
using System;

public class PlayerFall : MonoBehaviour
{
    public event Action OnHitGround = delegate { };

    private PlayerJump playerJump;

    private Vector3 rand;
    private bool isFalling = false;

    private void Awake()
    {
        playerJump = GetComponent<PlayerJump>();
    }

    private void Start()
    {
        rand = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }

    void Update()
    {
        RotatePlayer();
        CheckIfHitGround();
    }

    private void RotatePlayer()
    {
        if (GetComponent<Rigidbody>().velocity.y < -10)
        {
            isFalling = true;
            float v = (GetComponent<Rigidbody>().velocity.y - 5);
            transform.Rotate(rand * Mathf.Pow(v * 0.25f, 2) * Time.deltaTime);
        }
    }

    private void CheckIfHitGround()
    {
        if (isFalling && playerJump.IsGrounded)
        {
            isFalling = false;
            OnHitGround();
        }
    }
}
