using UnityEngine;
using UnityEngine.UI;

public class FilterController : MonoBehaviour
{
    [SerializeField] private SubFilterControllerWatch watchSubFilter;
    [SerializeField] private SubFilterControllerCloth clothSubFilter;
    [SerializeField] private SubFilterControllerJwelry jwelerySubFilter;

    [Space]
    [SerializeField] private Toggle watchToggle;
    [SerializeField] private Toggle clothToggle;
    [SerializeField] private Toggle jweleryToggle;

    private void Start()
    {
        watchSubFilter.gameObject.SetActive(false);
        clothSubFilter.gameObject.SetActive(false); 
        jwelerySubFilter.gameObject.SetActive(false);

        watchToggle.isOn = false;
        clothToggle.isOn = false;
        jweleryToggle.isOn = false;

        watchToggle.onValueChanged.AddListener(OnWatchSelection);
        clothToggle.onValueChanged.AddListener(OnClothSelection);
        jweleryToggle.onValueChanged.AddListener(OnJwelrySelection);
    }

    private void OnWatchSelection(bool isOn)
    {
        if (isOn)
        {
            watchSubFilter.Enable();
        }
        else
        {
            watchSubFilter.Disable();
            watchSubFilter.ResetFilter();
        }
        FIlterManager.Instance.watchFilter.selected = isOn;
    }

    private void OnClothSelection(bool isOn)
    {
        if (isOn)
        {
            clothSubFilter.Enable();
        }
        else
        {
            clothSubFilter.Disable();
            clothSubFilter.ResetFilter();
        }
        FIlterManager.Instance.clothFiltre.selected = isOn;
    }

    private void OnJwelrySelection(bool isOn)
    {
        if (isOn)
        {
            jwelerySubFilter.Enable();
        }
        else
        {
            jwelerySubFilter.Disable();
            jwelerySubFilter.ResetFilter();
        }
        FIlterManager.Instance.jweleryFiltre.selected = isOn;
    }

    public void ResetFilter()
    {
        watchToggle.isOn = false;
        clothToggle.isOn = false;
        jweleryToggle.isOn = false;

        watchSubFilter.ResetFilter();
        clothSubFilter.ResetFilter();
        jwelerySubFilter.ResetFilter();

        FIlterManager.Instance.watchFilter.selected = false;
        FIlterManager.Instance.clothFiltre.selected = false;
        FIlterManager.Instance.jweleryFiltre.selected = false;
    }
}