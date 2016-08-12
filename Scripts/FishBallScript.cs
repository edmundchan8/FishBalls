using UnityEngine;
using System.Collections;

public class FishBallScript : MonoBehaviour {

    //I want this script to start the fishball animation showing
    //Then when the player sees the fishballs, the player can select them and get money for the fishballs
    //I want the animation to play randomly.
    //I want the money to be stored in a player preference somewhere.

    //The fishball animator
    Animator FishBallAnimator;

    //Time to play fishball animator
    public int MinFishBallPlayTime, MaxFishBallPlayTime;
    public float Timer, TimeTillFishBall;

    void Start()
    {
        FishBallAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        Timer = Time.timeSinceLevelLoad;
        if (Timer >= TimeTillFishBall)
        {
            TimeTillFishBall += Time.time;
            StartCoroutine(PlayFishBallAnimation());
        }
    }

    IEnumerator PlayFishBallAnimation()
    {
        yield return new WaitForSeconds(0f);
        FishBallAnimator.SetTrigger("CanFishBall");
    }
}
