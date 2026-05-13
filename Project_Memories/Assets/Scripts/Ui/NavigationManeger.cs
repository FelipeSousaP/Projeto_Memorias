using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NavigationManager : MonoBehaviour
{
    public MenuPanel mainMenu;
    public MenuPanel creditsMenu;
    public MenuPanel settingsMenu;
    public MenuPanel controlsMenu;

    private MenuPanel currentActiveMenu;
    [SerializeField] private GameObject _actionPlayer;

    void Start()
    {
        _actionPlayer.SetActive(false);
        currentActiveMenu = mainMenu;
        mainMenu.Show();
    }

    public void SwitchToCredits() => ChangeMenu(creditsMenu);
    public void SwitchToSettings()
    {
        if (_actionPlayer != null) _actionPlayer.SetActive(false);
        if (currentActiveMenu != null)
        {
            currentActiveMenu.Hide();
        }

        if (settingsMenu != null)
        {
            settingsMenu.Show();
            currentActiveMenu = settingsMenu;
        }
        else
        {
            Debug.LogError("NavigationManager: SettingsMenu não está arrastado no Inspetor!");
        }
    }
    public void SwitchToControls() => ChangeMenu(controlsMenu); 
    public void BackToMain() => ChangeMenu(mainMenu);
    public void StartGameSequence()
    {
        if (currentActiveMenu != null) currentActiveMenu.Hide();
        if (_actionPlayer != null) _actionPlayer.SetActive(true);
        PlayerMenu pm = Object.FindAnyObjectByType<PlayerMenu>();
        if (pm != null)
        {
            pm.StartGameplay();
        }
    }

    private void ChangeMenu(MenuPanel targetMenu)
    {
        if (currentActiveMenu != null) currentActiveMenu.Hide();

        targetMenu.Show();
        currentActiveMenu = targetMenu;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}