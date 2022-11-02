using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WidgetScript
{
    [RequireComponent(typeof(Widget))]
    public class Greater : Widget
    {
        public override Widget InLoopCmd { get { return m_InLoopCmd; } set { m_InLoopCmd = value; } }
        public override Widget OutLoopCmd { get { return m_OutLoopCmd; } set { m_OutLoopCmd = value; } }
        public override int Val1 { get { return m_Val1; } set { m_Val1 = value; } }
        public override int Val2 { get { return m_Val2; } set { m_Val2 = value; } }
        public override void SetIndexObj(int index, Index_Script obj) { m_Index_Obj[index] = obj; }


        public void Awake()
        {
            m_List = GameObject.FindGameObjectWithTag("List").GetComponent<List_Script>();
        }


        public override void Operation()
        {
            if (!m_List)
                m_List = GameObject.FindGameObjectWithTag("List").GetComponent<List_Script>();

            if (m_Val1 == -2 && m_Val2 == -2)
            {
                if (m_List.Greater(m_Index_Obj[0].GetIndex(), m_Index_Obj[1].GetIndex()))
                    if (m_InLoopCmd)
                        m_InLoopCmd.Operation();

            }
            else if (m_Val1 == -2 && m_Val2 > -1)
            {
                if (m_List.Greater(m_Index_Obj[0].GetIndex(), m_Val2))
                    if (m_InLoopCmd)
                        m_InLoopCmd.Operation();
            }
            else if (m_Val1 > -1 && m_Val2 == -2)
            {
                if (m_List.Greater(m_Val1, m_Index_Obj[1].GetIndex()))
                    if (m_InLoopCmd)
                        m_InLoopCmd.Operation();
            }
            else if (m_Val1 > -1 && m_Val2 > -1)
            {
                if (m_List.Greater(m_Val1, m_Val2))
                    if (m_InLoopCmd)
                        m_InLoopCmd.Operation();
            }

            if (!m_OutLoopCmd)
                return;
            m_OutLoopCmd.Operation();
        }


        //do nothings//

        public override int LoopIndex { get { return m_loop_Index; } }

    }
}
