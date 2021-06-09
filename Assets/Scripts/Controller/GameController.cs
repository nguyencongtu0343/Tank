using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using TMPro;

public class TOPICNAME
{
    public const string ENEMY_DESTROYED = "EnemyDestroyed";
    public const string FINAL_WAVE_END = "FinalWavesEnd";
}
public class GameController : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtState;
    private int score = 0;
    private int stage = 1;
    void Start()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMY_DESTROYED, Score);
        Observer.Instance.AddObserver(TOPICNAME.FINAL_WAVE_END, Stage);
    }
    
    public void Score(object data)
    {
        score++;
        txtScore.text = "Score " + score.ToString();
    }

    public void Stage(object data)
    {
        stage++;
        txtState.text = "Stage: " + stage.ToString();
    }
}
