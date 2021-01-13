using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class PlayerInstantiate : MonoBehaviour
{
    private void Start()
    {
        if (SteamVR.active)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("VrRig"));
            XRSettings.gameViewRenderMode = GameViewRenderMode.None;
            SteamVR.settings.autoEnableVR = false;
            SteamVR.enabled = false;
        }
    }
}
