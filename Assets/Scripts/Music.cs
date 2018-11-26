using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SetUpSingleton();
	}

    private void SetUpSingleton()
    {
        // looks for Music type
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
