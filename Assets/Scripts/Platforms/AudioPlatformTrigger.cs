using System.Collections;
using UnityEngine;

public class AudioPlatformTrigger : MonoBehaviour
{
    private AudioSource aud;
    private int currentBar;

    private const float bpmInSeconds = 6.620689655172414f;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        Trigger();
        ResetLoop();
    }

    private void ResetLoop()
    {
        aud.Play();

        currentBar = 0;

        //start bpm trigger loop
        StartCoroutine(BpmTrigger());
    }

    private IEnumerator BpmTrigger()
    {
        yield return new WaitForSecondsRealtime(0.01f);

        while (currentBar < 14)
        {
            yield return new WaitForSecondsRealtime(bpmInSeconds - 0.7f);
            EarlyTrigger();
            yield return new WaitForSecondsRealtime(0.7f);
            Trigger();

            currentBar++;
        }

        //reset loop
        ResetLoop();
        yield return null;
    }

    private void EarlyTrigger()
    {
        //triggers 0.7 sec before every bar
        FindObjectOfType<PlatformMan>().TogglePlatOne();
    }

    private void Trigger()
    {
        //triggers every bar
        FindObjectOfType<PlatformMan>().TogglePlatOne();
    }
}
