using UnityEngine;

public class UIManeger : MonoBehaviour
{
    static UIManeger _instance;
    private void Awake() { if (_instance == null) { _instance = this; } }
    public static UIManeger Instance => _instance;    

    public void Hide(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    public void Show(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    public void PauseGame(){Time.timeScale = 0;}
    public void ActiveGame() { Time.timeScale = 1;}
}
