using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class Item
{
    public EnumTypes.ItemName Name;
    public GameObject Prefab;
}

public class BaseItem : MonoBehaviour
{
    protected void Update()
    {
        transform.Translate(new Vector3(0, -0.005f, 0f));   
    }

    public virtual void OnGetItem(CharacterManager characterManager) { }
}

public class ItemManager : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public void SpawnItem(EnumTypes.ItemName name, Vector3 position)
    {
        Item foundItem = Items.Find(item => item.Name == name);

        if (foundItem != null)
        {
            GameObject itemPrefab = foundItem.Prefab;
            Instantiate(itemPrefab, position, Quaternion.identity);
        }
    }
}