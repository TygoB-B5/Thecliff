using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
    private GameObject leftController, rightController;
    private Rigidbody rb;
    private bool isLeftGrabbing;
    private bool isRightGrabbing;

    private void Awake()
    {
        leftController = GameObject.FindWithTag("LController");
        rightController = GameObject.FindWithTag("RController");

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateInputStates();
        UpdateGrabbing();
    }

    private void UpdateGrabbing()
    {
        if(!CheckBothHands())
            CheckSingleHands();

        CheckNoHands();
    }

    private GameObject GetLatestGrabbed()
    {
        if (leftController.transform.position.y > rightController.transform.position.y)
            return leftController;
        else
            return rightController;
    }

    private void CheckNoHands()
    {
        if (!leftController.GetComponent<HandClimbingTriggerHandler>().canGrab &&
        !rightController.GetComponent<HandClimbingTriggerHandler>().canGrab ||
        !isLeftGrabbing && !isRightGrabbing)
            rb.useGravity = true;
    }

    private void CheckSingleHands()
    {
        if (isLeftGrabbing)
        {
            Grab(leftController);
            return;
        }
        else if (isRightGrabbing)
        {
            Grab(rightController);
            return;
        }
    }

    private bool CheckBothHands()
    {
        if (isLeftGrabbing && isRightGrabbing)
        {
            Grab(GetLatestGrabbed());
            return true;
        }
        return false;
    }

    private void UpdateInputStates()
    {
        if (VRInput.LeftGrab && leftController.GetComponent<HandClimbingTriggerHandler>().canGrab)
            isLeftGrabbing = true;
        if (VRInput.RightGrab && rightController.GetComponent<HandClimbingTriggerHandler>().canGrab)
            isRightGrabbing = true;

        if (VRInput.LeftGrabLetGo)
            isLeftGrabbing = false;
        if (VRInput.RightGrabLetGo)
            isRightGrabbing = false;
    }

    private void Grab(GameObject controllerReference)
    {
        transform.position -= controllerReference.GetComponent<HandClimbingTriggerHandler>().Delta;
        rb.useGravity = false;
    }
}
