using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemName Name;
    public GameObject Prefab;
}

public enum ItemName
{
    HealthUp
}

public class ItemManager : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public static ItemManager instance;

    private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
    {
        if (instance == null)  // 단 하나만 존재하게끔
        {
            instance = this;  // 객체 생성시 instance에 자기 자신을 넣어줌
            DontDestroyOnLoad(gameObject);  // 씬 바뀔 때 자기 자신 파괴 방지
        }
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnItem(ItemName name, Vector3 position)
    {
        Item foundItem = Items.Find(item => item.Name == name);

        if (foundItem != null)
        {
            GameObject itemPrefab = foundItem.Prefab;
            Instantiate(itemPrefab, position, Quaternion.identity);
        }
    }
}