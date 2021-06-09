using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using static GameController;

public class PlayerController : TanksController
{
    public GameObject player;

    protected override void Awake()
    {
        base.Awake();
        levelController.SetLevel(1);
        Observer.Instance.AddObserver(TOPICNAME.ENEMY_DESTROYED, EnemyDestroyedHandle);
    }    
    public override void onDestroy()
    {
        Destroy(this.gameObject);
        CreateController.Instance.CreateExplosion(transform.position);
        Observer.Instance.RemoveObserver(TOPICNAME.ENEMY_DESTROYED, EnemyDestroyedHandle);
    }


    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        Move(direction);

        Vector3 gunDirection = new Vector3(
            Input.mousePosition.x - Screen.width/2,
            Input.mousePosition.y - Screen.height/2,
            0
            );

        RotateGun(gunDirection);

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        CameraController.Instance.CameraMove(transform.position);
    }

    void EnemyDestroyedHandle(object data)
    {
        int enemyLevel = (int)data;
        levelController.SetValue(levelController.currentValue + enemyLevel * 50);
    }

}

public class Player: SingletonMonoBehaviour<PlayerController>
{

}
