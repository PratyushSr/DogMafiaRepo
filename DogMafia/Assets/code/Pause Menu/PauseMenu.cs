using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool _GamePaused = false;
    public GameObject _PauseMenuUI;

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(_GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        _PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _GamePaused = false;
    }

    void Pause()
    {
        _PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _GamePaused = true;
    }
}
