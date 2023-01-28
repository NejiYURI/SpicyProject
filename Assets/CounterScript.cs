using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    public TextMeshProUGUI CounterTxt;

    private void Start()
    {
        this.transform.LeanScale(Vector3.zero, 0f);
    }

    public void CounterSet(string counterValue)
    {
        this.transform.LeanScale(Vector3.zero, 0f);
        CounterTxt.text = counterValue;
        this.transform.LeanScale(Vector3.one, 0.2f);
    }
}
