using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Script : MonoBehaviour
{
    private bool m_IsHeld = false;

    void Update()
    {
        Debug.Log(transform.position.z);
        switch (m_IsHeld) 
        {
            case false:
                break;
            default:
                if (transform.position.z < -0.15f)
                    transform.position = new Vector3(0.0f, 0.0f, -0.15f);
                if (transform.position.z !> 0.0f)
                    transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                break;
        }
    }

    public void IsHeld() { m_IsHeld = !m_IsHeld; }

    public void IsReleased() { m_IsHeld = !m_IsHeld; }
}
