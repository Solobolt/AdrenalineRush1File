using UnityEngine;
using System.Collections;

public class Screenshake : MonoBehaviour {

    //Holds the main camera object
    private Camera main;

    //Holds screen shake variables
    private float shakeAmount = 0.5f;
    private float shakeTime = 0.2f;

    private float timer = 0;

    private bool shake = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(shake == true)
        {

        }
        else
        {
            main.transform.localPosition = new Vector2(0,0);
        }
	}
}
