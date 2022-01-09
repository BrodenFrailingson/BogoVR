using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WidgetScript
{
    
    public class Widget : MonoBehaviour
    {
        protected int m_Val1 = -1, m_Val2 = -1, m_loop_Index = 0;
        protected GameObject m_List, m_NextCmd, m_FalseCmd;
        protected GameObject[] m_Index_Obj = {null, null};

        public void SetVal1(int val) { m_Val1 = val; }

        public void SetVal2(int val) { m_Val2 = val; }

        public void SetLoopIndex(int i) { m_loop_Index = i; }

        public void SetNextCmd(GameObject next) { m_NextCmd = next; }

        public void SetFalseCmd(GameObject fls) { m_FalseCmd = fls; }

        public int GetLoopIndex() { return m_loop_Index; }

        public void SetIndexObj1(GameObject obj) { m_Index_Obj[0] = obj; }
        public void SetIndexObj2(GameObject obj) { m_Index_Obj[1] = obj; }



    }

}