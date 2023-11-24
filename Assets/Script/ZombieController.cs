using UnityEngine;

public class ZombieController : EnemyController
{
    protected override void CharacterMovement(Vector2 direction)
    {
        base.CharacterMovement(direction);
        animator.Play("EnemyWalk");
    }
}
