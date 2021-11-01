using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScripts : MonoBehaviour
{
    public void ShiftScene(int sceneNomer)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneNomer);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
