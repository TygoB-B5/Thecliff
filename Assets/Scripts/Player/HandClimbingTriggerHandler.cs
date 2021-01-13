using UnityEngine;

public class HandClimbingTriggerHandler : MonoBehaviour
{
    public Transform controllerPositionReference;

    public Transform grabObject { get; private set; }
    public bool canGrab { get; private set; }
    public Vector3 Delta { get; private set; }

    private Vector3 lastPos;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Climable")
        {
            canGrab = true;
            grabObject = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canGrab = false;
        grabObject = null;
    }

    private void Start()
    {
        lastPos = controllerPositionReference.localPosition;
    }

    private void Update()
    {
        Delta = controllerPositionReference.localPosition - lastPos;
    }

    private void LateUpdate()
    {
        lastPos = controllerPositionReference.localPosition;
    }
}
