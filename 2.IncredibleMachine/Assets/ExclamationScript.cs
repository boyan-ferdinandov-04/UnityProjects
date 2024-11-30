using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationScript : MonoBehaviour
{
    public GameObject objectToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManagerScript.PlaySound("destroyed");
            if (objectToDestroy != null)
            {
                
                Destroy(objectToDestroy);
                Debug.Log("Object destroyed!");
            }
            else
            {
                Debug.LogWarning("No object assigned to destroy!");
            }
        }
    }
}
