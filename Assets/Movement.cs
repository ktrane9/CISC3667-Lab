using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] GameObject pin;
    public Vector2 moveValue;
    public Collider2D col;
    public float x, y;
    public bool facingRight;
    public float speed = 2;
    int face = 1; //Variable the changes horizontal movement
    //private Animator animation;

    void Awake() {
        //animation = GetComponent<Animator>();
    }

    void Start() {
        
    }

    // Update is called once per frame
    
    void Update() {
        move();
        shoot();

        // flip();

    }

    void move() {
        // x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        

        if (x < 0 && facingRight) {
            facingRight = false;
            transform.Rotate(new Vector2(0, 180));
            face = -1;
            moveValue = new Vector2(x * face, y);
            transform.Translate(moveValue * speed * Time.deltaTime);
        }

        else if (x > 0 && !facingRight) {
            facingRight = true;
            transform.Rotate(new Vector2(0, 180));
            face = 1;
            moveValue = new Vector2(x * face, y);
            transform.Translate(moveValue * speed * Time.deltaTime);
        }

        else {
            moveValue = new Vector2(x * face, y);
            transform.Translate(moveValue * speed * Time.deltaTime);
        }

        //if(moveValue != 0) animator.SetBool("");


        //flip(x, y);
    }

    public void shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //pin is spawned have it move in the direction it is facing
            Instantiate(pin, transform.position, Quaternion.identity);
        }
    }
}