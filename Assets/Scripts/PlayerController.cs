using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Transform myTransform;

    //Holds all speed Variables
    private float speedIncrease = 20.0f;
    public float currentSpeed = 0;
    private float maxSpeed = 50.0f;
    public float speedRatio = 0.0f;
    private float speedDelta = 50.0f;

    //holds the players distnace from the begining distance
    private float distance = 0.0f;

    //Holds player score info
    public PointManager pointsManager;

    public GameObject pause;

    // Use this for initialization
    void Start () {
        myTransform = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        //constant speed degredation
        currentSpeed -= speedDelta * Time.deltaTime;

        //stops player from moving backwards
        if (currentSpeed < 0)
        {
            currentSpeed = 0;
        }

        //Handles mouse click
        if (Input.GetMouseButtonDown(0))
        {
            currentSpeed += speedIncrease;
            if(currentSpeed >= maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(pause);
        }

        //Moves the player at the cirrect speed
        myTransform.Translate(Vector3.right * Time.deltaTime * currentSpeed);

        //Tracks the players current distance
        distance += Time.deltaTime * currentSpeed;

        //Creates new floor every 100 m
        if (distance > 100)
        {
            distance -= 100;
            print("Create Floor");
            //Create a floor
        }

        //keeps a value for the players speed
        speedRatio = currentSpeed / maxSpeed;

        //if the player right click sload the main menu
        if (Input.GetMouseButtonDown(1))
        {
            Application.LoadLevel("MainMenu");
        }
    }


    //Restarts the level if the player hits a trap
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.transform.tag == "Trap")
        {
            print(coll.transform.tag);
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            if(coll.transform.tag == "Point")
            {
                pointsManager.addPoint();
            }
        }
    }
}
