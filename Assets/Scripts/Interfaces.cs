using System;
using Enemies;
using UnityEngine;

public interface IShooting
{
    void Shoot(Vector2 positionToShoot);
}

public interface IDamageable
{
    event Action HealthDepletedEvent;
    void TakeDamage(float damage);
}

public interface ICurable
{
    void RestoreHealth(float amount);
}

public interface ITransition
{
    bool Allowed { get; }
    string NextStateId { get; }
    void Run(EnemyController controller);
}

public interface IAbility
{
    void Cast();
    event Action AbilityDepletedEvent;
}

