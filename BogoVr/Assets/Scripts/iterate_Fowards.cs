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
                if (m_NextCmd != null)
                {
                   
                }
            }
        }
    }
}
