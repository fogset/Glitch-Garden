using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab;
    List<Vector2> postions = new List<Vector2>();
    bool ifFirstTime = true;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        if(defenderPrefab)
        {
            var StarDisplay = FindObjectOfType<StarDisplay>();
            int defenderCost = defenderPrefab.GetStarCost();
            if (StarDisplay.HaveEnoughStars(defenderCost) == true)
            {

                if (repeatedPostition(gridPos) == false)
                {
                    Debug.Log("clicked this postion: " + gridPos);
                    SpawnDefender(gridPos);
                }
                StarDisplay.SpendStars(defenderCost);
            }
        }
    }

    private bool repeatedPostition(Vector2 gridPos)
    {   
        if(ifFirstTime == true)
        {
            postions.Add(gridPos);
            ifFirstTime = false;
        }
        else
        {
            for (int i = 0; i < postions.Count; i++)
            {
                Debug.Log("current postion: " +i + postions[i]);
            }
            if (postions.Contains(gridPos))
            {
                return true;
            }
            else
            {
                postions.Add(gridPos);
                return false;
            }
        }
        return false;
    }
    
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defenderPrefab, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
    
}
