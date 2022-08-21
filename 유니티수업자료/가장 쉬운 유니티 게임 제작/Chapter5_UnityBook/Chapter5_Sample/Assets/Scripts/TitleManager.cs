using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
	
    public void GameQuit()
    {
        Application.Quit();
    }
}
