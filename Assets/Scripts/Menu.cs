using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private int buttonHeight;
    private int buttonWidth;
    private int origin_x;
    private int origin_y;
    private GUIStyle titleStyle;

    void Start () {
        buttonHeight = 50;
        buttonWidth = 200;
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;
        titleStyle = new GUIStyle();
    }
	
    void OnGUI()
    {
        titleStyle.fontSize = 30;
        titleStyle.alignment = TextAnchor.UpperCenter;
        GUI.Label(new Rect(origin_x, origin_y / 2, buttonWidth, buttonHeight), "Roll a ball", titleStyle);
        if(GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "Play")) {
            SceneManager.LoadScene(1);
        }
        if(GUI.Button(new Rect(origin_x, origin_y + buttonHeight * 2 + 20, buttonWidth, buttonHeight), "Exit")) {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
				Application.Quit();
			#endif
        }
    }
}