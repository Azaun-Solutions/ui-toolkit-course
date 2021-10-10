using System.Collections;
using System.Collections.Generic;
using UI.PlainButton;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenuUI : MonoBehaviour
{
    private UIDocument m_UIDocument;
    private VisualElement m_ConfirmationModal;

    private void Awake()
    {
        m_UIDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = m_UIDocument.rootVisualElement;
        PlainButton continueButton = root.Q<PlainButton>("continue-button");
        continueButton.SetEnabled(false);
        PlainButton exitButton = root.Q<PlainButton>("exit-button");
        exitButton.clicked += ShowConfirmationModal;
        m_ConfirmationModal = root.Q("confirmation-modal");
        Button confirmButton = m_ConfirmationModal.Q<Button>("confirm-button");
        confirmButton.clicked += QuitGame;
        Button cancelButton = m_ConfirmationModal.Q<Button>("cancel-button");
        cancelButton.clicked += Cancel;
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
}
