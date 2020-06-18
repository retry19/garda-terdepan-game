using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        Application.LoadLevel(scene);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
