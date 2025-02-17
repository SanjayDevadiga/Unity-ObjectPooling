using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class FilterCollection
{
    public List<FilterData> filters;
}

[System.Serializable]
public class FilterData
{
    public string filterName;
    public List<SubFilterData> subFilters;
}

[System.Serializable]
public class SubFilterData
{
    public string subFilterName;
    public List<ItemData> items;
}

[System.Serializable]
public class ItemData
{
    public string name;
    public string description;
}

public class ItemSpawner : MonoBehaviour, IDescription
{
    public TextAsset jsonFile;
    public GameObject prefab;
    public GameObject description;
    public Transform spawnPoint;
    private FilterCollection filterCollection;
    private List<GameObject> activeItems = new List<GameObject>();

    void Start()
    {
        LoadJsonData();
        SpawnItemsFromJson();
    }

    void LoadJsonData()
    {
        //string path = Path.Combine(Application.streamingAssetsPath, "data.json");
        //if (File.Exists(path))
        //{
        //    string json = File.ReadAllText(path);
        //    filterCollection = JsonUtility.FromJson<FilterCollection>(json);
        //}
        //else
        //{
        //    Debug.LogError("JSON file not found at " + path);
        //}

        TextAsset jsonText = Resources.Load<TextAsset>("data");

        // Deserialize the JSON string into an object
        if (jsonText != null)
        {
            filterCollection = JsonUtility.FromJson<FilterCollection>(jsonText.text);
            Debug.Log("Loaded Data: " + filterCollection.filters.Count);
        }
        else
        {
            Debug.LogError("JSON file not found!");
        }
    }

    public void DisplayDescription(string text)
    {
        description.SetActive(true);
        description.GetComponent<DescriptionHandler>().SetDescription(text);
    }

    public void SpawnItemsFromJson()
    {
        if (filterCollection != null)
        {
            foreach (var filter in filterCollection.filters)
            {
                foreach (var subFilter in filter.subFilters)
                {
                    foreach (var item in subFilter.items)
                    {
                        GameObject itemObj = Instantiate(prefab, this.transform);
                        itemObj.name = item.name;
                        itemObj.GetComponent<ItemPrefabController>().SetValues(null, item.name, item.description, this);

                        itemObj.transform.parent = spawnPoint.transform;
                        itemObj.transform.localScale = Vector3.one;
                        activeItems.Add(itemObj);
                        Debug.Log("Spawned: " + item.name + " - " + item.description);
                    }
                }
            }
        }
    }

    void ClearAllChild()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ApplyFilter(Filter watchFilter, Filter clothFilter, Filter jwelryFilter)
    {
        ClearAllChild();
        if (filterCollection == null) return;

        if (!watchFilter.selected && !clothFilter.selected && !jwelryFilter.selected)
        {
            SpawnItemsFromJson();
            return;
        }

        DisplyWatchFilter(watchFilter);
        DisplayForClothFilter(clothFilter);
        DisplayForJwelry(jwelryFilter);
    }
    void DisplyWatchFilter(Filter watchFilter)
    {
        if (watchFilter.selected)
        {
            if (watchFilter.SubFilter.male)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Watches")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Male")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }
            if (watchFilter.SubFilter.female)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Watches")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Female")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }
            if (watchFilter.SubFilter.kids)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Watches")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Kids")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }

            if (!watchFilter.SubFilter.kids && !watchFilter.SubFilter.male && !watchFilter.SubFilter.female)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Watches")
                    {
                        foreach (var category in item.subFilters)
                        {
                            foreach (var items in category.items)
                            {
                                GameObject itemObj = Instantiate(prefab, this.transform);
                                itemObj.name = items.name;
                                itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                itemObj.transform.parent = spawnPoint.transform;
                                itemObj.transform.localScale = Vector3.one;
                                activeItems.Add(itemObj);
                                Debug.Log("Spawned: " + items.name + " - " + items.description);
                            }
                        }
                    }
                }
            }
        }
    }

    void DisplayForClothFilter(Filter clothFilter)
    {
        if (clothFilter.selected)
        {
            if (clothFilter.SubFilter.male)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Cloths")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Male")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }
            if (clothFilter.SubFilter.female)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Cloths")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Female")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }
            if (clothFilter.SubFilter.kids)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Cloths")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Kids")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }
            if (!clothFilter.SubFilter.kids && !clothFilter.SubFilter.male && !clothFilter.SubFilter.female)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Cloths")
                    {
                        foreach (var category in item.subFilters)
                        {
                            foreach (var items in category.items)
                            {
                                GameObject itemObj = Instantiate(prefab, this.transform);
                                itemObj.name = items.name;
                                itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                itemObj.transform.parent = spawnPoint.transform;
                                itemObj.transform.localScale = Vector3.one;
                                activeItems.Add(itemObj);
                                Debug.Log("Spawned: " + items.name + " - " + items.description);
                            }
                        }
                    }
                }
            }
        }
    }

    void DisplayForJwelry(Filter jwelryFilter)
    {
        if (jwelryFilter.selected)
        {
            if (jwelryFilter.SubFilter.male)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Jwelry")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Male")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }
            if (jwelryFilter.SubFilter.female)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Jwelry")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Female")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }
            if (jwelryFilter.SubFilter.kids)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Watches")
                    {
                        foreach (var maleItem in item.subFilters)
                        {
                            if (maleItem.subFilterName == "Kids")
                            {
                                foreach (var items in maleItem.items)
                                {
                                    GameObject itemObj = Instantiate(prefab, this.transform);
                                    itemObj.name = items.name;
                                    itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                    itemObj.transform.parent = spawnPoint.transform;
                                    itemObj.transform.localScale = Vector3.one;
                                    activeItems.Add(itemObj);
                                    Debug.Log("Spawned: " + items.name + " - " + items.description);
                                }
                            }
                        }
                    }
                }
            }
            if (!jwelryFilter.SubFilter.kids && !jwelryFilter.SubFilter.male && !jwelryFilter.SubFilter.female)
            {
                foreach (var item in filterCollection.filters)
                {
                    if (item.filterName == "Jwelry")
                    {
                        foreach (var category in item.subFilters)
                        {
                            foreach (var items in category.items)
                            {
                                GameObject itemObj = Instantiate(prefab, this.transform);
                                itemObj.name = items.name;
                                itemObj.GetComponent<ItemPrefabController>().SetValues(null, items.name, items.description, this);

                                itemObj.transform.parent = spawnPoint.transform;
                                itemObj.transform.localScale = Vector3.one;
                                activeItems.Add(itemObj);
                                Debug.Log("Spawned: " + items.name + " - " + items.description);
                            }
                        }
                    }
                }
            }
        }
    }
}



