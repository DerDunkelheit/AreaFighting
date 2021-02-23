using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour, IDamageable
{
    public Action PlayerDeathEven;

    [SerializeField] private NavMeshSurface2d surface2d = null;
    [SerializeField] private float startingHealth = 3f;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        //an example how to build navMesh in runtime.
        if (Input.GetKeyDown(KeyCode.G))
        {
            surface2d.BuildNavMesh();
        }
    }

    //TODO: replace to health component.
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
        PlayerDeathEven?.Invoke();
    }
}