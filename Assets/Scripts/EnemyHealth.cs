using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] [Range (1, 5)] int maxHitPoints = 5;
    [SerializeField] int difficultyRamp = 1;


    int currentHitPoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            enemy.RewardGold();
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
        }
    }
}
