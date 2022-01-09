using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WidgetScript
{
    [RequireComponent(typeof(Widget))]
    public class Greater : Widget
    {
        // Start is called before the first frame update
        public void Operation()
        {
            List_Script m_Script;
            Debug.Log(m_Val1 + " + " + m_Val2);
            if (m_Val1 != -1 && m_Val2 != -1)
            {

                m_List = GameObject.FindGameObjectWithTag("List") ? GameObject.FindGameObjectWithTag("List") : null;
                m_List = m_List != null ? m_List : GameObject.FindGameObjectWithTag("List_Out");


                m_Script = m_List.GetComponent<List_Script>();

                
                if (m_Val1 == -2 && m_Val2 == -2)
                {
                    Debug.Log("Here");
                    if(m_Script.Greater(m_Index_Obj[0].GetComponent<Index_Script>().GetIndex(), m_Index_Obj[1].GetComponent<Index_Script>().GetIndex()))
                        PerformOperation(m_NextCmd);
                    else
                        PerformOperation(m_FalseCmd);
                    return;

                }
                else if (m_Val1 == -2 && m_Val2 > -1)
                {
                    Debug.Log("Here");
                    if (m_Script.Greater(m_Index_Obj[0].GetComponent<Index_Script>().GetIndex(), m_Val2))
                        PerformOperation(m_NextCmd);
                    else
                        PerformOperation(m_FalseCmd);
                    return;
                }
                else if (m_Val1 > -1 && m_Val2 == -2)
                {
                    Debug.Log("Here");
                    if (m_Script.Greater(m_Val1, m_Index_Obj[1].GetComponent<Index_Script>().GetIndex()))
                        PerformOperation(m_NextCmd);
                    else
                        PerformOperation(m_FalseCmd);
                    return;
                }
                else if (m_Val1 > -1 && m_Val2 > -1)
                {
                    Debug.Log("Here");
                    if (m_Script.Greater(m_Val1, m_Val2))
                        PerformOperation(m_NextCmd);
                    else
                        PerformOperation(m_FalseCmd);
                    return;
                }
                Debug.Log("no conditions true");
            }
        }

        private void PerformOperation(GameObject next)
        {
            if (next != null)
                switch (next.tag)
                {
                    case "Swap":
                        m_NextCmd.GetComponent<Swap>().Operation();
                        break;
                    case "<":

                        break;
                    case ">":

                        break;
                    case "For":

                        break;

                }
        }

    }
}
