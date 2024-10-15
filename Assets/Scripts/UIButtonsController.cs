using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsController : MonoBehaviour
{
    [SerializeField] AudioSource _music;
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
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && _music != null)
        {
            if (animator.GetBool("On"))
            {
                animator.SetBool("On", false);
                _music.Pause();
            }
            else
            {
                animator.SetBool("On", true);
                _music.Play();
            }

        }
    }
}
