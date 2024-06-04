using Singleton;
using UnityEditor;
#if UNITY_EDITOR
using UnityEngine;
#endif
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button toMainMenuButton;

    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject optionsScreen;

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
        optionsButton.onClick.AddListener(GoToOptions);
        quitButton.onClick.AddListener(QuitGame);
        toMainMenuButton.onClick.AddListener(GoToMainMenu);

        volumeSlider.onValueChanged.AddListener(SetVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        GoToMainMenu();
    }

    private void Play()
    {
        GameManager.Instance.LoadLevel("Level1");
    }

    private void GoToOptions()
    {
        mainScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    private void GoToMainMenu()
    {
        mainScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    private void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }

    private void SetVolume(float newVolume)
    {
        //TODO: Conectar con el volumen del juego
        Debug.Log($"New sound volume is {newVolume}");
    }

    private void SetSFXVolume(float newVolume)
    {
        //TODO: Conectar con el volumen de efectos de sonido
        Debug.Log($"New sfx volume is {newVolume}");
    }
}