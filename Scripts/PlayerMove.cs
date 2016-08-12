using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour {
    //control player speed
    public float PlayerSpeed;

    //true or false if we can move up or down
    bool CanMoveUp, CanMoveDown;

    //lerp variables
    public float TimeTakenDuringLerp;
    public float DistantToMove;
    bool isLerping;
    Vector3 startPos, endPos;
    float timeStartedLerping;

    //clamp Y values
    public float MinY, MaxY;

    //I need an animator state to check if there is the road instantiator gameobject in the scene.  
    //If there is, then we can play the float in and player running state.
    //If there isn't, we just play the idle state.
    Animator myAnimator;

    //TODO horrible hardcoding.  For time being, use current build int to change animation parameter
    int sceneNumber;

    void Awake()
    {
        //animator on body of player gameobject
        myAnimator = transform.GetChild(0).GetComponent<Animator>();
        
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {

        CheckCanMoveUpOrDown(); // checks where the player is in the game and if they can move up or down in the scene.

        FloatInIfRoadInScene(); //checks if there is a road gameobject in the scene, if there is, can float in and start running.
        //move up or down, player lerps up and down
        //I want the player to only move in the Y direction from -2, 0, 2
        if (Input.GetKeyUp(KeyCode.UpArrow) && CanMoveUp)
        {
            PlayerMovesUp();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && CanMoveDown)
        {
            PlayerMovesDown();
        }
    }

    void FixedUpdate()
    {
        //is lerping is true once you hit the up or down arrows
        if (isLerping)
        {
            //time variables for lerp
            //this calculates a time difference
            float timeSinceStarted = Time.time - timeStartedLerping;

            //this takes the time difference and divides it by a 'TimeTakenDuringLerp' variable.  Basically, as time passes,
            //this 'percentageComplete' value gets closer to '1'.
            //Once we reach '1', the the lerp is complete, and isLerping can be true (and end)
            float percentageComplete = timeSinceStarted / TimeTakenDuringLerp;

            transform.position = Vector3.Lerp(startPos, endPos, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                isLerping = false;
            }
        }

        //clamp y position of player
        transform.position = new Vector3 (transform.position.x, Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);
    }

    void CheckCanMoveUpOrDown()
    {
        if (transform.position.y <= -2) {
            CanMoveUp = true;
            CanMoveDown = false;
        }

        if (transform.position.y >= 2) {
            CanMoveUp = false;
            CanMoveDown = true;
        }

        if (transform.position.y > -2 && transform.position.y < 2) {
            CanMoveUp = true;
            CanMoveDown = true;
        }
    }

    void StartLerping()
    {

        isLerping = true;
        timeStartedLerping = Time.time;
        //set the start position to the transform position
        startPos = transform.position;
        //set the final position to be a y position + or - a distant to move
        endPos = transform.position;
        endPos.y = transform.position.y + DistantToMove;
    }

    void PlayerMovesUp ()
    {
        //plus 2 to the y position
        DistantToMove = MaxY;
        StartLerping();
    }

    void PlayerMovesDown()
    {
        //minus 2 to the y position
        DistantToMove = MinY;
        StartLerping();
    }

    //TODO this is horrible hard coding.
    //How can we tell this is the running scene!!!
    void FloatInIfRoadInScene() {
        if (sceneNumber == 3)
        {
            myAnimator.SetBool("CanFloatIn", true);
        }
    }
}
