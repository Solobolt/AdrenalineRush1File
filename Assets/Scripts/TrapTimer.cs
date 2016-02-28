using UnityEngine;
using System.Collections;

public class TrapTimer : MonoBehaviour {

    //Holds timer values
    //ToDo add World timer get;
    private float timer = 0.0f;
    private float timerReset;

    //Postion Timers
    private float upTime = 0.57f;
    private float downTime = 0.5f;

    //Sets defualt trap postion to up
    public bool trapUp = true;

    //JUICE
    public AudioClip smash;
    private AudioSource source;
    private bool soundHasPlayed = false;

    public CameraFollow mainCam;

    // Use this for initialization
    void Start () {
        timerReset = downTime + upTime;
        source = this.gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        TimerSet();
        SetPosition();
    }

    //Sets trap position
    void SetPosition()
    {
        if (timer >= 0 && timer < upTime)
        {
            //traps up
            trapUp = true;

            //resets the fact that the sound has played
            soundHasPlayed = false;
        }
        else
        {
            //traps down
            trapUp = false;
            
            //Ensures that the sound is only played once
            if(soundHasPlayed == false)
            {
                PlaySounds(smash);

                //Add Screen shake
                mainCam.SetShake(0.2f);
            }
            soundHasPlayed = true;
            
        }
    }

    //Keeps The timer in Time
    void TimerSet()
    {
        //Incriments the timer
        timer += Time.deltaTime;

        //Keeps the timer within 1 accuratly
        if (timer >= timerReset)
        {
            timer -= timerReset;
        }
    }

    //plays sound with randomised pitch
    void PlaySounds(AudioClip clip)
    {

            source.pitch = Random.Range(0.3f, 1.5f);
            source.PlayOneShot(clip);
    }
}
