using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "EntitySettings", menuName = "Examples/Entity Settings")]
public class EntitySettings : ScriptableObject {
    [FormerlySerializedAs("name")] [Header("Base Stats")]
    public string entityName;
    public int health;
    public int mana;
    public int strength;
    public int dexterity;
    public int intelligence;
    public int vitality;
    public int luck;

    [Header("Inventory & Equipment")]
    public Inventory currentInventory;
    public Inventory currentEquipment;
}
