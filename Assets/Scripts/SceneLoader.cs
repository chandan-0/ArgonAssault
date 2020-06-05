using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadFirstScene",2f);
    }
    
    void loadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
