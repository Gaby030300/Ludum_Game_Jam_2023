using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] GameObject map;

    [Header("Settings")]
    [SerializeField] GameObject settings;

    void Update()
    {
        OpenMap();
        OpenSettings();
    }
    public void OpenMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            map.SetActive(!map.gameObject.activeSelf);
            if (map.gameObject.activeSelf == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

        }
    }

    public void OpenSettings()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settings.SetActive(!settings.gameObject.activeSelf);
            if (settings.gameObject.activeSelf == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnOptionsButton()
    {
        settings.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnCloseButton()
    {
        settings.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnExitButton()
    {
        Application.Quit();
    }
}
