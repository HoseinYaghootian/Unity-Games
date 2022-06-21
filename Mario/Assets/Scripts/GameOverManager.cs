using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public bool is_game_over = false;

    public void SetActive() {
        gameObject.SetActive(true);
        is_game_over = true;
    }

    void Update() {
        if(Input.GetKey(KeyCode.Return))
            RestartButton();
    } 
    
    public void RestartButton() {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void ExitButton() {
        Application.Quit();
    }
}
