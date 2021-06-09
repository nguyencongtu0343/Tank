using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using static GameController;

public class EnemyController : TanksController
{

    float distance;
    private float count = 0;
    private float time = 0;
    Vector3 enemyDirection;

    public override void onDestroy()
    {
        Destroy(this.gameObject);
        CreateController.Instance.CreateExplosion(transform.position);
        Observer.Instance.Notify(TOPICNAME.ENEMY_DESTROYED, levelController.Level);
    }

    void Start()
    {
        levelController.SetLevel(1);
    }

    void Update()
    {

        distance = Vector3.Distance(transform.position, Player.Instance.player.transform.position);

        if (distance > 10)
        {
            enemyDirection = (Player.Instance.player.transform.position - transform.position) / distance;
        }

        else
        {
            count++;
            if (count == 30)
            {
                count = 0;
                enemyDirection = new Vector3(
                    Random.Range(-1, 1),
                    Random.Range(-1, 1),
                    0
                    );
            }
        }

        Move(enemyDirection);

        RotateGun(Player.Instance.player.transform.position - transform.position);

        time++;
        if (time == 20)
        {
            Shoot();
            time = 0;
        }

        
    }
}
