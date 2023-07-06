using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    public string name;
    public string description = "Default";
    public Sprite image;
    public ItemType type;
    public bool stackable;
    public GameObject itemPrefab;
    public int count;
    public float weight;
}

public enum ItemType {
    Medicine,
    Food,
    Tool
}