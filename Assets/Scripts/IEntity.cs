public interface IEntity {
    public string GetName();
    public Inventory GetInventory();
    public EntitySettings GetSettings();
    public void SetSettings(EntitySettings settings);
}

public interface ICharacter : IEntity {
}

public interface IEnemy : IEntity {
    public void SetInventory(Inventory inventory);
}
