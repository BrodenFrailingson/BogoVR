using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WidgetScript;

public class Index_Script : MonoBehaviour
{
    [SerializeField] private GameObject m_Loop;

    public int GetIndex() 
    {
        return m_Loop.GetComponent<Iterate_Fowards>().GetLoopIndex();
    }
}

