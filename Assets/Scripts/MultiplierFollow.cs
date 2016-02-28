using UnityEngine;
using System.Collections;

public class MultiplierFollow : MonoBehaviour {

    public GameObject player;

    private Transform myTransform;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        myTransform.position = player.transform.position;
	}
}
