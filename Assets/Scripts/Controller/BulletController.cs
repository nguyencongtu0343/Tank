using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveController
{
    public Transform explosion;
    private float time = 0;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(transform.up);
        time++;
        if(time > 25)
        {
            Destroy(this.gameObject);
            CreateController.Instance.CreateExplosion(transform.position);
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.5f);

        if (hit.transform != null)
        {
            IHit fire = hit.transform.gameObject.GetComponent<IHit>();
            if (fire != null)
            {
                fire.OnHit(damage);
                Destroy(this.gameObject);
            }
        }
    }
}

public class Bullet : SingletonMonoBehaviour<BulletController>
{

}
