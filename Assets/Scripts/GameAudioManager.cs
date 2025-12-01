using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    void Start()
    {
        if (GameVariables.muted)
        {
            foreach (var source in FindObjectsByType<AudioSource>(FindObjectsSortMode.None))
            {
                source.volume = 0;
            }
        }
    }
}
