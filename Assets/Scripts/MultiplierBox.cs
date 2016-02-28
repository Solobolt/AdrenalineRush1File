using UnityEngine;
using System.Collections;

public class MultiplierBox : MonoBehaviour {

    public PointManager pointManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Handles trap hit
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.transform.tag == "Trap")
        {
            //Add multiplier
            pointManager.addMulti();
        }
    }
}
