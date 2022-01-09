using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WidgetScript
{
    [RequireComponent(typeof(Widget))]
    public class Iterate_Fowards : Widget
    {
        // Start is called before the first frame update
        public void Operation()
        {
            for (int i = 0; i < 6; i++)
            {
                Debug.Log(m_NextCmd);
                SetLoopIndex(i);
                PerformOperation(m_NextCmd);
            }
            PerformOperation(m_FalseCmd);
        }

        private void PerformOperation(GameObject next)
        {
            if (next != null)
            {
                switch (next.tag)
                {
                    case "Swap":
                        m_NextCmd.GetComponent<Swap>().Operation();
                        break;
                    case "<":
                        m_NextCmd.GetComponent<Less>().Operation();
                        break;
                    case ">":
                        Debug.Log("bouta enter greater");
                        m_NextCmd.GetComponent<Greater>().Operation();
                        break;
                    case "For":
                        m_NextCmd.GetComponent<Iterate_Fowards>().Operation();
                        break;

                }
            }
        }
    }
}
