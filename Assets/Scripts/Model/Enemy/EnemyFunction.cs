using UnityEngine;

public class EnemyFunction : MonoBehaviour
{
    protected Enemy enemy;
    //Init Enemy
    protected void InitializeEnemy()
    {

        if (gameObject.CompareTag(StringConstant.EnemyType.BOAR))
        {
            enemy = new Enemy(100, 20, 3, 30, 2f);
        }
        else if (gameObject.CompareTag(StringConstant.EnemyType.BEE))
        {
            enemy = new Enemy(50, 10, 5, 15, 3f);
        }
    }
}
