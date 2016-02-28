using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    //Holds the object that the camera follows
    public GameObject player;

    //Holds this objects transform
    private Transform myTransform;
    private Vector3 currentPos;
    private float camOffset = 6.5f;

    private float shake = 0.5f;
    private float currentShake = 0.0f;

    //Found
    private float ShakeY = 0.8f;
    private float ShakeYSpeed = 0.8f;

    // Use this for initialization
    void Start () {
        myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        LerpToPlayer();
        ShakeCamera();
    }

    //Lerps the camera towards the player
    void LerpToPlayer()
    {
        currentPos = myTransform.position;
        currentPos.x += ((player.transform.position.x + camOffset) - currentPos.x) * 10.0f * Time.deltaTime;
        myTransform.position = currentPos;
    }

    //Sets the amount that the camera must shake
    public void SetShake(float someY)
    {
        ShakeY = someY;
    }

    //Shakes the camera when ShakeY is set
    void ShakeCamera()
    {
        Vector2 _newPosition = new Vector2(0, ShakeY);
        if (ShakeY < 0)
        {
            ShakeY *= ShakeYSpeed;
        }
        ShakeY = -ShakeY;
        transform.Translate(_newPosition, Space.Self);
    }
}
