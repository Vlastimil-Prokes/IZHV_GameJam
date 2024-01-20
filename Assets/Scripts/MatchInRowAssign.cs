using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchInRowAssign : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = GameManager.NowIndex.ToString();
    }
    void Update()
    {
        text.text = GameManager.NowIndex.ToString();
    }
}
