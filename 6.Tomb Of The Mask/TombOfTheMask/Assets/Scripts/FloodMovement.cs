using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodMovement : MonoBehaviour
{
    public float moveAmount = 0.5f;
    public float moveInterval = 2f;
    private Vector3 moveDirection = Vector3.up;
    void Start()
    {
        StartCoroutine(MoveFlood());
    }

    private IEnumerator MoveFlood()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveInterval);
            MoveUp();
        }
    }

    private void MoveUp()
    {
        transform.Translate(moveDirection * moveAmount);
        
    }

    void Update()
    {
        
    }
}
