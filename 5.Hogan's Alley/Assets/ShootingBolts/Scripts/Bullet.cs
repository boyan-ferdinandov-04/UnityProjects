using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private AudioClip fireSound;


    private ParticleSystem ps;
    private Rigidbody rb;
    private AudioSource audioSource;
    // Start is called before the first frame update
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.Log("World will explode.");
        }
        else
        {
            audioSource.PlayOneShot(fireSound);
        }
        ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {
            Debug.Log("Mem");
        }
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        ps.Play();
    }

    public void Shoot(Vector3 direction)
    {
        if (rb != null)
        {
            rb.AddForce(direction, ForceMode.Impulse);
        }
    }
}
