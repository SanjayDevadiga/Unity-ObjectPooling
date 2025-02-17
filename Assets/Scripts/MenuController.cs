using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private List<Button> buttons = new List<Button>();
    [SerializeField] private List<Sprite> selectedSprite = new List<Sprite>();
    [SerializeField] private List<Sprite> deselectedSprite = new List<Sprite>();
    [SerializeField] private int selectedButtonIndex = 0;

    [Space]
    [SerializeField] private GameObject notFoundPage;

    private void Start()
    {
        buttons[0].GetComponent<Image>().sprite = selectedSprite[selectedButtonIndex];
        notFoundPage.SetActive(false);
    }

    private void disableSelection()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<Image>().sprite = deselectedSprite[i];
        }
    }

    public void OnButtonSelect(int buttonIndex)
    {
        disableSelection();

        selectedButtonIndex = buttonIndex;
        buttons[selectedButtonIndex].GetComponent<Image>().sprite = selectedSprite[selectedButtonIndex];

        if (selectedButtonIndex == 0)
            PagesController.Instance.EnablePage(Page.Home);
        else
            PagesController.Instance.EnablePage(Page.None);
    }
}
