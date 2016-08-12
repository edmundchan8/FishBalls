using UnityEngine;
using System.Collections;

public class HazardInstantiator : MonoBehaviour
{
    
    //This script to randomly generate hazards
   
    //array of YPosChoice for position of y of the hazard when instantiated
    float[] YPosChoice = new float [3];

    //array of hazardChoices to choose from, currently 10/08/2016 - only 2 hazards
    GameObject[] hazardChoice = new GameObject[2];

    //position of the instantiated hazard gameobject
    public Vector3 hazardPos;
    public float XPos; //to control when on the x value this instantiates from
    
    //my prefabs are all on the game manager script
    GameObject hazardGameManagerGO;
    GameManager hazardGameManager;

    //TODO create a folder in the scene to store the instantiated hazards
    public GameObject HazardFolder;

    //Ienumerator values
    public float TimeTillStartInstantiate;

    //a public static gameobject so that from external scripts can set to this static gameobject which hazard prefab
    //do we want to instantiate.
    public static GameObject chosenGameObject;

    void Start()
    {
        hazardGameManagerGO = GameObject.Find("Game Manager");
        hazardGameManager = hazardGameManagerGO.GetComponent<GameManager>();
        
        //TODO learn about arrays, but for mean time, hard code array values
        YPosChoice[0] = -2.5f; YPosChoice[1] = 0; YPosChoice[2] = 2.5f;

        //TODO as above learn about arrays, hazard prefabs are on the gamemanager, is there another way to find the prefabs to put into this code.
        hazardChoice[0] = hazardGameManager.BoxHazard;
        hazardChoice[1] = hazardGameManager.PlankHazard;

        //TODO create a folder in the scene to store the instantiated hazards
        HazardFolder = GameObject.Find("Hazard Folder");
        if (HazardFolder == null)
        {
            HazardFolder = new GameObject("Hazard Folder");
        }

        hazardPos.x = XPos; //sets the x position of the hazard, basically to start from the right of the screen

        //call the IEnumerator
        StartCoroutine(InstantiateHazard());
    }

    void FixedUpdate()
    {

    }

    IEnumerator InstantiateHazard()
    {
        //TO DO again, hard coded, maybe when game ends, this is false
        while (true)
        {
            yield return new WaitForSeconds(TimeTillStartInstantiate); //TODO change this code to change as level gets harder
            float yPos = YPosChoice[Random.Range(0, 3)]; //this take a value between 0 to 2, and affects the y position of the hazard
            chosenGameObject = hazardChoice[Random.Range(0,hazardChoice.Length)]; //this takes a value between 0 - 1 and determines which hazard to make.
                                                                //TODO maybe shouldn't use 2, should use hazardChoice[].length
            hazardPos.y = yPos;
            GameObject hazardPrefab = Instantiate(chosenGameObject, hazardPos, transform.rotation) as GameObject;
            hazardPrefab.transform.parent = HazardFolder.transform;
        }
    }
}
