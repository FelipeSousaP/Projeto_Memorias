using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exemple_SceneControler : MonoBehaviour{
    [SerializeField] private float _sceneFadeDuration;
    private Exemple_SceneFade _sceneFade;

    private void Awake() {
        _sceneFade = GetComponentInChildren<Exemple_SceneFade>();
    }

    private IEnumerator Start() {
        yield return _sceneFade.FadeInCoroutine(_sceneFadeDuration);
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName) {
        yield return _sceneFade.FadeOutCoroutine(_sceneFadeDuration);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
