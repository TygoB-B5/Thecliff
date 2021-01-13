using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObjectBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}
