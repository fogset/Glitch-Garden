using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    private float levelTime = 10;
    bool triggerLevelFinished = false;

    private void Start()
    {
        levelTime = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerLevelFinished == true)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished)
        {
            Debug.Log("level timer expired!");
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggerLevelFinished = true;
        }
    }

    public void SetLevelTimer(float time)
    {
        levelTime = time;
    }
}
