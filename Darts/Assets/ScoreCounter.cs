using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    int score;

    public void AddPoint()
    {
        score ++;
        var text = GetComponent<TMP_Text>();
        text.SetText(score.ToString());
    }
}
