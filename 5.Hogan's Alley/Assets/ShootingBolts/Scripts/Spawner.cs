using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawnPrefabs;
    [SerializeField]
    private List<Transform> spawnPoints;

    public float minTime = 0f;
    public float maxTime = 5f;

    private Coroutine coroutineRef;

    private void OnEnable()
    {
        coroutineRef = StartCoroutine(Spawn());
    }
    private void OnDisable()
    {
        StopCoroutine(coroutineRef);
    }

    IEnumerator Spawn()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Instantiate(
                spawnPrefabs[Random.Range(0, spawnPrefabs.Count)],
                spawnPoints[Random.Range(0, spawnPoints.Count)]
            );
        }
    }

    
}
