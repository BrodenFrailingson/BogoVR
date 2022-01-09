using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WidgetScript
{
    
    public class Widget : MonoBehaviour
    {
        protected int m_Val1 = -1, m_Val2 = -1;
        protected GameObject m_List, m_NextCmd, m_FalseCmd;

        public void SetVal1(int val) { m_Val1 = val; }

        public void SetVal2(int val) { m_Val2 = val; }

        public void SetNextCmd(GameObject next) { m_NextCmd = next; }

        public void SetFalseCmd(GameObject fls) { m_FalseCmd = fls; }

    }

}