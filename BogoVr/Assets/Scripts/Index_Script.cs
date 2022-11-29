using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WidgetScript;

public class Index_Script : MonoBehaviour
{
    private Iterate_Fowards m_Loop;
    private void Start()
    {
        m_Loop = transform.parent.gameObject.GetComponent<Iterate_Fowards>();
    }

    public int GetIndex() => m_Loop.LoopIndex;
}

