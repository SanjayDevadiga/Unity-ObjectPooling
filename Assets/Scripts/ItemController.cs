using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour, IDescription
{
    [SerializeField] private GameObject description;

    public void DisplayDescription(string text)
    {
        description.SetActive(true);
        description.GetComponent<DescriptionHandler>().SetDescription(text);
    }
}
