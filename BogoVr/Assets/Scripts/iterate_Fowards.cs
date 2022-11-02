using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WidgetScript
{
    [RequireComponent(typeof(Widget))]
    public class Iterate_Fowards : Widget
    {
        // Start is called before the first frame update
        public override Widget InLoopCmd { get { return m_InLoopCmd; }  set{ m_InLoopCmd = value; } }
        public override Widget OutLoopCmd { get{ return m_OutLoopCmd; } set{ m_OutLoopCmd = value; } }
        public override int LoopIndex { get { return m_loop_Index; }}

        public override void Operation()
        {
            for (int i = 0; i < 6; i++)
            {
                //Debug.Log(m_InLoopCmd);
                if (m_InLoopCmd)
                    m_InLoopCmd.Operation();
                m_loop_Index = i;
            }

            if (!m_OutLoopCmd)
                return;
            m_OutLoopCmd.Operation();
        }


        //do nothings//
        public override void SetIndexObj(int index, Index_Script obj) { /*Do Nothing */ }
        public override int Val1 { get; set; }
        public override int Val2 { get; set; }

    }
}
