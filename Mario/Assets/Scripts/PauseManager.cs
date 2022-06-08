using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool is_pause = false;
    public bool do_resume = false;

    public void SetActive() {
        gameObject.SetActive(true);
        is_pause = true;
    }

    public void SetDeActive() {
        gameObject.SetActive(false);
        is_pause = false;
        do_resume = false;
    }
    
    public void ResumeButton() {
        do_resume = true;
    }

    public void ExitButton() {
        Application.Quit();
    }
}
