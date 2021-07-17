using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameEventStartMinigame[] StartMinigames;
    public int PlayerIndex;
    public bool Clickable = true;
    public bool EnableRotation = false;

    public void Clicked() {
        if (!Clickable) return;
        Debug.Log("Clicked on " + name);
        StartAvailableMinigames();
    }

    public void Activate() {
        GetComponent<SpriteRenderer>().color = Color.white;
        Clickable = true;
    }

    public void AddMinigame(GameEventStartMinigame minigame)
    {
        StartMinigames[0] = minigame;
    }

    void StartAvailableMinigames() {
        foreach (GameEventStartMinigame MiniGameEvent in StartMinigames)
        {
            bool IsUIGame = MiniGameEvent.MinigamePrefab.GetComponent<MinigameWindow>().InstantiateInUISpace;
            GameObject NewMinigame = Instantiate
                (MiniGameEvent.MinigamePrefab, 
                SpawnPositionController.spawnPositionControllerInstance.GetPlayerSpawnPositionInWorldCoordinates(PlayerIndex, IsUIGame), 
                Quaternion.identity);
            if (IsUIGame) {
                NewMinigame.transform.SetParent(SpawnPositionController.spawnPositionControllerInstance.GetCanvas().transform);
                float scaleFactor = (Screen.height + Screen.width) / 1200f;
                NewMinigame.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
            }
            MinigameWindow NewMinigameWindow = NewMinigame.GetComponent<MinigameWindow>();

            if (EnableRotation)
            {
                for (int i = 0; i < PlayerIndex; i++)
                {
                    NewMinigameWindow.Rotate();
                }
            }

            MinigameController NewMinigameController = NewMinigameWindow.minigameController;
            NewMinigameController.MinigameSource = gameObject;
        }
    }
}
