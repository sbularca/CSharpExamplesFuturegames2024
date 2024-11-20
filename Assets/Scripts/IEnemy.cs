public interface IEnemy {
    public int Health { get; set; }
    public int Damage { get; set; }
}

public class EnemyHandler {
    private readonly IEnemy enemy;
    public EnemyHandler(IEnemy enemy) {
        this.enemy = enemy;

    }
    public void Damage() {
        enemy.Health--;
    }
}
