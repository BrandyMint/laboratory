using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadScenes : MonoBehaviour {

	

    public void LoadScene1(int n)
    {
        Application.LoadLevel(n);
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
