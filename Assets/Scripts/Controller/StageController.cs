using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

[System.Serializable]
public class Stage
{
    public WaveInfo[] wave;
}
public class StageController : MonoBehaviour
{
    [SerializeField]
    int currentIndex;
    public Stage[] stage;

    void Start()
    {
        currentIndex = 0;
        Observer.Instance.AddObserver(TOPICNAME.FINAL_WAVE_END, OnEndWay);
        CreateStage();
    }

    public void OnEndWay(object data)
    {
            currentIndex++;
            CreateStage();
    }

    public void CreateStage()
    {
        if(currentIndex > stage.Length - 1)
        {
            Debug.Log("YOU WIN");
            return;
        }

        Stage currentStage = stage[currentIndex];
        Wave.Instance.Wave = currentStage.wave;
        Wave.Instance.CreateWave();
    }
}

