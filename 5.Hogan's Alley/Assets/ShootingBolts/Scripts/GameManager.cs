using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int actualPoints;
    public float time = 60;
    public TextMeshProUGUI textArea;


    private void Update()
    {
        time -= Time.deltaTime;
        textArea.text = "Score:" + actualPoints + "\nTime: " + (int)time;

        if (time <= 0.0f)
        {
            Application.Quit();
        }
    }

}
