using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private int pointsHit;
    [SerializeField]
    private int pointsLeave;

    public float minTIme = 3.0f;
    public float maxTime = 5.0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.Log("Error with Animator");
        }

        StartCoroutine(WaitTimeUntilDeath(Random.Range(minTIme, maxTime)));

    }

    IEnumerator WaitTimeUntilDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("Die");
        GameManager.Instance.actualPoints += pointsLeave;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("Die");
            GameManager.Instance.actualPoints += pointsHit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
