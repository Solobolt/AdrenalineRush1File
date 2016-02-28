using UnityEngine;
using System.Collections;

public class SpeedBar : MonoBehaviour {

    //Holds players gameObject
    public GameObject player;
    private PlayerController controller;
    private float ratio;
    private Vector3 currentScale;
    private Vector3 currentPos;

    private Transform myTransform;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
        controller = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        ratio = controller.speedRatio;

        currentScale = myTransform.localScale;
        currentPos = myTransform.localPosition;

        currentScale.y = ratio;
        currentPos.y = (ratio / 2.0f) - 0.5f;

        myTransform.localPosition = currentPos;
        myTransform.localScale = currentScale;
	}
}
