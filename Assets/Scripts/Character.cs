using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private int _minHealth;

    public event UnityAction<float> HealthChanged;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        OnAwake();
    }

    public virtual void OnAwake()
    {
        MaxHealth = 10;
        _minHealth = 0;
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage = 0)
    {
        CurrentHealth -= damage;
        float percentOfHealth = (float)CurrentHealth / MaxHealth;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, MaxHealth);
        HealthChanged.Invoke(percentOfHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth(int amountOfHealth)
    {
        CurrentHealth += amountOfHealth;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, MaxHealth);
        float percentOfHealth = (float)CurrentHealth / MaxHealth;
        HealthChanged.Invoke(percentOfHealth);
    }

    public virtual void Reset()
    {
        CurrentHealth = MaxHealth;
        _healthBar.Reset();
    }

    public virtual void Die(){}
}
