using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomComplete : MonoBehaviour
{
    public GameObject button;

    public bool HasNextRoom;

    public void SpawnNextButton()
    {
        button.SetActive(true);
    }

    public void LoadNextRoom()
    {
        if (HasNextRoom)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }


}
