using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour {
    public Vector2 moveValue;
    public Collider2D balloon;
    public Collider2D rWall;
    public Collider2D lWall;
    public Collider2D pin;
    //public Collider2D spike = GameObject.tag("Hazard");
    public float x, y;
    public bool facingRight;
    public float speed = 2;
    public float growth = 0.6f;
    public int points = 1;
    [SerializeField] AudioSource audio;
    //int face = 1; //Variable that changes horizontal movement

    // Start is called before the first frame update
    void Start() {
        //Debug.Log("Bounce");
        if (GetComponent<AudioSource>() == null) {
            audio = GetComponent<AudioSource>();
        }

        InvokeRepeating("grow", 3.0f, 1.0f);
    }

    // Update is called once per frame
    void Update() {
        bounce(balloon);
        //pop(col);
        
        
    }

    void move() {
        x = 1;
        moveValue = new Vector2(x, 0);
        transform.Translate(moveValue * speed * Time.deltaTime);

    }

    public void bounce(Collider2D balloon) {
        if(balloon.IsTouching(lWall) || balloon.IsTouching(rWall)) {
            speed = -speed;
            move();
        }
        else move();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Pin") {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(col.gameObject);
            Display.Scoring.addPoints(points);
        }
    }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if(collision.gameObject.tag == "Hazard") {
    //         spike.isTrigger = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D col) {
    //     if(col.gameObject.tag == "Hazard") {
    //         col.isTrigger = false;
    //     }
    // }

    void grow() {
        if(growth < 1) {
            growth += 0.1f;
            if(growth > 0.62f) {
                transform.localScale = new Vector2(growth, growth);
                points += 1;

            }
        }
        else {
            CancelInvoke("grow");
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Display.Scoring.reload();
        }
        
    }
}
