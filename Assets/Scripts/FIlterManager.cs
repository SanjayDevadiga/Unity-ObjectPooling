using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Filter
{
    public bool selected = false;
    public SubFilter SubFilter = new SubFilter();
}

[Serializable]
public class SubFilter
{
    public bool male = false;
    public bool female = false;
    public bool kids = false;
}

public class FIlterManager : MonoBehaviour
{
    public static FIlterManager Instance { get; set; }

    public ItemSpawner itemSpawner;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button applyButton;

    [SerializeField] private FilterController filterController;

    public Filter watchFilter;
    public Filter clothFiltre;
    public Filter jweleryFiltre;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        closeButton.onClick.AddListener(OnCloseButtonClick);
        resetButton.onClick.AddListener(OnResetButtonClick);
        applyButton.onClick.AddListener(OnApplyButtonClick);

        watchFilter = new Filter();
        clothFiltre = new Filter();
        jweleryFiltre = new Filter();
    }

    private void OnCloseButtonClick()
    {
        this.gameObject.SetActive(false);
    }

    private void OnApplyButtonClick()
    {
        itemSpawner.ApplyFilter(watchFilter, clothFiltre, jweleryFiltre);
    }

    private void OnResetButtonClick()
    {
        filterController.ResetFilter();
        itemSpawner.SpawnItemsFromJson();
    }
}
