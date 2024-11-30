using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool_list = new List<GameObject>();

    [SerializeField]
    private GameObject ref_prefab;

    [SerializeField]
    private int maxNumPoolObjects = 10;


    void Start()
    {

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool_list.Count; i++)
        {
            if (!pool_list[i].activeInHierarchy)
            {
                pool_list[i].SetActive(true);
                StartCoroutine(DelayedDisableBullet(pool_list[i]));
                return pool_list[i];
            }
        }

        GameObject aux;
        if (pool_list.Count < maxNumPoolObjects)
        {
            aux = Instantiate(ref_prefab, transform.position, transform.rotation);
            StartCoroutine(DelayedDisableBullet(aux));
            pool_list.Add(aux);
            return aux;
        }

        return null;
    }


    IEnumerator DelayedDisableBullet(GameObject bulletInstance)
    {
        yield return new WaitForSeconds(3f);
        bulletInstance.SetActive(false);
    }
}