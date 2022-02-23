using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {
    float speed = 20;
    void Start() {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D mihman)
    {
        if(mihman.gameObject.name == "WallLeft") {

        }
        else if(mihman.gameObject.name == "WallRight") {

        }
    }
}
