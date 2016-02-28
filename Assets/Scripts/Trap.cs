using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    //Holds main transform variables
    private Transform myTransform;
    private Vector3 currentPos;

    //Holds timer bool
    private TrapTimer timer;

    //Trap Height Values
    private float maxHeight = 8.0f;
    private float minHeight = 0.0f;


    // Use this for initialization
    void Start () {
        myTransform = this.transform;
        
        //Gets the trap position from the global timer
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TrapTimer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(timer.trapUp)
        {
            //Slides the trap Upwards
            SlideTrapUp(maxHeight);
        }
        else
        {
            //sets the traps to the min height
            SetPos(minHeight);
        }
    }


    //Changes the height of the trap
    void SetPos(float value)
    {
        currentPos = myTransform.position;
        currentPos.y = value;
        myTransform.position = currentPos;
    }

    //slides the trap up
    void SlideTrapUp(float target)
    {
        currentPos = myTransform.position;
        currentPos.y += (target - currentPos.y) * 6f * Time.deltaTime;
        myTransform.position = currentPos;
    }
}
