using UnityEngine;
using System.Collections.Generic;

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
    public GameObject description;
    public Transform spawnPoint;
    private FilterCollection filterCollection;
    private readonly List<GameObject> activeItems = new();

    [Space]
    public GameObject prefab;
    public int poolSize = 45;
    private readonly Queue<GameObject> poolQueue = new();

    void Start()
    {
        LoadJsonData();
        InitializePool();
        SpawnItemsFromJson();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

    private GameObject GetFromPool(Vector3 position, Quaternion rotation)
    {
        if (poolQueue.Count > 0)
        {
            GameObject obj = poolQueue.Dequeue();
            obj.transform.SetPositionAndRotation(position, rotation);
            obj.SetActive(true);
            return obj;
        }

        Debug.LogWarning("Pool exhausted! Reusing existing objects.");
        return null; // Prevent excessive instantiation
    }

    private void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform); // Reset parent to avoid clutter
        obj.transform.localScale = Vector3.one; // Reset scale
        poolQueue.Enqueue(obj);
    }

    void LoadJsonData()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("data");

        if (jsonText != null)
        {
            filterCollection = JsonUtility.FromJson<FilterCollection>(jsonText.text);
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
                        SpawnItem(item);
                    }
                }
            }
        }
    }

    public void ApplyFilter(Filter watchFilter, Filter clothFilter, Filter jewelryFilter)
    {
        // Return all active items to the pool before applying a new filter
        foreach (var item in activeItems)
        {
            ReturnToPool(item);
        }
        activeItems.Clear();

        if (!watchFilter.selected && !clothFilter.selected && !jewelryFilter.selected)
        {
            SpawnItemsFromJson();
            return;
        }

        if (filterCollection == null) return;

        if (watchFilter.selected)
        {
            if(watchFilter.SubFilter.male || watchFilter.SubFilter.female || watchFilter.SubFilter.kids)
            {
                HandleItemSpawn("Watches", watchFilter.SubFilter.male, "Male");
                HandleItemSpawn("Watches", watchFilter.SubFilter.female, "Female");
                HandleItemSpawn("Watches", watchFilter.SubFilter.kids, "Kids");
            }
            else
            {
                SpawnAll("Watches");
            }
        }

        if (clothFilter.selected)
        {
            if (clothFilter.SubFilter.male || clothFilter.SubFilter.female || clothFilter.SubFilter.kids)
            {
                HandleItemSpawn("Cloths", clothFilter.SubFilter.male, "Male");
                HandleItemSpawn("Cloths", clothFilter.SubFilter.female, "Female");
                HandleItemSpawn("Cloths", clothFilter.SubFilter.kids, "Kids");
            }
            else
            {
                SpawnAll("Cloths");
            }     
        }

        if (jewelryFilter.selected)
        {
            if (jewelryFilter.SubFilter.male || jewelryFilter.SubFilter.female || jewelryFilter.SubFilter.kids)
            {
                HandleItemSpawn("Jwelry", jewelryFilter.SubFilter.male, "Male");
                HandleItemSpawn("Jwelry", jewelryFilter.SubFilter.female, "Female");
                HandleItemSpawn("Jwelry", jewelryFilter.SubFilter.kids, "Kids");
            }
            else
            {
                SpawnAll("Jwelry");
            }
        }
    }

    private void SpawnAll(string categoryName)
    {
        foreach (var item in filterCollection.filters)
        {
            if (item.filterName == categoryName)
            {
                foreach (var subFilter in item.subFilters)
                {
                    foreach (var itemData in subFilter.items)
                    {
                        SpawnItem(itemData);
                    }
                }
            }
        }
    }

    private void HandleItemSpawn(string categoryName, bool filterCondition, string subFilterName)
    {
        if (!filterCondition) return;

        foreach (var item in filterCollection.filters)
        {
            if (item.filterName == categoryName)
            {
                foreach (var subFilter in item.subFilters)
                {
                    if (subFilter.subFilterName == subFilterName)
                    {
                        foreach (var itemData in subFilter.items)
                        {
                            SpawnItem(itemData);
                        }
                    }
                }
            }
        }
    }

    private void SpawnItem(ItemData item)
    {
        GameObject itemObj = GetFromPool(spawnPoint.position, Quaternion.identity);

        if (itemObj == null) return; // Prevents instantiating new objects beyond the pool

        itemObj.name = item.name;
        itemObj.GetComponent<ItemPrefabController>().SetValues(null, item.name, item.description, this);

        itemObj.transform.localScale = Vector3.one;
        activeItems.Add(itemObj);
        Debug.Log("Spawned: " + item.name + " - " + item.description);
    }
}

