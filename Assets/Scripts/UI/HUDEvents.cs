using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUDEvents : MonoBehaviour
{
    [SerializeField] private UIDocument ingameMenuUIDocument;

    private UIDocument uiDocument;
    private Button pauseButton;

    private List<Button> buttons;

    private AudioSource audioSource;

    void Awake()
    {
        uiDocument = GetComponent<UIDocument>(); 

        pauseButton = uiDocument.rootVisualElement.Q("PauseButton") as Button;
        pauseButton.RegisterCallback<ClickEvent>(OnPauseButtonClick);

        var versionLabel = uiDocument.rootVisualElement.Q("VersionLabel") as Label;
        versionLabel.text = "v" + Application.version;

        buttons = uiDocument.rootVisualElement.Query<Button>().ToList();

        foreach (var button in buttons)
        {
            button.RegisterCallback<ClickEvent>(OnButtonClickPlaySound);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        pauseButton.UnregisterCallback<ClickEvent>(OnPauseButtonClick);

        foreach (var button in buttons)
        {
            button.UnregisterCallback<ClickEvent>(OnButtonClickPlaySound);
        }
    }

    private void OnButtonClickPlaySound(ClickEvent evt)
    {
        audioSource.Play();
    }

    private void OnPauseButtonClick(ClickEvent evt)
    {
        uiDocument.rootVisualElement.style.visibility = Visibility.Hidden;
        ingameMenuUIDocument.rootVisualElement.style.visibility = Visibility.Visible;
    }
}
