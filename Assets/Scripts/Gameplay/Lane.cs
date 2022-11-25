using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Lane : MonoBehaviour
{
    private KeyCode m_KeyToPress;
    private SpriteRenderer m_SR;
    private Color m_PressedColor;
    private Color m_DefaultColor;

    private float m_AlphaOnPressed = 0.6f;

    public void SetUp(KeyCode key, Color color)
    {
        m_KeyToPress = key;
        m_DefaultColor = color;
        Initialize();
    }

    private void Initialize()
    {
        m_SR = GetComponent<SpriteRenderer>();
        m_SR.color = m_DefaultColor;
        m_PressedColor = new Color(m_DefaultColor.r, m_DefaultColor.g, m_DefaultColor.b, m_AlphaOnPressed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_KeyToPress))
        {
            m_SR.color = m_PressedColor;
        }

        if (Input.GetKeyUp(m_KeyToPress))
        {
            m_SR.color = m_DefaultColor;
        }
    }
}
