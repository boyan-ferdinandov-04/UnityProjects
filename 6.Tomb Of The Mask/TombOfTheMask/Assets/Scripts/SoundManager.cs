using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static AudioClip pickupCoin;
    private static AudioClip jump;
    private static AudioClip hurt;
    private static AudioSource audioSrc;

    void Start()
    {
        pickupCoin = Resources.Load<AudioClip>(nameof(pickupCoin));
        jump = Resources.Load<AudioClip>(nameof(jump));
        hurt = Resources.Load<AudioClip>(nameof(hurt));
        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coin":
                audioSrc.PlayOneShot(pickupCoin);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurt);
                break;
        }
    }
}
