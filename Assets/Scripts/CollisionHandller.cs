using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandller : MonoBehaviour
{
    [Tooltip("Marne ke baad kitna der rukega")][SerializeField] private float LevenLoadDelay = 1f;
    [Tooltip("Marne waala sound ka partical prefab")][SerializeField] private GameObject DeathFX;
    void OnTriggerEnter(Collider other)
    {
        print("Player triggerd with something : ");
        StartDeathsequance();
        DeathFX.SetActive(true);
        Invoke("reloadScene",LevenLoadDelay);
    }
    private void reloadScene() // String Reference
    {
        SceneManager.LoadScene(1);
    }
    private void StartDeathsequance()
    {
        print("you are DEAD..");
        SendMessage("onPlayerDeath");
    }
}
