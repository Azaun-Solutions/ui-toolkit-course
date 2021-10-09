using System.Collections;
using System.Collections.Generic;
using SaveSystem.Scripts.Runtime;
using SaveSystem.Scripts.Runtime.Channels;
using SceneManagement;
using UI.PlainButton;
using UI.Settings;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenuUI : MonoBehaviour
{
    private UIDocument m_UIDocument;
    private VisualElement m_ConfirmationModal;
    [SerializeField] private LoadSceneChannel m_LoadSceneChannel;
    [SerializeField] private SceneReference m_StartingLocation;
    [SerializeField] private GameData m_GameData;
    [SerializeField] private LoadDataChannel m_LoadDataChannel;
    
    private VisualElement m_Settings;

    private void Awake()
    {
        m_UIDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = m_UIDocument.rootVisualElement;
        PlainButton continueButton = root.Q<PlainButton>("continue-button");
        continueButton.SetEnabled(m_GameData.hasPreviousSave);
        continueButton.clicked += ContinuePreviousGame;
        PlainButton exitButton = root.Q<PlainButton>("exit-button");
        exitButton.clicked += ShowConfirmationModal;
        m_ConfirmationModal = root.Q("confirmation-modal");
        Button confirmButton = m_ConfirmationModal.Q<Button>("confirm-button");
        confirmButton.clicked += QuitGame;
        Button cancelButton = m_ConfirmationModal.Q<Button>("cancel-button");
        cancelButton.clicked += Cancel;
        Button closeButton = m_ConfirmationModal.Q<Button>("close-button");
        closeButton.clicked += Cancel;
        Button newGameButton = root.Q<PlainButton>("new-game-button");
        newGameButton.clicked += StartNewGame;
        PlainButton settingsButton = root.Q<PlainButton>("settings-button");
        settingsButton.clicked += OpenSettings;
        m_Settings = root.Q<SettingsElement>();
        Button closeSettingsButton = m_Settings.Q<Button>("close-button");
        closeSettingsButton.clicked += CloseSettings;
    }

    private void ContinuePreviousGame()
    {
        m_GameData.LoadFromBinaryFile();
        m_LoadDataChannel.Load();
    }

    private void StartNewGame()
    {
        m_LoadSceneChannel.Load(m_StartingLocation);
    }

    private void ShowConfirmationModal()
    {
        m_ConfirmationModal.style.display = DisplayStyle.Flex;
    }

    private void Cancel()
    {
        m_ConfirmationModal.style.display = DisplayStyle.None;
    }

    private void QuitGame()
    {
        m_ConfirmationModal.style.display = DisplayStyle.None;
        Application.Quit();
    }

    private void CloseSettings()
    {
        m_Settings.style.display = DisplayStyle.None;
    }

    private void OpenSettings()
    {
        m_Settings.style.display = DisplayStyle.Flex;
    }
}
