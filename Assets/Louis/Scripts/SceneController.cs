using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ToGameplay()
    {
        SceneManager.LoadScene(1);
    }
    public void ToCredit()
    {
        SceneManager.LoadScene(2);
    }
    public void ToExit()
    {
        Application.Quit();
    }
}
