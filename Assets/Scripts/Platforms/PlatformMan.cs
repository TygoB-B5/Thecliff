using UnityEngine;

public class PlatformMan : MonoBehaviour
{
    public static PlatformMan Instance { get; private set; }

    [SerializeField] private GameObject[] PlatOne;
    [SerializeField] private GameObject[] PlatTwo;

    private int currentPlatformPhase = 0;

    void Start()
    {
        if (Instance == null) { Instance = this; } else { Destroy(gameObject); }
        PlatOne = GameObject.FindGameObjectsWithTag("Plat1");
        PlatTwo = GameObject.FindGameObjectsWithTag("Plat2");
    }

    public void TogglePlatOne()
    {
        switch (currentPlatformPhase)
        {
            case 0:
                for (int i = 0; i < PlatOne.Length; i++)
                {
                    PlatOne[i].SetActive(false);
                }
                break;

            case 1:
                for (int i = 0; i < PlatOne.Length; i++)
                {
                    PlatTwo[i].SetActive(true);
                }
                break;

            case 2:
                for (int i = 0; i < PlatTwo.Length; i++)
                {
                    PlatOne[i].SetActive(false);
                }
                break;

            case 3:
                for (int i = 0; i < PlatTwo.Length; i++)
                {
                    PlatOne[i].SetActive(true);
                }
                break;

            case 4:
                for (int i = 0; i < PlatOne.Length; i++)
                {
                    PlatTwo[i].SetActive(false);
                }
                currentPlatformPhase = 0;
                break;
        }
        currentPlatformPhase++;
    }


}
