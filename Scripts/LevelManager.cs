using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float LoadNextLevel;
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 0){
            Invoke("LoadAfterSplash", LoadNextLevel);
        }
    }

    void LoadAfterSplash() {
        SceneManager.LoadScene(1);
    }

    public void LoadLevelName(string Name) {
        SceneManager.LoadScene(Name);
    }

    public void LoadRunningScene()
    {
        //TODO This is hardcoded at the moment, but I want the game to load the appropriate running scene depending on which level the player is playing.
        //but for now, lets load 03Running01
        SceneManager.LoadScene("03Running01");
    }
}
