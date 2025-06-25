using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverMenuEvents : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;

    [SerializeField] private UIDocument hudUIDocument;

    private UIDocument uiDocument;
    private Button restartButton;
    private Button reviveButton;
    private List<Button> buttons;

    private AudioSource audioSource;

    public static GameOverMenuEvents SharedInstance;
    void Awake()
    {
        SharedInstance = this;

        uiDocument = GetComponent<UIDocument>();
        uiDocument.rootVisualElement.style.visibility = Visibility.Hidden;

        restartButton = uiDocument.rootVisualElement.Q("RestartButton") as Button;
        restartButton.RegisterCallback<ClickEvent>(OnRestartButtonClick);

        reviveButton = uiDocument.rootVisualElement.Q("ReviveWatchingAdButton") as Button;
        reviveButton.RegisterCallback<ClickEvent>(OnReviveWatchingAdButtonClick);

        buttons = uiDocument.rootVisualElement.Query<Button>().ToList();

        foreach (var button in buttons)
        {
            button.RegisterCallback<ClickEvent>(OnButtonClickPlaySound);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        restartButton.UnregisterCallback<ClickEvent>(OnRestartButtonClick);

        foreach (var button in buttons)
        {
            button.UnregisterCallback<ClickEvent>(OnButtonClickPlaySound);
        }
    }

    private void OnButtonClickPlaySound(ClickEvent evt)
    {
        audioSource.Play();
    }

    private void OnRestartButtonClick(ClickEvent evt)
    {
        ReloadScene();
    }

    private void OnReviveWatchingAdButtonClick(ClickEvent evt)
    {
        // WARN(Ahmed) this will cause problems when we have multiple players
        // find an alternative to revive dead players, maybe add them to a list when they die?
        if (playerGameObject.TryGetComponent<Health>(out Health health))
        {
            health.Revive();
            HideUI();
        }
    }

    void ReloadScene()
    {
        // TODO(Ahmed) change this so that the player is sent back to the beginning of the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ShowUI()
    {
        uiDocument.rootVisualElement.style.visibility = Visibility.Visible;
        hudUIDocument.rootVisualElement.style.visibility = Visibility.Hidden;
    }

    public void HideUI()
    {
        uiDocument.rootVisualElement.style.visibility = Visibility.Hidden;
        hudUIDocument.rootVisualElement.style.visibility = Visibility.Visible;
    }

}
