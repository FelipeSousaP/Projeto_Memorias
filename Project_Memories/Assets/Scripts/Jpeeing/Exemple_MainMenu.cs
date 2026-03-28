using UnityEngine;
using UnityEngine.SceneManagement;

public class Exemple_MainMenu : MonoBehaviour{

    [SerializeField] private Exemple_SceneControler _sceneControler;

    public void Play() {
        SceneManager.LoadScene("level_bruto");
    }

    public void Menu() {
        _sceneControler.LoadScene("TitleScreen");
    }

    public void Options() {
        _sceneControler.LoadScene("Options");
    }

    public void Controls() {
        _sceneControler.LoadScene("Controls");
    }

    public void Quit() {
        Application.Quit();
    }
}
