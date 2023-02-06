using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void QuitButton()
    {
        Application.Quit();
    }

}
