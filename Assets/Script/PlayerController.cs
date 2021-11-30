using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed=1f;
    public float jumpSpeed=1f,jumpFrequency=1f,nextJumpTime=0f;
    bool facingRight=true;
    public bool isGrounded=false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB=GetComponent<Rigidbody2D>();
        playerAnimator=GetComponent<Animator>();

    
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove();
        onGroundCheck();
        //yüzünün yönü
        if(playerRB.velocity.x < 0 && facingRight){
            //yuzunu çevir
            flipFace();
        }
        else if(playerRB.velocity.x > 0 && !facingRight){
            flipFace();
        }
        
        //çift zıplamasını engelleme
        if(Input.GetAxis("Vertical")>0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad)){
            nextJumpTime=Time.timeSinceLevelLoad+jumpFrequency;
            jump();
        }
        
    }
    void FixedUpdate()
    {
       
    }
    //yatay eksende hareket
    void horizontalMove(){
       playerRB.velocity=new Vector2(Input.GetAxis("Horizontal")*moveSpeed,playerRB.velocity.y);
       playerAnimator.SetFloat("playerSpeed",Mathf.Abs(playerRB.velocity.x));
    }
    //koştuğu yöne yüzünü çevirme
    void flipFace(){
        facingRight=!facingRight;
        Vector3 tempLocalScale=transform.localScale;
        tempLocalScale.x *=-1;
        transform.localScale=tempLocalScale;
    
    }
    //zıplama
    void jump(){
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }
    //yere değiyormu
    void onGroundCheck(){
        isGrounded=Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim",isGrounded);
    }
}
