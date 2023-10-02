using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class player : MonoBehaviour //unity class for gameobject behavior 
{
    [SerializeField] float moveSpeed = 5f; // set moving speed
    UnityEngine.Vector2 rawInput; // player input definition

// definition of paddings for camera boundries
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    //definition of camera boundries
    UnityEngine.Vector2 minBounds;
    UnityEngine.Vector2 maxBounds;

    Shooter shooter;

    void Awake(){
        shooter = GetComponent<Shooter>();
    }


    // Start is called once on start
    void  Start(){

        initBounds(); //setting camera boundries


    }

    // Update is called once per frame
    void Update()
    {
        Move();// so long as player press or holds keys it should move 
    }

    void initBounds(){

        Camera mainCamera = Camera.main; //main camera object
        minBounds = mainCamera.ViewportToWorldPoint(new UnityEngine.Vector2(0,0)); //normalize left bottom
        maxBounds = mainCamera.ViewportToWorldPoint(new UnityEngine.Vector2(1,1)); //normalize right top
    }

    void Move()
    {
        UnityEngine.Vector2 delta = rawInput * moveSpeed * Time.deltaTime; // real time dependant move speed

        UnityEngine.Vector2 newPos = new UnityEngine.Vector2(); // object for next position 

        newPos.x = Mathf.Clamp(transform.position.x + delta.x , minBounds.x + paddingLeft , maxBounds.x + paddingRight ); // calculate new x

        newPos.y = Mathf.Clamp(transform.position.y + delta.y , minBounds.y + paddingBottom , maxBounds.y + paddingTop );// calculate new y

        transform.position = newPos; // to move game object
    }

    void OnMove(InputValue value){
        rawInput = value.Get<UnityEngine.Vector2>(); // get player input
    }

    void OnFire(InputValue value){

        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
