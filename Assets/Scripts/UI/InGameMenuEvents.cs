using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameMenuEvents : MonoBehaviour
{
    [SerializeField] private UIDocument hudUIDocument;

    private UIDocument uiDocument;
    private Button playButton;
    private Button quitButton;
    private List<Button> buttons;

    private AudioSource audioSource;

    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        // Note(Ahmed) make sure the ingame menu is hidden at first, pausing the game will make it visible.
        uiDocument.rootVisualElement.style.visibility = Visibility.Hidden;

        playButton = uiDocument.rootVisualElement.Q("PlayButton") as Button;
        playButton.RegisterCallback<ClickEvent>(OnPlayButtonClick);

        quitButton = uiDocument.rootVisualElement.Q("QuitButton") as Button;
        quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClick);

        buttons = uiDocument.rootVisualElement.Query<Button>().ToList();

        foreach (var button in buttons)
        {
            button.RegisterCallback<ClickEvent>(OnButtonClickPlaySound);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        playButton.UnregisterCallback<ClickEvent>(OnPlayButtonClick);

        foreach (var button in buttons)
        {
            button.UnregisterCallback<ClickEvent>(OnButtonClickPlaySound);
        }
    }

    private void OnButtonClickPlaySound(ClickEvent evt)
    {
        audioSource.Play();
    }

    private void OnPlayButtonClick(ClickEvent evt)
    {
        uiDocument.rootVisualElement.style.visibility = Visibility.Hidden;
        hudUIDocument.rootVisualElement.style.visibility = Visibility.Visible;
    }

    private void OnQuitButtonClick(ClickEvent evt)
    {
        // NOTE(Ahmed) in a normal game make sure the save before quiting
        // TODO(Ahmed) save quiting time, to check if application has crashed while launching the game

        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
