using UnityEngine;

public class BarGates : MonoBehaviour
{
    [SerializeField] private GateSoundController soundController;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();


            if (playerInventory != null)
            {

                if (playerInventory.HasKey())
                {
                    Debug.Log("¡Barrotes abiertos!");


                    if (soundController != null)
                    {
                        soundController.OpenGateSound();
                    }


                    GetComponent<Collider>().enabled = false;


                    if (GetComponent<MeshRenderer>() != null)
                    {
                        GetComponent<MeshRenderer>().enabled = false;
                    }


                    Destroy(gameObject, 1.0f);
                }
            }
        }
    }
}
