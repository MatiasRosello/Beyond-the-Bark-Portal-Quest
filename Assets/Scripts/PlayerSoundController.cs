using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attack;
    
    //[SerializeField] private AudioClip damage;//
    //[SerializeField] private AudioClip death;//

    public void attackSound()
    {
        audioSource.PlayOneShot(attack);
    }


   
    /* public void damageSound()
     {
         audioSource.PlayOneShot(damage);
     }
     */

    /* public void deathSound()
    {
        audioSource.PlayOneShot(death);
    }
    */
}
