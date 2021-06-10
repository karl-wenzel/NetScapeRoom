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
            GameObject NewMinigame = Instantiate
                (MiniGameEvent.MinigamePrefab, 
                SpawnPositionController.spawnPositionControllerInstance.GetPlayerSpawnPositionInWorldCoordinates(PlayerIndex), 
                Quaternion.identity);
        }
    }
}
