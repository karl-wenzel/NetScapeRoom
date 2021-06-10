using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionController : MonoBehaviour
{
    public static SpawnPositionController spawnPositionControllerInstance;
    public Transform[] PlayerPositions;
    Vector3[] PlayerWorldPositions;

    void Start()
    {
        spawnPositionControllerInstance = this;
        CalculatePlayerWorldPositions();
    }

    void CalculatePlayerWorldPositions() {
        PlayerWorldPositions = new Vector3[PlayerPositions.Length];
        for (int i = 0; i < PlayerPositions.Length; i++)
        {
            PlayerWorldPositions[i] = Camera.main.ScreenToWorldPoint(PlayerWorldPositions[i]);
        }
    }

    public Vector3 GetPlayerSpawnPositionInWorldCoordinates(int PlayerIndex) {
        if (PlayerIndex < PlayerWorldPositions.Length) {
            return PlayerWorldPositions[PlayerIndex];
        }
        return default;
    }
}
