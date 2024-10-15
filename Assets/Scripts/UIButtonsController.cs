using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsController : MonoBehaviour
{
    public void PauseButton()
    {
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
    }
    public void MainMenuButton()
    {
        ResumeButton();
        SceneManager.LoadScene(0);
    }

    public void SoundToggle(Animator animator)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            animator.SetBool("On", !animator.GetBool("On"));
        }
    }
}
