using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointManager : MonoBehaviour {

    private int points = 0;
    private float multiplier = 1.0f;

    public Text pointsText;
    public Text multiText;

    private float maxMulti = 20.0f;

	// Use this for initialization
	void Start () {
        updatePoints();
        updateMulti();
	}
	
	// Update is called once per frame
	void Update () {

        multiplier += (1.0f - multiplier) * 0.1f * Time.deltaTime;
        updateMulti();
	}

    //Updates the text in the UI for points
    void updatePoints()
    {
        pointsText.text = ("Points: " + points);
    }

    //Updates the text in the UI for multiplier
    void updateMulti()
    {
        multiText.text = ("x" + ((Mathf.FloorToInt(multiplier * 100.0f)) / 100.0f));
    }

    //Adds point to the score
    public void addPoint()
    {
        points = points + Mathf.FloorToInt(1.0f * multiplier);
        updatePoints();
    }

    //Adds to your multiplier
    public void addMulti()
    {
        multiplier += 1.0f;
        if(multiplier > maxMulti)
        {
            multiplier = maxMulti;
        }
    }
}
