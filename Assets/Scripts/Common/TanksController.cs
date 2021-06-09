using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TanksController : MoveController, IHit
{
    public Transform shootPos;
    public Transform bullet;
    public Transform head;
    public Transform body;
    public HpController hpController;
    public LevelController levelController;

    protected virtual void Awake()
    {
        hpController.die = onDestroy;
    }

    public abstract void onDestroy();
    
        
    
    protected override void Move(Vector3 direction)
    {
        if(direction.magnitude >= 0.5f)
        {
            base.Move(direction);
            body.up = direction;
        }       
    }

    protected virtual void RotateGun(Vector3 gunDirection)
    {
        head.up = gunDirection;
    }

    protected virtual void Shoot()
    {
        CreateController.Instance.CreateBullet(shootPos);
    }

    public void OnHit(int damage)
    {
        hpController.SetValue(hpController.currentValue - damage);
    }

    public void UpLevel(int level)
    {
        Bullet.Instance.damage = level * 5;
        speed = level * 2;
    }
}
