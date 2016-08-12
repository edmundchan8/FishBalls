using UnityEngine;
using System.Collections;

public class RoadMover : MonoBehaviour {

    //road moving speed;
    public float RoadSpeed;

    //access to Road rigidbody
    Rigidbody2D roadRigidbody2D;

	void Start () {
        roadRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        //move road in x direction, controlled from hierarchy
        roadRigidbody2D.velocity = new Vector2(RoadSpeed, 0);
	}
}
