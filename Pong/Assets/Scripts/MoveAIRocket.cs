using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAIRocket : MonoBehaviour
{
    float ball_x = 0;
    float ball_y = 0;

    float speed = 30;
    public GameObject Ball_1;
    public GameObject Ball_2;

    void Start() {
        
    }

    void Update() {
        float rocket_x = transform.position.x;
        float rocket_y = transform.position.y;

        float ball_x_1 = Ball_1.transform.position.x;
        float ball_y_1 = Ball_1.transform.position.y;
        float ball_x_2 = Ball_2.transform.position.x;
        float ball_y_2 = Ball_2.transform.position.y;

        //تشخیص این‌که کدام توپ به راکت نزدیکتر است یا این‌که از راکت رد نشده است تا راکت بر مبنای آن حرکت کند
        if(rocket_x - ball_x_1 < rocket_x - ball_x_2 | ball_x_2 > rocket_x) {
            ball_x = ball_x_1;
            ball_y = ball_y_1;
        } 
        else if(rocket_x - ball_x_1 > rocket_x - ball_x_2 | ball_x_1 > rocket_x) {
            ball_x = ball_x_2;
            ball_y = ball_y_2;
        }

        float rocket_h = GetComponent<BoxCollider2D>().transform.localScale.y;
        float direction;

        //فقط زمانی که توپ وارد زمینش می‌شود
        if(ball_x > 0) {
            //حرکت راکت
            if(ball_y + rocket_h < rocket_y) {
                direction = -1;
            } 
            else if(ball_y - rocket_h > rocket_y) {
                direction = 1;
            } 
            else {
                direction = 0;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, direction) * speed;
        }
        
    }
}
