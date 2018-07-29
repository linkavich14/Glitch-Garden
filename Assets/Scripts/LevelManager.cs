using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNestLevelAfter;

     void Start() {
        if(autoLoadNestLevelAfter == 0) {
            
        }else {
            Invoke("LoadNextLevel", autoLoadNestLevelAfter);
        }
    }

    public void LoadLevel(string name){		
        SceneManager.LoadScene(name);
    }

	public void QuitRequest(){
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
        }

}
