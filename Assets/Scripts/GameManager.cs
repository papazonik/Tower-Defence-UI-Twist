using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public int gold;
    private int lives = 10;
    public Text goldDisplay;
    public TextMeshProUGUI pauseText;
    public Transform heartPrefab;
    List<Transform> hearts;

    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        hearts = new List<Transform>();
        for (int i = 0; i < lives; i++)
        {
           SpawnHeart(i);
        }
    }

    void SpawnHeart(int positionIndex)
    {
        Vector3 spawnpos = new Vector3(-6.5f + positionIndex, 4, 0);
        Transform newHeart = Instantiate(heartPrefab, spawnpos, Quaternion.identity);
        hearts.Add(newHeart);
    }

    public void LoseHeart()
    {
        if (hearts.Count > 0)
        {
            Destroy(hearts[hearts.Count - 1].gameObject);
            hearts.RemoveAt(hearts.Count - 1);
        }
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
            LoseHeart();
        }
    }



    // Update is called once per frame
    void Update()
    {
        //goldDisplay.text = gold.ToString();
    }
}
