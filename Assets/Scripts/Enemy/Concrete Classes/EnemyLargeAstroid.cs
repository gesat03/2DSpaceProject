public class EnemyLargeAstroid : BaseEnemy
{
    protected override void Update()
    {
        EnemyMovement();

        OutOfBoundry();
    }
}
