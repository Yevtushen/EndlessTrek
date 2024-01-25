using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public string parentName;

    void Start()
    {
        parentName = transform.name;
        StartCoroutine(CleanClone());
    }

    IEnumerator CleanClone()
    {
        yield return new WaitForSeconds(120);
        if (parentName == "Section(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
