using UnityEngine;

public class InsectController : EnemyController
{
    protected override void CharacterMovement(Vector2 direction)
    {
        base.CharacterMovement(direction);
        animator.Play("InsectWalk");
    }
}
