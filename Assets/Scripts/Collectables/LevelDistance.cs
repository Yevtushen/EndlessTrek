using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class LevelDistance : MonoBehaviour
{
    public GameObject distanceDisplay;
    public GameObject finalDistanceDisplay;
    public int distanceRun;
    public static int publicDistanceRun;
    public int finalDistanceRun;
    public bool addingDistance;
    public float distanceDelay = 0.35f;

    void Update()
    {
        if (addingDistance == false)
        {
            addingDistance= true;
            StartCoroutine(AddingDistance());
        }
    }

    IEnumerator AddingDistance()
    {
        distanceRun++;
        publicDistanceRun = distanceRun;
        distanceDisplay.GetComponent<TextMeshProUGUI>().text = "" + distanceRun;
        finalDistanceDisplay.GetComponent<TextMeshProUGUI>().text = "" + distanceRun;
        yield return new WaitForSeconds(distanceDelay);
        addingDistance = false;
    }
}
