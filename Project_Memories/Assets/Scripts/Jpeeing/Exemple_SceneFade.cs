using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Exemple_SceneFade : MonoBehaviour{
    private Image _sceneFadeImage;
    private void Awake() {
        _sceneFadeImage = GetComponent<Image>();
    }

    public IEnumerator FadeInCoroutine(float duration) {
        Color originalColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);
        Color targetColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 0);

        yield return FadeCoroutine(originalColor, targetColor, duration);
        gameObject.SetActive(false);
    }

    public IEnumerator FadeOutCoroutine(float duration) {
        Color originalColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 0);
        Color targetColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);

        gameObject.SetActive(true);
        yield return FadeCoroutine(originalColor, targetColor, duration);
    }

    private IEnumerator FadeCoroutine(Color originalColor, Color targetColor, float duration) {

        float elapsedTime = 0;
        float elapsedPercentage = 0;

        while (elapsedPercentage < 1) {
            elapsedPercentage = elapsedTime / duration;
            _sceneFadeImage.color = Color.Lerp(originalColor, targetColor, elapsedPercentage);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
    }
}
