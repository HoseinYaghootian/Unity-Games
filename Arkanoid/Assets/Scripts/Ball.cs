using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 100;
    void Start() {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
    
    void Update() {}
}
