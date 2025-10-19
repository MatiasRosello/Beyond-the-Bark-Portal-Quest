using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoints : MonoBehaviour
{
    public Transform LastCheckPoint => lastCheckPoint;

    [SerializeField] private Text checkPointText;

    private Transform lastCheckPoint;
    private RectTransform checkPointTextRectTransform;

    private void Awake()
    {
        checkPointTextRectTransform = checkPointText.GetComponent<RectTransform>();
    }

    public void UpdateLastCheckPoint(Transform newCheckPoint)
    {
        lastCheckPoint = newCheckPoint;

        Color checkPointTextColor = checkPointText.color;
        checkPointTextColor.a = 0;
        checkPointText.color = checkPointTextColor;

        checkPointText.text = "Check Point " + newCheckPoint.gameObject.name.Replace("CheckPoint - ", "") + "!";

        checkPointText.DOFade(1, 0.5f);

        checkPointTextRectTransform.anchoredPosition = Vector2.zero;
        checkPointTextRectTransform.DOAnchorPosY(150f, 0.5f);
    }
}
