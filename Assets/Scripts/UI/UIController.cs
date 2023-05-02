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

    [Header("Instructions")]
    [SerializeField] GameObject instructions;

    void Update()
    {
        OpenMap();
        OpenSettings();
    }
    public void OpenMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.instance.PlaySFX("Button");
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
            AudioManager.instance.PlaySFX("Button");
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
        AudioManager.instance.PlaySFX("Button");
        SceneManager.LoadScene("GameScene");
    }

    public void OnOptionsButton()
    {
        AudioManager.instance.PlaySFX("Button");
        settings.SetActive(true);
    }
    public void OnMenuButton()
    {
        AudioManager.instance.PlaySFX("Button");
        SceneManager.LoadScene("Menu");
    }
    public void OnCloseButton()
    {
        AudioManager.instance.PlaySFX("Button");
        settings.SetActive(false);
    }
    public void OnCloseInstructionsButton()
    {
        AudioManager.instance.PlaySFX("Button");
        instructions.SetActive(false);
    }
    public void OnPlayAgainButton()
    {
        AudioManager.instance.PlaySFX("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnCreditsButton()
    {
        AudioManager.instance.PlaySFX("Button");
        SceneManager.LoadScene("Credits");
    }
    public void OnExitButton()
    {
        AudioManager.instance.PlaySFX("Button");
        Application.Quit();
    }
}
