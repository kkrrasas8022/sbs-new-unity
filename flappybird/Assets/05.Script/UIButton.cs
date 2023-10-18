using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public Button myButton;
    public void Onclick()
    {
        GameManager.Instance.OnRestart?.Invoke();
    }
}
