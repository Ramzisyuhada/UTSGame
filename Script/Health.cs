using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    [SerializeField]private Slider slider;

    [SerializeField]private Gradient gradient;
    
    [SerializeField]private Image fill;

    // Start is called before the first frame update
    // void Start()
    // {
    //    CurrentDarah();
    //    slider = slider.GetComponent<Slider>();
    // }

    public void Setmaxhealth(int health){
        slider.value = health;
        slider.maxValue = health;

        fill.color = gradient.Evaluate(1f);

    }
    public void SetHealth(int health){
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public int Takedamage(int current){
        current -= 20;
        SetHealth(current);

        return current;
    }
    
    public int Regen(int current){
        current += 10;
        SetHealth(current);

        return current;
    }

   
}
