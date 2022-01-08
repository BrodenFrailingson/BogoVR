using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Widget
{
    [RequireComponent(typeof(Widget))]
    public class Swap : Widget
    {
        // Start is called before the first frame update
        public void Operation()
        {
            Debug.Log(m_Val1 + " + " + m_Val2);
            m_List = GameObject.FindGameObjectWithTag("List");
            if (m_List == null)
                m_List = GameObject.FindGameObjectWithTag("List_Out");
            if(m_Val1 != -1 && m_Val2 != -1)
                m_List.GetComponent<List_Script>().Swap(m_Val1, m_Val2);
        }
    }
}
