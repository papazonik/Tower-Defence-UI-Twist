using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gold;
    public Text goldDisplay;
    public TextMeshProUGUI pauseText;

    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        
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



    // Update is called once per frame
    void Update()
    {
        //goldDisplay.text = gold.ToString();
    }
}
