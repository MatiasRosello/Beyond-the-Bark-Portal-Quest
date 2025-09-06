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
        yield return new WaitForSeconds(0.75f);
        wasdTutorialText.Show();
        yield return new WaitForSeconds(5f);
        wasdTutorialText.Hide();
        yield return new WaitForSeconds(2f);

        shiftTutorialText.Show();
        yield return new WaitForSeconds(5f);
        shiftTutorialText.Hide();
    }
}
