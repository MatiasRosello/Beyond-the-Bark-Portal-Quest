using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialText wasdTutorialText;
    [SerializeField] private TutorialText shiftTutorialText;
    [SerializeField] private TutorialText goToTheFirstObjectiveText;
    [SerializeField] private TutorialText yourDogText;

    [Space(15)]

    [SerializeField] private GameObject playerFollowCamera;
    [SerializeField] private GameObject secondTutorialStepCamera;

    [Space(15)]

    [SerializeField] private Transform firstPlayerTarget;
    [SerializeField] private GameObject firstTutorialTrigger;
    [SerializeField] private GameObject firstWall;

    private ThirdPersonController thirdPersonController;
    private GameObject player;
    private DogTutorialController dogTutorialController;

    private void Awake()
    {
        thirdPersonController = FindFirstObjectByType<ThirdPersonController>();
        dogTutorialController = FindFirstObjectByType<DogTutorialController>();
    }

    private void OnEnable()
    {
        dogTutorialController.OnReachedPortal.AddListener(DogTutorialController_OnReachedPortal);
    }

    private void Start()
    {
        StartCoroutine(FirstTutorialStepCoroutine());

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDisable()
    {
        dogTutorialController.OnReachedPortal.RemoveListener(DogTutorialController_OnReachedPortal);
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
        goToTheFirstObjectiveText.Show();
        firstWall.SetActive(false);
        firstTutorialTrigger.SetActive(true);

    }

    public void FirstTutorialTrigger_OnTriggerEnterWithPlayer()
    {
        goToTheFirstObjectiveText.Hide();

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

        dogTutorialController.StartMovingToPortal();
    }

    private void DogTutorialController_OnReachedPortal()
    {
        thirdPersonController.enabled = true;
        yourDogText.Show();
    }
}
