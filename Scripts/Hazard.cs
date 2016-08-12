using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

    //want this script to move automatically by itself

    public float HazardSpeed;

    Rigidbody2D hazardRigidbody2D;

    void Start()
    {
        hazardRigidbody2D = gameObject.transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //we multiply the hazardspeed by -1 because otherwise it would go from left to right
        hazardRigidbody2D.velocity = new Vector2(HazardSpeed * -1, 0);
    }
}
