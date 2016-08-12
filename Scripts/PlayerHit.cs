using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {

    //This script checks to see if the player has been hit by a hazard.  If they have, then initially, I want this script to notify
    //the player that the player has been hit.  eventually, this will allow the police to catch up to the player a lot sooner

    public string CaughtScene;

    void OnTriggerEnter2D(Collider2D myCollider2D)
    {
        if (myCollider2D.transform.tag == "Player")
        {
            SceneManager.LoadScene(CaughtScene);
        }
    }
}
