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
            Debug.Log(m_Val1 + " + " + m_Val2);
            if (m_Val1 != -1 && m_Val2 != -1)
            {
                m_List = GameObject.FindGameObjectWithTag("List");
                if (m_List == null)
                    m_List = GameObject.FindGameObjectWithTag("List_Out");
                if (m_List.GetComponent<List_Script>().Greater(m_Val1, m_Val2))
                    PerformOperation(m_NextCmd);
                else
                    PerformOperation(m_FalseCmd);
                
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
                    case "Iterate_Through":

                        break;

                }
        }

    }
}
