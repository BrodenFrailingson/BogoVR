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
            if (m_Val1 != -1 && m_Val2 != -1)
            {
                m_List = GameObject.FindGameObjectWithTag("List");
                if (m_List == null)
                    m_List = GameObject.FindGameObjectWithTag("List_Out");
                m_List.GetComponent<List_Script>().Swap(m_Val1, m_Val2);
                PerformOperation();
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

                        break;
                    case ">":

                        break;
                    case "Iterate_Through":

                        break;

                }
        }
    }


}
