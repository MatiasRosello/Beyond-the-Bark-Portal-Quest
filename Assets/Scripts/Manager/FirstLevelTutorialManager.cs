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

    public static FirstLevelTutorialManager Instance;

    [SerializeField] private TutorialText useSpaceText;
    [SerializeField] private TutorialText chestText;
    [SerializeField] private TutorialText swordText;
    [SerializeField] private GameObject chestWall;

    private Chest chest;
    private PlayerEquipment playerEquipment;
    private bool hasJumpedOverGap;
    private bool hasOpenedChest;

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

        yield return new WaitForSeconds(4f);
        swordText.Hide();
    }
}
