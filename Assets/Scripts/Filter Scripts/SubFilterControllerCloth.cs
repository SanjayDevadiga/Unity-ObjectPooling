using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubFilterControllerCloth : MonoBehaviour
{
    [SerializeField] private Toggle maleToggle;
    [SerializeField] private Toggle femaleToggle;
    [SerializeField] private Toggle kidsToggle;

    private void OnEnable()
    {
        maleToggle.isOn = false;
        femaleToggle.isOn = false;
        kidsToggle.isOn = false;
    }

    private void Start()
    {
        maleToggle.onValueChanged.AddListener(OnMaleClick);
        femaleToggle.onValueChanged.AddListener(OnFemaleClick);
        kidsToggle.onValueChanged.AddListener(OnKidsClick);
    }

    private void OnKidsClick(bool isOn)
    {
        FIlterManager.Instance.clothFiltre.SubFilter.kids = isOn;
    }

    private void OnFemaleClick(bool isOn)
    {
        FIlterManager.Instance.clothFiltre.SubFilter.female = isOn;
    }

    private void OnMaleClick(bool isOn)
    {
        FIlterManager.Instance.clothFiltre.SubFilter.male = isOn;
    }

    public void Disable()
    {
        this.transform.gameObject.SetActive(false);
    }

    public void Enable()
    {
        this.transform.gameObject.SetActive(true);
    }

    public void ResetFilter()
    {
        maleToggle.isOn = false;
        femaleToggle.isOn = false;
        kidsToggle.isOn = false;

        FIlterManager.Instance.clothFiltre.SubFilter.male = false;
        FIlterManager.Instance.clothFiltre.SubFilter.female = false;
        FIlterManager.Instance.clothFiltre.SubFilter.kids = false;
    }
}
