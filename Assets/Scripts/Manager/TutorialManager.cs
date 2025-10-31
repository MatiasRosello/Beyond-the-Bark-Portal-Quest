using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    [SerializeField] private TutorialImage icono;
    [SerializeField] private TutorialImage border;
    [SerializeField] private TutorialText wasdTutorialText;
    [SerializeField] private TutorialText shiftTutorialText;
    [SerializeField] private TutorialText goToTheFirstObjectiveText;
    [SerializeField] private TutorialText goToTheFirstObjectiveText2;
    [SerializeField] private TutorialText yourDogText;
    [SerializeField] private TutorialText yourDogText2;

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
    private DogMove dogMove;

    private void Awake()
    {
        Instance = this;
        thirdPersonController = FindFirstObjectByType<ThirdPersonController>();
        dogTutorialController = FindFirstObjectByType<DogTutorialController>();
        dogMove = FindFirstObjectByType<DogMove>();
    }

    private void OnEnable()
    {
        dogTutorialController.OnReachedPortal.AddListener(DogTutorialController_OnReachedPortal);
    }

    private void Start()
    {
        StartCoroutine(FirstTutorialStepCoroutine());

        player = GameObject.FindGameObjectWithTag("Player");

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        dogTutorialController.OnReachedPortal.RemoveListener(DogTutorialController_OnReachedPortal);
    }

    private IEnumerator FirstTutorialStepCoroutine()
    {
        yield return new WaitForSeconds(0.75f);
        icono.Show();
        border.Show();
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

        yield return new WaitForSeconds(1.5f);
        goToTheFirstObjectiveText.Hide();

        yield return new WaitForSeconds(1f);
        goToTheFirstObjectiveText2.Show();
    }

    public void FirstTutorialTrigger_OnTriggerEnterWithPlayer()
    {
        goToTheFirstObjectiveText2.Hide();
        icono.Hide();
        border.Hide();

        firstTutorialTrigger.SetActive(false);

        dogMove.enabled = false;

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

    public void DogTutorialController_OnReachedPortal()
    {
        StartCoroutine(DogReachedPortalCoroutine());
    }

    private IEnumerator DogReachedPortalCoroutine()
    {
        thirdPersonController.enabled = true;
        icono.Show();
        border.Show();
        yourDogText.Show();

        yield return new WaitForSeconds(1.5f);
        yourDogText.Hide();

        yield return new WaitForSeconds(1f);
        yourDogText2.Show();
    }
}
