using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider VolumeSlider;

    private bool SkipTutorial = false;


    private void Start()
    {
        SetVolume();
    }

    public void PlayGame()
    {
        if (!SkipTutorial)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        AudioListener.volume = VolumeSlider.value;
    }

    public void ToogleSkipTutorial()
    {
        SkipTutorial = !SkipTutorial;
    }


}
