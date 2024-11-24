using System;
using UnityEngine;
public class Item : ScriptableObject, IItem {
    public ItemBaseStats baseStats = new();
}

public interface IItem { }

[Serializable]
public class ItemBaseStats {
    public string name = "default";
    public string type = "default";
    public int value;
    public int weight;
}
