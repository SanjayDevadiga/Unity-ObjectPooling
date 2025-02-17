using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IDescription
{
    public void DisplayDescription(string text);
}

public class ItemPrefabController : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemName;

    IDescription callbackIn;
    private string description = "";

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        callbackIn.DisplayDescription(description);
    }

    public void SetValues(Sprite image, string name, string description, IDescription callback = null)
    {
        callbackIn = callback;

        this.description = description;

        itemName.text = name;
        if(image!=null)
            itemImage.sprite = image;
    }
}
