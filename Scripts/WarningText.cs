using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WarningText : MonoBehaviour {

    //This script will initially hide the text and then bring them out in the open after a certain period of time
    //First need access to the text and image
    Text definitionText;
    Image warningImage;

    //time which the warning sign will come out, although note we can add a random value to this time 
    //so that it isn't always the same time that the police will come
    public float TimePoliceArrive;
    public float AdditionalRandomTime;
    public float MinRandom, MaxRandom;


    //Need access to the animator to tell the player to runaway when the warning pops up
    //Animator is on player, so we need access to player animator
    GameObject myPlayerGO;
    Animator myPlayerAnim;

    void Awake()
    {
        definitionText = transform.GetChild(0).GetComponent<Text>();
        warningImage = transform.GetChild(1).GetComponent<Image>();

        definitionText.GetComponent<Text>().enabled = false; //at start of game, hide text
        warningImage.GetComponent<Image>().enabled = false;  //at start of game, hide image

        myPlayerGO = GameObject.Find("Player");
        myPlayerAnim = myPlayerGO.transform.GetChild(0).GetComponent<Animator>();

    }

    void Start()
    {
        AdditionalRandomTime = Random.Range(MinRandom, MaxRandom);
        StartCoroutine(WarningSign());
    }

    IEnumerator WarningSign()
    {
        yield return new WaitForSeconds(TimePoliceArrive + AdditionalRandomTime);
        definitionText.GetComponent<Text>().enabled = true; //show text
        warningImage.GetComponent<Image>().enabled = true;  //show image
        myPlayerAnim.SetBool("CanRunAway", true);
    }
}
