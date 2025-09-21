using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [SerializeField] private Image image;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void FadeIn(Action OnFadeInFinished = null, Action OnFadeOutStarted = null, Action OnFadeOutFinished = null)
    {
        image.DOFade(1f, 1.75f)
            .OnComplete(() =>
            {
                OnFadeInFinished?.Invoke();
                image.DOFade(0f, 1.75f)
                    .SetDelay(0.85f)
                    .OnStart(() => OnFadeOutStarted?.Invoke())
                    .OnComplete(() => OnFadeOutFinished?.Invoke());
            });
    }
}
