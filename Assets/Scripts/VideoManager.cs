using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<VideoPlayer>().targetCamera = Camera.main;
    }
}
