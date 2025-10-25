using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialImage : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();

        // Opcional: asegurar que la imagen esté transparente al inicio
        if (image != null)
        {
            Color tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
        }
    }

    public void Show()
    {
        image.enabled = true;
        // Solo fade in, sin modificar la escala
        image.DOFade(1f, 1f).SetEase(Ease.InOutQuad);
    }

    public void Hide()
    {
        // Solo fade out, sin modificar la escala
        image.DOFade(0f, 1f).SetEase(Ease.InOutQuad);
    }
}