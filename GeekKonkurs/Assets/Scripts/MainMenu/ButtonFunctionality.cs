using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{
    public GameObject OptionsPanel;

    public void StartGame() {
        SceneManager.LoadScene((int)Scenes.MAIN_GAME);
    }

    public void Options() {
        OptionsPanel.SetActive(true);
    }

    public void ExitGame() {
        Application.Quit();
    }
}

public enum Scenes {
    MAIN_MENU,
    MAIN_GAME
}
