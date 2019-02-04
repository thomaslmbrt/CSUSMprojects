using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBack : MonoBehaviour {

    void OnGUI() {
        if(GUI.Button(new Rect(20, 40, 100, 50), "Menu")) {
            SceneManager.LoadScene(0);
        }
    }
}