using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : SingletonMonoBehaviour<CreateController>
{
    //private float count = 0;
    public EnemyController enemy;
    public ExplosionController explosion;
    public BulletController bullet;
    public void CreateBullet(Transform shootPos)
    {
        Instantiate(bullet, shootPos.position, shootPos.rotation);
    }

    public void CreateExplosion(Vector3 Pos)
    {
        Instantiate(explosion, Pos, Quaternion.identity);
    }

    public EnemyController CreateEnemy(Transform enemyAppear)
    {
       return Instantiate(enemy, enemyAppear.position, enemyAppear.rotation);
    }

}
