using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string CoinSound = "coin";
    [SerializeField] 
    private int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.PlaySound(CoinSound);
            FindObjectOfType<GameManager>().CollectCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
