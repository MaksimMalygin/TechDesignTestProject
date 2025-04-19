using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class MenuButtons : MonoBehaviour
{
    public void GoToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SwitchLocale()
    {
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])//0=RU,1=EN
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }
        else
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
