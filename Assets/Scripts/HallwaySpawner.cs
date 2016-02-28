using UnityEngine;
using System.Collections;

public class HallwaySpawner : MonoBehaviour {

    private Transform myTransform;

    //Holds Hallway prefabs
    public GameObject hallway1;
    //public GameObject hallway2;
    //public GameObject hallway3;
    //public GameObject hallway4;

    //Holds Hallways currently in world
    public GameObject hall1;
    public GameObject hall2;

    //Holds number of hallways that has spawned
    private int hallwayNum = 1;
    private float hallwaySize = 100.0f;
    
    // Use this for initialization
	void Start () {
        myTransform = this.transform;

        //Populates Hall3
        hall2 = Instantiate(hallway1, new Vector3(100 * hallwayNum, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {

        //Culculates the distance from the start position
	    if(myTransform.position.x >= (hallwaySize * hallwayNum))
        {
            CreateHall();
        }
	}

    //Creates a new hallway and deletes the oldest one
    void CreateHall()
    {
        hallwayNum++;
        Destroy(hall1.gameObject);
        hall1 = hall2;
        hall2 = Instantiate(hallway1,new Vector3(100 * hallwayNum,0,0),new Quaternion (0,0,0,0)) as GameObject;
    }
}
