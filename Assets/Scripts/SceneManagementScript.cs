using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
