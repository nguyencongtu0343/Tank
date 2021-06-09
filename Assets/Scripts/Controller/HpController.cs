using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : ProcessCotroller
{
    //public float currentHP;
    //public float maximumHP;
    SpriteRenderer spriteRenderer;
    public delegate void Die();
    public Die die;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.green;
        currentValue = maximumValue;
    }

    public override void SetValue(int newValue)
    {
        base.SetValue(newValue);
        if (currentValue <= 0)
        {
            die();
            return;
        }

        spriteRenderer.color = Color.Lerp(Color.red, Color.yellow, (float)currentValue / maximumValue);
    }

}

