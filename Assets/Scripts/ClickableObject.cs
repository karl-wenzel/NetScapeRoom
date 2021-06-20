using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameEventStartMinigame[] StartMinigames;
    public int PlayerIndex;

    public void Clicked() {
        Debug.Log("Clicked on " + name);
        StartAvailableMinigames();
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
                NewMinigame.transform.parent = SpawnPositionController.spawnPositionControllerInstance.GetCanvas().transform;
            }
            MinigameWindow NewMinigameWindow = NewMinigame.GetComponent<MinigameWindow>();
            for (int i = 0; i < PlayerIndex; i++)
            {
                NewMinigameWindow.Rotate();
            }
            MinigameController NewMinigameController = NewMinigameWindow.minigameController;
            NewMinigameController.MinigameSource = gameObject;
        }
    }
}