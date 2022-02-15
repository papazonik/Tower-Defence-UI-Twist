using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    Health health;
    public Sprite noDamage;
    public Sprite damage1;
    public Sprite damage2;
    public Sprite damage3;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    public AudioClip takeDamage;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        SetSprite(noDamage);
    }

    private void OnDestroy()
    {
        if (gameManager)
        {
            gameManager.LoseLife();
        }
    }

    void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    void Update()
    {
        if (health.getCurrentHealth() <= 35)
        {
            SetSprite(damage3);           
        }
        else if (health.getCurrentHealth() <= 50)
        {
            SetSprite(damage2);
        }
        else if (health.getCurrentHealth() <= 80)
        {
            SetSprite(damage1);
        }
    }
}
