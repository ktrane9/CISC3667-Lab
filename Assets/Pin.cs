using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    public Vector2 moveValue;
    public Collider2D col;
    public float x = 1;
    public bool facingRight;
    public float speed = 4;
    //[SerializeField] AudioSource audio;

    void Start() {
        // if (GetComponent<AudioSource>() == null) {
        //     audio = GetComponent<AudioSource>();
        // }
        
    }

    void Update() {
        fire();
    }

    void fire() {
        moveValue = new Vector2(x, 0);
        transform.Translate(moveValue * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(col.isTrigger) col.isTrigger = false;
    }
}
