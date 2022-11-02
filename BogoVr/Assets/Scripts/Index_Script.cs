using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WidgetScript;

public class Index_Script : MonoBehaviour
{
    [SerializeField] private Iterate_Fowards m_Loop;

    public int GetIndex() => m_Loop.LoopIndex;
}

