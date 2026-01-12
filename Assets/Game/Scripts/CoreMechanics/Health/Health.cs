using UnityEngine;

public class Health
{
    public Health(int startHealth)
    {
        MaxHealth = startHealth;
        CurrentHealth = MaxHealth;

        IsDead = false;
    }
    
    public int MaxHealth {get; private set;}
    public int CurrentHealth {get; private set;}
    public bool IsDead {get; private set;}

    public void Heal(int value)
    {
        if(value < 0)
        {
            Debug.Log("Неправильное значение хила");
            return;
        }

        if(CurrentHealth + value >= MaxHealth)
            CurrentHealth = MaxHealth;
        else
            CurrentHealth += value;

        Debug.Log("Текущее хп: " + CurrentHealth);
    }

    public void TakeDamage(int value)
    {
        if(IsDead)
            return;

        if(value < 0)
        {
            Debug.Log("Неправильное значение урона");
            return;
        }

        if(CurrentHealth - value <= 0)
        {
            CurrentHealth = 0;
            IsDead = true;
            Debug.Log("Персонаж умер");
            return;
        }
        
        CurrentHealth -= value;
        Debug.Log("Текущее хп: " + CurrentHealth);
    }
}
