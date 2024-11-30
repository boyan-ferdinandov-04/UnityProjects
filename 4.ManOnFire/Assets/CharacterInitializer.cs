using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInitializer : MonoBehaviour
{
    public GameObject manOnFire;
    public Vector3 spawnPoint = Vector3.zero; 
    public float spawnRange = 10f;
    public CinemachineVirtualCamera virtualCamera;
    void Start()
    {
        if (manOnFire != null)
        {
 
            manOnFire.SetActive(true);


            Vector3 randomPosition = new Vector3(
                spawnPoint.x + Random.Range(-spawnRange, spawnRange),
                spawnPoint.y + Random.Range(-spawnRange, spawnRange),
                spawnPoint.z + Random.Range(-spawnRange, spawnRange)
            );

            Quaternion randomRotation = Quaternion.Euler(
                Random.Range(0f, 360f),
                Random.Range(0f, 360f),
                Random.Range(0f, 360f)
            );

            manOnFire.transform.position = randomPosition;
            manOnFire.transform.rotation = randomRotation;
            virtualCamera.Follow = manOnFire.transform;
        }
    }
}
