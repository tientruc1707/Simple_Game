


enum EnemyType
{
    BEE,
    BOAR
}
[System.Serializable]
public class Enemy
{
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float Value { get; set; }
    public float AttackRange { get; set; }
    
    public Enemy(float health, float damage, float speed, float value, float attackRange)
    {
        Health = health;
        Damage = damage;
        Speed = speed;
        Value = value;
        AttackRange = attackRange;
    }
}
