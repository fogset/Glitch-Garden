using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayPlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealthNumber = 5;
    Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = playerHealthNumber.ToString();
    }

    public void TakeLife(int amount)
    {
            playerHealthNumber = playerHealthNumber - amount;
            UpdateDisplay();
            if(playerHealthNumber <= 0)
            {
                FindObjectOfType<LevelController>().HandleLoseCondition();
            }
    }
}
