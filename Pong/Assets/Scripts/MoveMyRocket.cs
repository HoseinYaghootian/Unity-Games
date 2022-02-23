using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMyRocket : MonoBehaviour {
    float speed = 30;
    void Start() {
        
    }

    void Update() {
        // UP or W : 1
        // DOWN or S : -1
        float v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
