using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour {
    public Vector2 moveValue;
    public Collider2D spikes;
    public Collider2D balloon;
    public Collider2D Ceiling;
    public Collider2D Platform;
    public float x, y;
    [SerializeField] float speed;
    public bool direction = true;
    //[SerializeField] AudioSource audio; //plink sound effect
    private Animator animation;
   
    void Awake() {
        animation = GetComponent<Animator>();
    }

    void Start() {
        // if (GetComponent<AudioSource>() == null) {
        //     audio = GetComponent<AudioSource>();
        // }
        animation.SetBool("Poke", true);
        speed = 0.5f;
    }

    void Update() {
        bounce();
        //bounce(spikes);
    }

    void move() {
        y = 1;
        moveValue = new Vector2(0, y);
        transform.Translate(moveValue * speed * Time.deltaTime);
    }

    public void bounce() {
        if(direction == false) {
            speed = -speed;
            direction = true;
            move();
        }
        else move();
    }

    public void bounce(Collider2D spikes) {
        if(spikes.IsTouching(Ceiling) || spikes.IsTouching(Platform)) {
            speed = -speed;
            move();
        }
        else move();
    }

    // public void animate() {
    //     animator.SetBool("Poke", true);
    // }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Pin") {
            //AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(col.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Wall") {
            direction = false;
            bounce();
        } 
    }
}
