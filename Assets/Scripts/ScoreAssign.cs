using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAssign : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = GameManager.Score.ToString();
    }
    void Update()
    {
        text.text = GameManager.Score.ToString();
    }


}
