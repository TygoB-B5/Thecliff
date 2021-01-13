using UnityEngine;

public class MenuContainerHandler : MonoBehaviour
{
    private Transform hmd;
    private GameObject[] uiButtons;

    private void Awake()
    {
        hmd = Camera.main.transform;
        uiButtons = GameObject.FindGameObjectsWithTag("UiButton");
    }

    private void Update()
    {
        if (VRInput.OpenMenu)
            EnableUi(true);
    }

    public void EnableUi(bool enable)
    {
        if (enable)
            SetToForwardDirection();

        for (int i = 0; i < uiButtons.Length; i++)
            uiButtons[i].SetActive(enable);
    }

    private void SetToForwardDirection()
    {
            Vector3 forwardDir = new Vector3(hmd.forward.x, 0, hmd.forward.z);
            transform.position = hmd.position + forwardDir * 0.7f;
            transform.rotation = Quaternion.LookRotation(forwardDir);
    }
}
