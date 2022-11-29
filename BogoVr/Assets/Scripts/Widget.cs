using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WidgetScript
{
    
    public abstract class Widget : MonoBehaviour
    {
        protected int m_Val1 = -1, m_Val2 = -1, m_loop_Index = 0;
        protected List_Script m_List;
        protected Widget m_InLoopCmd, m_OutLoopCmd, m_PrevCmd;
        protected Index_Script[] m_Index_Obj;

        
        public abstract Widget InLoopCmd { get; set; }
        public abstract Widget OutLoopCmd { get; set; }
        public abstract int Val1 { get; set; }
        public abstract int Val2 { get; set; }
        public abstract int LoopIndex { get;}


        public abstract void Operation();
        public abstract void SetIndexObj(int index, Index_Script obj);
        
    }

}