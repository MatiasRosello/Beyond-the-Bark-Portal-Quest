using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FirstLevelTutorialManager : MonoBehaviour
{
    public bool HasJumpedOverGap
    {
        get => hasJumpedOverGap;
        set => hasJumpedOverGap = value;
    }
    public bool HasOpenedChest
    {
        get => hasOpenedChest;
        set => hasOpenedChest = value;
    }

    public bool HasLlave
    {
        get => hasLlave;
        set => hasLlave = value;
    }

    public static FirstLevelTutorialManager Instance;

    [SerializeField] private TutorialImage icono;
    [SerializeField] private TutorialImage border;
    [SerializeField] private TutorialText useSpaceText;
    [SerializeField] private TutorialText chestText;
    [SerializeField] private TutorialText swordText;
    [SerializeField] private TutorialText swordText2;
    [SerializeField] private TutorialText llaveText;
    [SerializeField] private TutorialText llaveText2;
    [SerializeField] private GameObject chestWall;

    private Chest chest;
    private PlayerEquipment playerEquipment;
    private bool hasJumpedOverGap;
    private bool hasOpenedChest;
    private bool hasLlave;

    private void Awake()
    {
        chest = FindFirstObjectByType<Chest>();
        playerEquipment = FindFirstObjectByType<PlayerEquipment>();
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(FirstLevelTutorialCoroutine());
    }

    private IEnumerator FirstLevelTutorialCoroutine()
    {
        yield return new WaitForSeconds(1.25f);
        useSpaceText.Show();
        icono.Show();
        border.Show();

        yield return new WaitUntil(() => hasJumpedOverGap);
        useSpaceText.Hide();

        yield return new WaitForSeconds(1f);
        chestText.Show();
        chest.CanBeOpened = true;

        yield return new WaitUntil(() => hasOpenedChest);
        chestText.Hide();
        playerEquipment.TurnOnSword();
        chestWall.SetActive(false);

        yield return new WaitForSeconds(1f);
        swordText.Show();

        yield return new WaitForSeconds(2f);
        swordText.Hide();

        yield return new WaitForSeconds(1f);
        swordText2.Show();

        yield return new WaitForSeconds(3f);
        swordText2.Hide();
        icono.Hide();
        border.Hide();

        yield return new WaitUntil(() => hasLlave);
        icono.Show();
        border.Show();
        llaveText.Show();

        yield return new WaitForSeconds(2f);
        llaveText.Hide();

        yield return new WaitForSeconds(1f);
        llaveText2.Show();

        yield return new WaitForSeconds(4f);
        llaveText2.Hide();
        icono.Hide();
        border.Hide();
    }
}
