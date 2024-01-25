using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -5.13f;
    public static float rightSide = 1.57f;

    public float controllerLeft;
    public float controllerRight;

    // Update is called once per frame
    void Update()
    {
        controllerLeft = leftSide;
        controllerRight = rightSide;

    }
}
