using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public TextMeshProUGUI myText;
    private void Update()
    {
        myText.text = GameManager.Instance.ScoreNum.ToString();
    }

}
