using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform respawnPoint;

    public void StartRespawn()
    {
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2f);

        if (respawnPoint != null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
            Debug.Log("Player respawned at checkpoint.");
        }
        else
        {
            Debug.LogError("Respawn point is not set!");
        }
    }
}
