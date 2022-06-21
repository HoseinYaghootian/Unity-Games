using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Mario mario;

    RigidbodyConstraints2D original_constraints;
    public GameOverManager gameOverManager;
    public PauseManager pauseManager;
  
    void Awake()
    {
        mario.mario_rb = mario.GetComponent<Rigidbody2D>();
        original_constraints = mario.mario_rb.constraints;
    }

    void Start()
    {   
    
    }

    void Update()
    {
        if(mario.is_levelup==true)
        {
            SceneManager.LoadScene("Level2");
        }

        if(mario.is_dead==true)
        {
            gameOverManager.SetActive();
            mario.mario_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
      
        if(Input.GetKey(KeyCode.Escape) && pauseManager.is_pause == false && gameOverManager.is_game_over == false)
        {
            pauseManager.SetActive();
            mario.mario_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }  

        if(Input.GetKey(KeyCode.Return) && pauseManager.is_pause == true || pauseManager.do_resume == true)
        {
            pauseManager.SetDeActive();
            mario.mario_rb.constraints = original_constraints;
            mario.controller.Move(mario.horizontalMove * Time.fixedDeltaTime, false, mario.isJumping);
        }  


    }
    
}
