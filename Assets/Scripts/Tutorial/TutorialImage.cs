using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialImage : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();

        if (image != null)
        {
            Color tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
        }
    }

    public void Show()
    {
        image.DOFade(1f, 1f).SetEase(Ease.InOutQuad);
    }

    public void Hide()
    {
        image.DOFade(0f, 1f).SetEase(Ease.InOutQuad);
    }

}