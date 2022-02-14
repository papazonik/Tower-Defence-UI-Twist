using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int gold;
    private int lives = 10;
    public Text goldDisplay;
    public TextMeshProUGUI pauseText;
    public Transform heartPrefab;
    List<Transform> hearts;
    public GameObject gameOver;
    public AudioClip loseLife;

    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
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
        //LoseLife();
        if (hearts.Count > 0)
        {
            if (hearts[hearts.Count - 1] == null)
            {
                return;
            }
            Destroy(hearts[hearts.Count - 1].gameObject);
            hearts.RemoveAt(hearts.Count - 1);
        }
    }

    void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1.0f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.LogWarning("Game Quit");
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
            SoundManager.Instance.PlaySound(loseLife);
            if (lives == 0)
            {
                GameOver();
            }
        }
        print("Lives: " + lives);
    }



    // Update is called once per frame
    void Update()
    {
        //goldDisplay.text = gold.ToString();
    }
}
