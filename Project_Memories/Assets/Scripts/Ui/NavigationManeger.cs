using UnityEngine;
using UnityEngine.UI;

public class NavigationManager : MonoBehaviour
{
    public MenuPanel mainMenu;
    public MenuPanel creditsMenu;
    public MenuPanel settingsMenu;
    public MenuPanel controlsMenu;

    private MenuPanel currentActiveMenu;

    void Start()
    {
        currentActiveMenu = mainMenu;
        mainMenu.Show();
    }

    public void SwitchToCredits() => ChangeMenu(creditsMenu);
    public void SwitchToSettings() => ChangeMenu(settingsMenu);
    public void SwitchToControls() => ChangeMenu(controlsMenu);
    public void BackToMain() => ChangeMenu(mainMenu);
    public void StartGameSequence()
    {
        mainMenu.Hide();
        FindObjectOfType<PlayerMenu>().StartGameplay();
    }

    private void ChangeMenu(MenuPanel targetMenu)
    {
        if (currentActiveMenu != null)
        {
            currentActiveMenu.Hide();
        }

        targetMenu.Show();
        currentActiveMenu = targetMenu;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}