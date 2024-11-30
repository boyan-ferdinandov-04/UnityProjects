using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public float yOffset = 0f; 

    void LateUpdate()
    {
        if (player == null)
        {
            FindPlayer();
        }

        if (player != null)
        {
            Vector3 currentPos = transform.position;
            Vector3 targetPos = new Vector3(currentPos.x, player.position.y + yOffset, currentPos.z);
            transform.position = Vector3.Lerp(currentPos, targetPos, smoothSpeed);
        }
    }

    private void FindPlayer()
    {
        GameObject newPlayer = GameObject.FindGameObjectWithTag("Player");
        if (newPlayer != null)
        {
            player = newPlayer.transform;
        }
    }
}
