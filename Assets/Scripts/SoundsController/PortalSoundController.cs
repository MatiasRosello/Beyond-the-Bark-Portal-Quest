using UnityEngine;

public class PortalSoundController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip enterPortal;


    public void EnterPortalSound()
    {
        audioSource.PlayOneShot(enterPortal);
    }
}
