using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

    //public positions to say where the gameobject will appear from
    public float XPos, YPos;
    Vector3 instantiatePos;

    //access Gamemanager, which has the prefabs
    GameObject GameManagerGO;
    GameManager myGameManager;

    //the road prefab on the child of the gamemanager
    GameObject roadPrefab;

    //Time in which to instantiate the road prefab
    public float InstantiateTime;

    //find the RoadHolder gameobject
    GameObject roadHolder;

    void Start() {
        GameManagerGO = GameObject.Find("Game Manager");
        myGameManager = GameManagerGO.GetComponent<GameManager>();

        roadPrefab = myGameManager.RoadPrefab;

        //where to instantiate the road prefab
        instantiatePos = new Vector3(XPos, YPos, 1f);
        StartCoroutine(InstantiateRoad());

        //find the RoadHolder gameobject in scene
        roadHolder = GameObject.Find("Road Holder");
        if (roadHolder == null) {
            roadHolder = new GameObject("Road Holder");
        }

    }

    void FixedUpdate (){
        if (GameManagerGO == null) { print("GameManagerGO is null"); }
        if (myGameManager == null) { print("myGameManager is null"); }
        if (roadPrefab == null) { print("road prefab is null"); }

        //When you instantiate a gameobject, access the prefabs in the gamemanager

    }

    IEnumerator InstantiateRoad() {
        //TODO change the 'true' to a parameter, or always leave as true
        //but if ever false, StopCoroutine
        while (true) {
            yield return new WaitForSeconds(InstantiateTime);

            //instantiate the road prefabs as a child of RoadHolder
            GameObject prefab = Instantiate(roadPrefab, instantiatePos, transform.rotation) as GameObject;
            prefab.transform.parent = roadHolder.transform;
            
        }
        
    }
    
}
