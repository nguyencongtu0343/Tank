using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : ProcessCotroller
{
    int level;
    SpriteRenderer spriteRenderer;
    //public delegate void LevelUp(int level);
    //public LevelUp levelUp;
    public TextMeshPro txtLevel;
    
    public int Level
    {
        get
        {
            return level;
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.cyan;
        SetValue(currentValue);
    }

    public void SetLevel(int newLevel)
    {
        level = newLevel;
        txtLevel.text = "Lv" + level.ToString();
    }

    public override void SetValue(int newValue)
    {
        base.SetValue(newValue);
        if (currentValue == maximumValue)
        {
            SetLevel(++level);
            currentValue = 0;           
            base.SetValue(currentValue);
        }
    }



}
