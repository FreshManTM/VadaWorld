using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsController : MonoBehaviour
{
    [SerializeField] AudioSource _music;
    public IEnumerable<int> GenerateFibonacciSequence(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be non-negative.");

        int first = 0, second = 1;

        for (int i = 0; i < count; i++)
        {
            yield return first;
            int temp = first + second;
            first = second;
            second = temp;
        }
    }
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
    public bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(email);
            return mailAddress.Address == email;
        }
        catch
        {
            return false;
        }
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
