using UnityEngine;

public class JumpTutorialTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FirstLevelTutorialManager.Instance.HasJumpedOverGap = true;
        }
    }
}