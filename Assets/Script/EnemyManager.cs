using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;
    public Slider slider;

    bool colliderBusy=false;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue=health;
        slider.value=health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //enemye değdiğim an
        if(other.tag=="Player" && !colliderBusy){
            colliderBusy=true;
            other.GetComponent<PlayerManager>().getDamage(damage);
        }
        //kurşunların enemye değmesi
        else if(other.tag=="Bullet"){
            getDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
        
    }
    //içinde olma
    private void OnTriggerStay2D(Collider2D other)
    {
        
    }
    //değmediğim an
    private void OnTriggerExit2D(Collider2D other)
    {
         if(other.tag=="Player"){
            colliderBusy=false;
          
        }
    }

    //düşmana hasar verme
    public void getDamage(float damage){
        if(health-damage>=0){
            health-=damage;
        }
        else{
            health=0;
        }
        slider.value=health;
        amIDead();
    }
    void amIDead(){
        if(health<=0){
            //düşmanın canı azsa yoket
        DataManager.Instance.EnemyKilled++;
        Destroy(gameObject);
        }
    }
}
