using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        GameManager.Instance.LoadScene(1);
    }

}
