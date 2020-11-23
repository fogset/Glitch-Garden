using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
    public bool HaveEnoughStars(int amount)
    {
        if (stars > amount)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void AddStars(int amount)
    {
        stars = stars + amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if(stars >= amount)
        {
            stars = stars - amount;
            UpdateDisplay();
        }
        
    }

}
