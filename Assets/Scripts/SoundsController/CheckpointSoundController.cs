using UnityEngine;

public class CheckpointSoundController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip checkPoint;


    public void checkPointSound()
    {
        audioSource.PlayOneShot(checkPoint);
    }
}
