public class EnemySmallAstroid : BaseEnemy
{
    protected override void Update()
    {
        EnemyMovement();

        OutOfBoundry();
    }
}
