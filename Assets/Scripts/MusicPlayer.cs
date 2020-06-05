
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    private int Length;
    private void Awake(){
        int numMusicPlayers = FindObjectOfType<MusicPlayer>().Length;
        print("Num of musicplayers in this scene" + numMusicPlayers);
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
