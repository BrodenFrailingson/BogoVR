using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WidgetScript
{
    [RequireComponent(typeof(Widget))]
    public class Swap : Widget
    {
        // Start is called before the first frame update
        public void Operation()
        {
            Debug.Log("In Swap");
            List_Script m_Script;
            if (m_Val1 != -1 && m_Val2 != -1)
            {

                m_List = GameObject.FindGameObjectWithTag("List") ? GameObject.FindGameObjectWithTag("List") : null;
                m_List = m_List != null ? m_List : GameObject.FindGameObjectWithTag("List_Out");


                m_Script = m_List.GetComponent<List_Script>();


                if (m_Val1 == -2 && m_Val2 == -2)
                {
                    Debug.Log("Two Loop Index' " + m_Index_Obj[0].GetComponent<Index_Script>().GetIndex() + " + " + m_Index_Obj[1].GetComponent<Index_Script>().GetIndex() + " + " + m_Val1 + " + " + m_Val2);
                    m_Script.Swap(m_Index_Obj[0].GetComponent<Index_Script>().GetIndex(), m_Index_Obj[1].GetComponent<Index_Script>().GetIndex());
                    PerformOperation();
                    return;

                }
                else if (m_Val1 == -2 && m_Val2 > -1)
                {
                    Debug.Log("Left Loop Index' " + m_Index_Obj[0].GetComponent<Index_Script>().GetIndex() + " + " + m_Val2 + " + " + m_Val1 + " + " + m_Val2);
                    m_Script.Swap(m_Index_Obj[0].GetComponent<Index_Script>().GetIndex(), m_Val2);
                    SetVal2(m_Index_Obj[0].GetComponent<Index_Script>().GetIndex());
                    PerformOperation();
                    return;
                }
                else if (m_Val1 > -1 && m_Val2 == -2)
                {
                    Debug.Log("Right Loop Index' " + m_Val1 + " + " + m_Index_Obj[1].GetComponent<Index_Script>().GetIndex() + " + " + m_Val1 + " + " + m_Val2);
                    m_Script.Swap(m_Val1, m_Index_Obj[1].GetComponent<Index_Script>().GetIndex());
                    SetVal1(m_Index_Obj[1].GetComponent<Index_Script>().GetIndex());
                    PerformOperation();
                    return;
                }
                else if (m_Val1 > -1 && m_Val2 > -1)
                {
                    Debug.Log("no Loop Index' " + m_Val1 + " + " + m_Val2 + " + " + m_Val1 + " + " + m_Val2);
                    m_Script.Swap(m_Val1, m_Val2);
                    int temp = m_Val1;
                    SetVal1(m_Val2);
                    SetVal2(temp);
                    PerformOperation();
                    return;
                }
            }
        }

        

        private void PerformOperation()
        {
            if (m_NextCmd != null)
                switch (m_NextCmd.tag)
                {
                    case "Swap":
                        m_NextCmd.GetComponent<Swap>().Operation();
                        break;
                    case "<":
                        m_NextCmd.GetComponent<Less>().Operation();
                        break;
                    case ">":
                        m_NextCmd.GetComponent<Greater>().Operation();
                        break;
                    case "For":
                        m_NextCmd.GetComponent<Iterate_Fowards>().Operation();
                        break;
                }
        }
    }


}
