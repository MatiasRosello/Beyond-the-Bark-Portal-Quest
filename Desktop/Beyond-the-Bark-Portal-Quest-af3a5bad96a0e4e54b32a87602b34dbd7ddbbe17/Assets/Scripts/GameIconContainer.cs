using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameIconContainer : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;

    public Sequence Tween()
    {
        Sequence sequence = DOTween.Sequence()
            .Join(backgroundImage.DOFade(1, 1f))
            .AppendInterval(1f)
            .Append(iconImage.DOFade(1, 3f))
            .AppendInterval(2f)
            .AppendCallback(OnTweenFinished);

        return sequence;
    }

    private void OnTweenFinished()
    {
        SceneTransitionManager.Instance.FadeIn(
            null,
            () => SceneManager.LoadScene("Level1"),
            null);
    }
}
