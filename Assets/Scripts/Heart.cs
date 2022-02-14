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

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        SetSprite(noDamage);
    }

    void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    private void OnDestroy()
    {
        print("Dead");
        gameManager.LoseLife();
        print(gameManager.GetLives());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health.TakeDamage(10);
            print(health.getCurrentHealth());
        }
        if (health.getCurrentHealth() <= 25)
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
