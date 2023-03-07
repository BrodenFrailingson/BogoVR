using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WidgetScript;

public class Index_Script : MonoBehaviour
{
    private Iterate_Fowards m_Loop;
    private string _symbol;
    private string[] notations = { "i", "j", "k", "x", "y", "z" };
    public string Symbol { get { return _symbol; } }

    private void Start()
    {
        int others = GameObject.FindGameObjectsWithTag("i").Length;
        _symbol = (others > 6 && others !=0)? "i" + notations[others-6] : notations[others - 1];
        _symbol = (others == 0) ? notations[0] : _symbol;
        m_Loop = transform.parent.gameObject.GetComponent<Iterate_Fowards>();
    }

    public int GetIndex() => m_Loop.LoopIndex;
}

