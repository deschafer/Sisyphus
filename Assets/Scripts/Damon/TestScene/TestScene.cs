using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
	// we want to time the scene
	// and we need to verify that the scene is in fact still able to suceed

	private bool fail = false;		// indicates if this test has failed
	private float time = 10;		// indicates time in seconds
	private float currentTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// get the time from the last instance
		currentTime += Time.deltaTime;

		if(currentTime >= time && !fail)
		{
			Debug.Log("Suceeded");
		}

	}
}
