using UnityEngine;

public class GateSoundController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip OpenGate;


    public void OpenGateSound()
    {
        audioSource.PlayOneShot(OpenGate);
    }
}

