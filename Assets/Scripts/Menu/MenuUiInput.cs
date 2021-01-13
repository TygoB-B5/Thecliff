using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiInput : MonoBehaviour
{
    public enum Action {Start, Exit};
    public Action action;

    private void OnTriggerEnter(Collider collision)
    {
        UseButton();
    }

    private void UseButton()
    {
    switch(action)
        {
            case Action.Start:
                SceneManager.LoadScene("Game");
                break;
            case Action.Exit:
                Application.Quit();
                break;
        }

        FindObjectOfType<MenuContainerHandler>().EnableUi(false);
    }
}
