using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerNeeds : MonoBehaviour
{
    public Need health;
    public Need hunger;
    public Need thirst;
    public Need sleep;   

    public float noHungerHealthDecay;
    public float noThirstHealthDecay;

    public UnityEvent onTakeDamage;

    private void Start()
    {
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        thirst.curValue = thirst.startValue;
        sleep.curValue = sleep.startValue;
    }

    private void Update()
    {
        //decay needs over times
        hunger.Subtract(hunger.decayRate * Time.deltaTime); //it is decreasing 1 by 1 second
        thirst.Subtract(thirst.decayRate * Time.deltaTime); 
        sleep.Add(sleep.decayRate * Time.deltaTime);

        //if we starving/thirsty it take our hp
        if (hunger.curValue == 0.0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }
        if (thirst.curValue == 0.0f)
        {
            thirst.Subtract(noThirstHealthDecay * Time.deltaTime);
        }

        //check if player is dead
        if (health.curValue == 0.0f)
        {
            Die();
        }


        //update UI bar
        health.uiBar.fillAmount = health.GetPrecentage();
        hunger.uiBar.fillAmount = hunger.GetPrecentage();
        thirst.uiBar.fillAmount = thirst.GetPrecentage();
        sleep.uiBar.fillAmount = sleep.GetPrecentage();
    }

    public void Heal (float amout)
    {
        health.Add(amout);
    }

    public void Eat (float amount)
    {
        hunger.Add(amount);
    }

    public void Drink (float amount) 
    {
        thirst.Add(amount);
    }

    public void Sleep (float amout)
    {
        sleep.Subtract(amout);
    }

    public void TakePhysicalDamage (int amout)
    {
        health.Subtract(amout);
        //? means that if there is null (nothing subscribe this event) this will not invoke, but if there is it is going invoke
        onTakeDamage?.Invoke();
    }

    public void Die()
    {
        Debug.Log("Died");
    }

}

[System.Serializable]
public class Need
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar; //Bar which is inreacing or decreasing

    public void Add (float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract (float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    //using this to manipulate uiBar
    public float GetPrecentage()
    {
        return curValue / maxValue;
    }
}
