using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring_v2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public int scoreTotal = 0;
    public GameObject body;
    public GameObject prompt;
    public GameObject target;
    public Text heighttext;
    public Text prompttext;
    public GameObject faileffect;
    public int upperReleaseHeigth = 800;
    public int lowerReleaseHeigth = 500;
    private Vector3 bodyLoc;
    private float bodyheight;
    private Vector3 bodyInitialLoc;
    private Vector3 targetLoc;
    private double prompttime;

    
    void GetLoc()
    {
        bodyLoc = body.transform.position;
        bodyheight = body.transform.position.y;
    }

    void GetInitialLoc()
    {
        bodyInitialLoc = body.transform.position;
        targetLoc = target.transform.position;
    }

    void GraderJumping()
    {
        void deactiveFaileffect()
        {
            faileffect.SetActive(false);
        }

        if (Input.GetKeyDown("d"))
        {
            Debug.Log("the user has jumped");
            if ((Vector3.Distance(bodyLoc, bodyInitialLoc) >= 300) && (Vector3.Distance(bodyLoc, bodyInitialLoc) < 400))
            {
                score = 2;
                Debug.Log("Jumping Scored 2");
            }
            else if ((Vector3.Distance(bodyLoc, bodyInitialLoc) > 250) && (Vector3.Distance(bodyLoc, bodyInitialLoc) < 350))
            {
                score = 1;
                Debug.Log("Jumping Scored 1");
            }
            else
            {
                faileffect.SetActive(true);
                Debug.Log("Jumping Scored 0");
                Invoke("deactiveFaileffect", 1.5f);
            }
            scoreTotal += score;
        }
    }

    void GraderLanding()
    {
        void deactiveFaileffect()
        {
            faileffect.SetActive(false);
        }

        if (GameObject.Find("GroundTrigger").GetComponent<landingDetect>().landingState)
        {
            Debug.Log("the user has landed");
            if (Vector3.Distance(bodyLoc, targetLoc) < 100)
            {
                score = 2;
                Debug.Log("Landing Scored 2");
            }
            else if (Vector3.Distance(bodyLoc, targetLoc) < 200)
            {
                score = 1;
                Debug.Log("Landing Scored 1");
            }
            else
            {
                faileffect.SetActive(true);
                Debug.Log("Landing Scored 0");
                Invoke("deactiveFaileffect", 1.5f);
            }
        }
    }

    void GraderParachute()
    {
        void deactiveFaileffect()
        {
            faileffect.SetActive(false);
        }

        if (Input.GetKeyDown("f"))
        {
            Debug.Log("the parachute is released");
            if ((bodyheight < upperReleaseHeigth) && (bodyheight > lowerReleaseHeigth))
            {
                score = 2;
                Debug.Log("Scored 2");
            }
            else if ((bodyheight < upperReleaseHeigth + 200) && (bodyheight > lowerReleaseHeigth - 200))
            {
                score = 1;
                Debug.Log("Scored 1");
            }
            else if (bodyheight < 150)
            {
                faileffect.SetActive(true);
                Debug.Log("Scored 0");
                Invoke("deactiveFaileffect", 1.5f);

            }
        }
    }

    void promptupVertical(int h_threshold, int duration, string message)
    {
        void deactivePrompt()
        {
            prompt.SetActive(false);
        }

        if ((bodyheight <= h_threshold) && (bodyheight > (h_threshold - duration)))
        {
            prompt.SetActive(true);
            prompttext.text = message;
            Invoke("deactivePrompt", 10f);
        }
    }

    void promptupHorizontal(int distance, int duration, string message)
    {
        void deactivePrompt()
        {
            prompt.SetActive(false);
        }

        if ((Vector3.Distance(bodyLoc, bodyInitialLoc) >= distance) && (Vector3.Distance(bodyLoc, bodyInitialLoc) < distance + duration))
        {
            prompt.SetActive(true);
            prompttext.text = message;
            Invoke("deactivePrompt", 10f);
        }
    }

    void showheight()
    {
        heighttext.text = "Weather: Sunnyy Height: " + bodyheight.ToString("F1");
    }

    void Start()
    {
        GetInitialLoc();
        prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetLoc();
        GraderParachute();
        GraderJumping();
        GraderLanding();
        showheight();

        promptupHorizontal(0, 100, "Ok, Spotting! Use your eyes to look before you leave the airplane. Look at the landmarks to remember the landing area, and make sure you are above the general vicinity of the area. Wind direction and speed do make a difference, but your success in landing relies on how much you know where you want to exit the aircraft.");
        promptupHorizontal(200, 100, "When you see a green light illuminate, that’s the signal it’s time to jump. Lift your head onto their shoulder to assume the freefall position. You may have butterflies in your stomach, but you will enjoy the feeling of flying!");
        promptupVertical(800, 100, "As a learner of skydiving, you need to release a parachute at a higher location than skilled divers. Use the altimeter shown in the vision, when you are in the range of range from 4,500-6,000 feet,  open your parachute using the trigger button.");
        promptupVertical(500, 100, "You can control the parachute by pulling down on the steering lines which causes it to turn or to increase or decrease its rate of descent.  For example, pulling down your right controller will draw on the right steering toggle, and have you turn right. Pulling down the left makes it turn left, and pulling both at the same time forces the canopy to slow its rate of descent by flattening out.");
        promptupVertical(150, 100000000, "Your score is " + scoreTotal.ToString());

    }
}
