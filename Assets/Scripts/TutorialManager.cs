using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialText wasdTutorialText;
    [SerializeField] private TutorialText shiftTutorialText;

    [SerializeField] private GameObject playerFollowCamera;
    [SerializeField] private GameObject secondTutorialStepCamera;

    private ThirdPersonController thirdPersonController;

    private void Awake()
    {
        thirdPersonController = FindFirstObjectByType<ThirdPersonController>();
    }

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
        yield return new WaitForSeconds(2f);

        SceneTransitionManager.Instance.FadeInSameScene(OnFadeInFinished, OnFadeOutStarted,OnFadeOutFinished);
    }

    private void OnFadeInFinished()
    {
        thirdPersonController.enabled = false;
        thirdPersonController.GetComponent<Animator>().SetFloat("Speed", 0);
    }

    private void OnFadeOutStarted()
    {
        StartCoroutine(ChangeCameraDelayCoroutine());
    }

    private IEnumerator ChangeCameraDelayCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        playerFollowCamera.SetActive(false);
        secondTutorialStepCamera.SetActive(true);
    }

    private void OnFadeOutFinished()
    {
        // Start actual sequence
    }
}
