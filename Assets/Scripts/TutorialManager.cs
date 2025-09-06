using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialText wasdTutorialText;
    [SerializeField] private TutorialText shiftTutorialText;

    private void Start()
    {
        StartCoroutine(FirstTutorialStepCoroutine());
    }

    private IEnumerator FirstTutorialStepCoroutine()
    {
        yield return new WaitForSeconds(1f);
        wasdTutorialText.Show();
        yield return new WaitForSeconds(2.5f);
        wasdTutorialText.Hide();
        yield return new WaitForSeconds(1.5f);

        shiftTutorialText.Show();
        yield return new WaitForSeconds(2.5f);
        shiftTutorialText.Hide();
    }
}
