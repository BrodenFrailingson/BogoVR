using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Attachment_Script : MonoBehaviour
{
    [SerializeField] private Transform m_Copy_Pos;
    [SerializeField] private GameObject m_Prefab;
    private bool can_copy = true;

    public void Awake()
    {
        Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);
        gameObject.transform.localScale = scale;
    }

    public void Dupe() 
    {
        if (can_copy) 
        {
            Instantiate(m_Prefab, m_Copy_Pos.position, m_Copy_Pos.rotation);
            can_copy = !can_copy;
        }
    }


}
