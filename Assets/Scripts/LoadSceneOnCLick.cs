using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnCLick : MonoBehaviour
{
    public void LoadByIndex(int idxScene)
    {
        SceneManager.LoadScene(idxScene);
    }
}
