using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    private Quaternion m_startRot;
    private bool m_rotate = false;

    private void Start()
    {
        m_startRot = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    public bool rotate{ set { m_rotate = value; } }

    // Update is called once per frame
    void Update()
    {
        if (m_rotate)
            transform.rotation = Quaternion.Slerp(transform.rotation, m_startRot, 0.2f);
    }
}
