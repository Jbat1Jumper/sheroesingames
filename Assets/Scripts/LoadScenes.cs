
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // Start is called before the first frame update

    public void Start()
    {
        // ensure translations are loaded
        Translations.ChangeLanguage(Translations.CurrentLanguage);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("LoadScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ChangeLanguage()
    {
        Translations.ChangeLanguage(Translations.NextLanguage);
    }
}
