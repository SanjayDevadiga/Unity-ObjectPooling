using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text description;
    [SerializeField] private Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void SetDescription(string text)
    {
        description.text = "Description :" + text;
    }
}
