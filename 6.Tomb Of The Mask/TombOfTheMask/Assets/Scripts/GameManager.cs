using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI heightText;
    public TextMeshProUGUI bestHeightText;
    public TextMeshProUGUI timeText;
    public Transform player;
    private int coinsCollected;
    private float bestHeight;
    private float currentTime;

    private void Start()
    {
        bestHeight = PlayerPrefs.GetFloat("BestHeight", 0f);
        UpdateBestHeightUI();
        UpdateCoinUI();
    }

    private void Update()
    {
        UpdateHeightUI();
        currentTime += Time.deltaTime;
        UpdateTimeUI();

        float currentHeight = player.position.y;
        if (currentHeight > bestHeight)
        {
            bestHeight = currentHeight;
            PlayerPrefs.SetFloat("BestHeight", bestHeight);
            PlayerPrefs.Save();
            UpdateBestHeightUI();
        }
    }

    public void CollectCoin(int coinValue)
    {
        coinsCollected += coinValue;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinsCollected;
    }

    private void UpdateTimeUI()
    {
        timeText.text = $"Time: {Math.Floor(currentTime):0.00}s";
    }
    private void UpdateHeightUI()
    {
        if (player.position.y >= 0.0f)
        {
            heightText.text = $"Height: {Mathf.Floor(player.position.y)}m";
        }
    }

    private void UpdateBestHeightUI()
    {
        bestHeightText.text = $"Best Height: {Mathf.Floor(bestHeight)}m";
    }

    public void HandlePlayerDeath()
    {
        PlayerPrefs.SetFloat("BestHeight", bestHeight);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}