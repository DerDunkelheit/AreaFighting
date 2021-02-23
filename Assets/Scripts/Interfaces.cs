using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooting
{
    void Shoot(Vector2 positionToShoot);
}

public interface IDamageable
{
    void TakeDamage(float damage);
}

