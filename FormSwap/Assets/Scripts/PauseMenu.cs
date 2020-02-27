using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Awake()
    {

    }

    public void ShowPauseMenu()
    {
        if(gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;

        }
        else
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
