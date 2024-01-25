using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public AudioSource buttonClicked;
    public GameObject pausedDisplay;
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public AudioSource readyFX;
    public AudioSource goFX;
    public GameObject fadeOut;

    public void PauseRunner()
    {
        buttonClicked.Play();
        Time.timeScale = 0;
        pausedDisplay.SetActive(true);
    }

    public void ResumeRunner()
    {
        buttonClicked.Play();
        pausedDisplay.SetActive(false);
        StartCoroutine(ResumeSequence());
    }

    public void RestartRunner()
    {
        StartCoroutine(StoppingRunner(1));
    }

    public void StopRunner()
    {
        StartCoroutine(StoppingRunner(0));
    }

    IEnumerator StoppingRunner(int index)
    {
        Time.timeScale = 1;
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(index);
    }

    IEnumerator ResumeSequence()
    {       
        countDown3.GetComponent<Animator>().Play("CountAnimation", -1, 0);
        readyFX.Play();
        yield return new WaitForSecondsRealtime(1);
        countDown2.GetComponent<Animator>().Play("CountAnimation", -1, 0);
        readyFX.Play();
        yield return new WaitForSecondsRealtime (1);
        countDown1.GetComponent<Animator>().Play("CountAnimation", -1, 0);
        readyFX.Play();
        yield return new WaitForSecondsRealtime(1);
        countDownGo.SetActive(true);
        goFX.Play();
        Time.timeScale = 1;
    }
}
