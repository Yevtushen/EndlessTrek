using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject characterModel;
    public AudioSource crashThud;
    public GameObject mainCamera;
    public GameObject levelControl;
   
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        characterModel.GetComponent<Animator>().StopPlayback();
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        characterModel.GetComponent<Animator>().Play("Stumble Backwards");
        levelControl.GetComponent<LevelDistance>().enabled= false;
        crashThud.Play();
        mainCamera.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<EndRunner>().enabled = true;
    }
}
