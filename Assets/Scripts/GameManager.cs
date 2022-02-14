using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public int gold;
    private int lives = 0;
    public Text goldDisplay;
    public TextMeshProUGUI pauseText;

    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        var hearts = FindObjectsOfType<Heart>();
        foreach (var heart in hearts)
        {
            lives++;
        }
        print(lives);
    }

    public void PauseToggle()
    {
        if (paused)
        {
            Time.timeScale = 1.0f;
            paused = false;
            pauseText.text = ("Pause");
        }
        else
        {
            Time.timeScale = 0.0f;
            paused = true;
            pauseText.text = ("Continue");
        }
    }

    public int GetLives()
    {
        return lives;
    }

    public void LoseLife()
    {
        if (lives >= 0)
        {
            lives--;
        }
    }



    // Update is called once per frame
    void Update()
    {
        //goldDisplay.text = gold.ToString();
    }
}
