using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FirstLevelTutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialText useSpaceText;
    [SerializeField] private TutorialText chestText;

    private Chest chest;

    private void Awake()
    {
        chest = FindFirstObjectByType<Chest>();
    }

    private void Start()
    {
        StartCoroutine(FirstLevelTutorialCoroutine());
    }

    private IEnumerator FirstLevelTutorialCoroutine()
    {
        yield return new WaitForSeconds(1.25f);
        useSpaceText.Show();

        yield return new WaitForSeconds(3.25f);
        useSpaceText.Hide();

        yield return new WaitForSeconds(0.5f);
        chestText.Show();
        chest.CanBeOpened = true;
    }
}
