using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Page
{
    None,
    Home,
}

public class PagesController : MonoBehaviour
{
    public static PagesController Instance { get; private set; }

    [SerializeField] private List<GameObject> _pages = new List<GameObject>();  
    [SerializeField] private GameObject _pageNotFound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _pages[0].SetActive(true);
    }

    private void DisableAllPage()
    {
        for (int i = 0; i < _pages.Count; i++)
        {
            _pages[i].SetActive(false);
        }
        _pageNotFound.SetActive(false);
    }

    public void EnablePage(Page page)
    {
        DisableAllPage();
        switch (page)
        {
            case Page.Home:
                _pages[0].SetActive(true);
                break;
            default:
                _pageNotFound.SetActive(true);
                break;
        }
    }}
