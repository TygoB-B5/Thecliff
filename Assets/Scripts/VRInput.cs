using UnityEngine;
using Valve.VR;

public class VRInput : MonoBehaviour
{
    public SteamVR_Action_Vector2 touchPad;
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean locPush;
    public SteamVR_Action_Boolean grab;

    public static Vector2 Movement { get; private set; }
    public static bool Jump { get; private set; }
    public static bool OpenMenu { get; private set; }
    public static bool LeftGrab { get; private set; }
    public static bool RightGrab { get; private set; }
    public static bool LeftGrabLetGo { get; private set; }
    public static bool RightGrabLetGo { get; private set; }

    private void Update()
    {
        if(touchPad.GetAxis(SteamVR_Input_Sources.Any) != Vector2.zero)
            Movement = touchPad.GetAxis(SteamVR_Input_Sources.Any);

        Jump = trigger[SteamVR_Input_Sources.Any].stateDown;
        OpenMenu = locPush[SteamVR_Input_Sources.Any].stateDown;
        LeftGrab = grab[SteamVR_Input_Sources.LeftHand].stateDown;
        RightGrab = grab[SteamVR_Input_Sources.RightHand].stateDown;

        LeftGrabLetGo = grab[SteamVR_Input_Sources.LeftHand].stateUp;
        RightGrabLetGo = grab[SteamVR_Input_Sources.RightHand].stateUp;
    }
}
