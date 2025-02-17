using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubFilterControllerWatch : MonoBehaviour
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
        FIlterManager.Instance.watchFilter.SubFilter.kids = isOn;
    }

    private void OnFemaleClick(bool isOn)
    {
        FIlterManager.Instance.watchFilter.SubFilter.female = isOn;

    }

    private void OnMaleClick(bool isOn)
    {
        FIlterManager.Instance.watchFilter.SubFilter.male = isOn;
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

        FIlterManager.Instance.watchFilter.SubFilter.male = false;
        FIlterManager.Instance.watchFilter.SubFilter.female = false;
        FIlterManager.Instance.watchFilter.SubFilter.kids = false;
    }
}
