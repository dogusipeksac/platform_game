using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health;
    bool dead=false;
    Transform muzzle;
    public Transform bullet,floatingText;
    public float bulletSpeed;

    public Slider slider;
    

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue=health;
        slider.value=health;
        //kurşunların çıktığı yer
        muzzle=transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        //mouse tıklandığında ates edilir
        if(Input.GetMouseButtonDown(0)){
            shootBullet();
        }
    }
    //userin değdiğinde canı azalır
    public void getDamage(float damage){

        Instantiate(floatingText,transform.position,UnityEngine.Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();
        if(health-damage>=0){
            health-=damage;
        }
        else{
            health=0;
        }
        slider.value=health;
        amIDead();
    }
    //eğer canım sıfırsa ölürüm
    void amIDead(){
        if(health<=0){
            dead=true;
        }else{
            dead=false;
        }
    }
    //ateş etme
    void shootBullet(){
        Transform tempBullet;
        tempBullet=Instantiate(bullet,muzzle.position,UnityEngine.Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward*bulletSpeed);
    }
}
