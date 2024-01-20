using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingTimeAssign : MonoBehaviour
{
    public TMP_Text text;

    public GameObject panel;

    int i = 60;

    void RefreshTime()
    {
        i--;
        text.text = i.ToString();
        if (i > 0)
            Invoke("RefreshTime", 1);
        else
            panel.SetActive(true);

    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = i.ToString();
        Invoke("RefreshTime", 1);
    }


}
