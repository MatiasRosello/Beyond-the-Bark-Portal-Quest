using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialText wasdTutorialText;
    [SerializeField] private TutorialText shiftTutorialText;

    [Space(15)]

    [SerializeField] private GameObject playerFollowCamera;
    [SerializeField] private GameObject secondTutorialStepCamera;

    [Space(15)]

    [SerializeField] private Transform firstPlayerTarget;
    [SerializeField] private GameObject firstTutorialTrigger;
    [SerializeField] private GameObject firstWall;

    private ThirdPersonController thirdPersonController;
    private GameObject player;

    private void Awake()
    {
        thirdPersonController = FindFirstObjectByType<ThirdPersonController>();
    }

    private void Start()
    {
        StartCoroutine(FirstTutorialStepCoroutine());

        player = GameObject.FindGameObjectWithTag("Player");
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

        firstWall.SetActive(false);
        firstTutorialTrigger.SetActive(true);

        // SceneTransitionManager.Instance.FadeInSameScene(OnFadeInFinished, OnFadeOutStarted);
    }

    public void FirstTutorialTrigger_OnTriggerEnterWithPlayer()
    {
        firstTutorialTrigger.SetActive(false);

        thirdPersonController.enabled = false;
        thirdPersonController.GetComponent<Animator>().SetFloat("Speed", 0);

        StartCoroutine(ChangeCameraDelayCoroutine());
    }

    private IEnumerator ChangeCameraDelayCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        playerFollowCamera.SetActive(false);
        secondTutorialStepCamera.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        thirdPersonController.enabled = true;
    }
}
