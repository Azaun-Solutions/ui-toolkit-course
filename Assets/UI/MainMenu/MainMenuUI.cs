using System.Collections;
using System.Collections.Generic;
using UI.PlainButton;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenuUI : MonoBehaviour
{
    private UIDocument m_UIDocument;

    private void Awake()
    {
        m_UIDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        PlainButton continueButton = m_UIDocument.rootVisualElement.Q<PlainButton>("continue-button");
        continueButton.SetEnabled(false);
    }
}
