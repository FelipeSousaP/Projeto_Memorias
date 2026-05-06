using UnityEngine;
using System.Collections;

public enum MenuState { Hidden, MovingIn, Visible, MovingOut }

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
public class MenuPanel : MonoBehaviour
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public RectTransform hiddenReference;
    public RectTransform visibleReference;
    public float transitionSpeed = 8f;

    private MenuState currentState = MenuState.Hidden;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Show()
    {
        if (currentState != MenuState.Visible && currentState != MenuState.MovingIn)
        {
            StopAllCoroutines();
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            StartCoroutine(ProcessTransition(visibleReference.anchoredPosition, MenuState.Visible));
        }
    }
    public void Hide()
    {
        if (currentState != MenuState.Hidden && currentState != MenuState.MovingOut)
        {
            StopAllCoroutines();
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            StartCoroutine(ProcessTransition(hiddenReference.anchoredPosition, MenuState.Hidden));
        }
    }

    private IEnumerator ProcessTransition(Vector2 targetPosition, MenuState finalState)
    {
        currentState = (finalState == MenuState.Visible) ? MenuState.MovingIn : MenuState.MovingOut;
        while (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) > 0.1f)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, Time.deltaTime * transitionSpeed);
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
        currentState = finalState;
        if (finalState == MenuState.Hidden)
        {
            canvasGroup.alpha = 0f;
        }
    }
}