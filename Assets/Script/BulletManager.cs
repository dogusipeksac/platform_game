using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage,lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        //3 sn sonra kurşunlar yok olur
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
