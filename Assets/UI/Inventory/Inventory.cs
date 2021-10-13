using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    private UIDocument m_UIDocument;

    private void Awake()
    {
        m_UIDocument = GetComponent<UIDocument>();
    }

    private void Start()
    {
        VisualElement root = m_UIDocument.rootVisualElement;
        Button button = root.Q<Button>();
        button.clicked += () => Debug.Log("Hello World!");
    }
}
