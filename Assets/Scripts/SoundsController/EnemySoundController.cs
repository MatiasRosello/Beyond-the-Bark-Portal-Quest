using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ZombieDamage;


    public void ZombieDamageSound()
    {
        audioSource.PlayOneShot(ZombieDamage);
    }
}
