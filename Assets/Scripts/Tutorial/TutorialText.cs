using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialText : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void Show()
    {
        text.DOFade(1f, 1f);
    }

    public void Hide()
    {
        text.DOFade(0f, 1f);
    }
}