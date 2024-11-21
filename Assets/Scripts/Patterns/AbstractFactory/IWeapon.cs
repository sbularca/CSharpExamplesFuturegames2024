using UnityEngine;

public interface IWeapon {
    public string ID { get; set; }
    public void AssembleWeapon();
}

public class Sniper : IWeapon {
    public string ID { get; set; }
    public void AssembleWeapon() {
        Debug.Log("Sniper Assembled");
    }
}

public class SMG : IWeapon {
    public string ID { get; set; }
    public void AssembleWeapon() {
        Debug.Log("SMG Assembled");
    }
}
