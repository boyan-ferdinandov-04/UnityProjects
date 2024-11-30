using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Animator animator;
    private bool isDead = false;
    private const string hurtSound = "hurt";
    public Respawner respawner;
    void Start()
    {
        animator = GetComponent<Animator>();

        if (respawner == null)
        {
            respawner = FindObjectOfType<Respawner>();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes") && !isDead)
        {
            isDead = true;
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        Debug.Log("Player death triggered.");
        animator.SetTrigger("Death");
        SoundManager.PlaySound(hurtSound);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        if (respawner != null)
        {
            Debug.Log("Notifying respawner to respawn player.");
            respawner.StartRespawn();
        }
        else
        {
            Debug.LogWarning("Respawner is not assigned in PlayerCollision.");
        }

        FindObjectOfType<GameManager>().HandlePlayerDeath();
        Destroy(gameObject);
    }

}
