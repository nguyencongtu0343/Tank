using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessCotroller : MonoBehaviour
{
    public int currentValue;
    public int maximumValue;
    public virtual void SetValue(int newValue)
    {
        currentValue = newValue;
        if (currentValue <= 0)
        {
            currentValue = 0;
        }
        else if (currentValue >= maximumValue)
        {
            currentValue = maximumValue;
        }
        transform.localScale = new Vector3((float) 0.08 * currentValue / maximumValue, transform.localScale.y, 1);
    }
}
