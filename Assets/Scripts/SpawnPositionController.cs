using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionController : MonoBehaviour
{
    public static SpawnPositionController spawnPositionControllerInstance;
    public Transform[] PlayerPositions;
    Vector3[] PlayerWorldPositions;
    public Canvas SpawnCanvas;

    void Start()
    {
        spawnPositionControllerInstance = this;
        CalculatePlayerWorldPositions();
    }

    void CalculatePlayerWorldPositions() {
        PlayerWorldPositions = new Vector3[PlayerPositions.Length];
        for (int i = 0; i < PlayerPositions.Length; i++)
        {
            PlayerWorldPositions[i] = Camera.main.ScreenToWorldPoint(PlayerPositions[i].position);
        }
    }

    public Canvas GetCanvas() {
        return SpawnCanvas;
    }

    public Vector3 GetPlayerSpawnPositionInWorldCoordinates(int PlayerIndex, bool IsUISpace) {
        if (PlayerIndex < PlayerWorldPositions.Length) {
            if (!IsUISpace)
            {
                return new Vector3(PlayerWorldPositions[PlayerIndex].x, PlayerWorldPositions[PlayerIndex].y, 0f);
            }
            else {
                return PlayerPositions[PlayerIndex].position;
            }
        }
        return default;
    }
}
