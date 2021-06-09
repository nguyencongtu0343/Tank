using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using static GameController;

[System.Serializable]
public class WaveInfo
{
    public int numEnemy;
    public int levelEnemy;
}

public class WaveController : MonoBehaviour
{
    [SerializeField] //public nhưng bảo vệ giá trị, không cho thay đổi ở cửa sổ unity
    WaveInfo[] wave;
    public WaveInfo[] Wave
    {
        set
        {
            wave = value; // Điền số lượng wave trong stage
            currentIndex = 0;
        }
    }
    public int currentIndex;
    int numEnemy;

    void Start()
    {
        currentIndex = 0;
        Observer.Instance.AddObserver(TOPICNAME.ENEMY_DESTROYED, EnemyDeath);
    }

    public void EnemyDeath(object data)
    {
        numEnemy--;
        if (numEnemy <= 0)
        {
            currentIndex++;

            CreateWave();
        }
    }

    public void CreateWave()
    {
        if (currentIndex > wave.Length - 1)
        {
            Debug.Log("NEXT STAGE");
            Observer.Instance.Notify(TOPICNAME.FINAL_WAVE_END, currentIndex);
            return;
        }

        numEnemy = wave[currentIndex].numEnemy;

        WaveInfo currentWay = wave[currentIndex];
        for (int i = 1; i <= currentWay.numEnemy; i++)
        {
            transform.position = new Vector3(
                Random.Range(-25, 25),
                Random.Range(-25, 25),
                0
                );
            EnemyController enemyController = CreateController.Instance.CreateEnemy(transform);
            enemyController.levelController.SetLevel(wave[currentIndex].levelEnemy);
        }
    }
}

public class Wave : SingletonMonoBehaviour<WaveController>
{

}