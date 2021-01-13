using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 beginPosition;

    private void Awake()
    {
        GetComponent<PlayerFall>().OnHitGround += RespawnToBeginning;
    }

    private void RespawnToBeginning()
    {
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        transform.position = beginPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.GetComponentInChildren<ParticleSystem>().Play();
    }
}
