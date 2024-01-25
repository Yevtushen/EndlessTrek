using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuFunction : MonoBehaviour
{
    public AudioSource buttonClicked;
    public AudioSource quitButtonClicked;
    public GameObject creditsScreen;
    public GameObject hintBox;
    public bool hintGenerated;
    public GameObject coinDisplay;
    static public int coinsCount;

    private string[] _hints = {"press a or left arrow to move to the left", "press d or right arrow to move to the right", "press w, space or up arrow to jump", "beware of tentacles and eyes", "don't forget to collect coins" };


    private void Start()
    {
        coinsCount += CollectableControl.coinCount;
        CollectableControl.coinCount = 0;
    }

    public void Update()
    {
        if (hintGenerated == false)
        {
            hintGenerated= true;
            StartCoroutine(GetHint());
        }
        
        coinDisplay.GetComponent<TextMeshProUGUI>().text = "" + coinsCount;
    }

    public void PlayGame()
    {
        StartCoroutine(LoadingGame());
    }

    IEnumerator LoadingGame()
    {
        buttonClicked.Play();
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        StartCoroutine(QuittingGame());
    }

    IEnumerator QuittingGame()
    {
        quitButtonClicked.Play();
        yield return new WaitForSeconds(1);
        Application.Quit();
        Debug.Log("Quit.");
    }

    public void ShowCredits()
    {
        buttonClicked.Play();
        creditsScreen.SetActive(true);
    }

    public void GoBack()
    {
        quitButtonClicked.Play();
        creditsScreen.SetActive(false);
    }

    IEnumerator GetHint()
    {

        hintBox.GetComponent<TextMeshProUGUI>().text = "" + _hints[Random.Range(0, _hints.Length)];
        yield return new WaitForSeconds(8);
        hintGenerated = false;
    }
}
