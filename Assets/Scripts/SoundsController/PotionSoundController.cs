using UnityEngine;

public class PotionSoundController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickUppotion;


    public void pickUpPotionSound()
    {
        audioSource.PlayOneShot(pickUppotion);
    }
}
