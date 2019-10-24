using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadScene1(int n)
    {
        SceneManager.LoadScene(n, LoadSceneMode.Single);
    }
    public void LoadSceneMain()
    {
        Application.LoadLevel(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
