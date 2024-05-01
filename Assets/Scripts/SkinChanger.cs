using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    public Slider colorSlider; // ������ �� ��������� Slider
    public SpriteRenderer playerSprite; // ������ �� ��������� SpriteRenderer

    private const string color_value = "PlayerColor"; // ���� ��� ���������� ����� � PlayerPrefs
    private Color initialColor; // ����������� ���� �������

    private void Start()
    {
        // ��������� ����������� ���� �������
        initialColor = playerSprite.color;

        // ��������� ����������� ���� �� PlayerPrefs
        if (PlayerPrefs.HasKey(color_value))
        {
            float hue = PlayerPrefs.GetFloat(color_value);
            colorSlider.value = hue;
            SetSpriteColorFromSliderValue(hue);
        }
    }

    public void OnColorChange()
    {
        float hue = colorSlider.value;

        if (hue == 0f)
        {
            // ���� �������� �������� ����� ����, ���������� ����������� ���� �������
            playerSprite.color = initialColor;
        }
        else
        {
            // ����� ���������� ����, ����������� � PlayerPrefs
            SetSpriteColorFromSliderValue(hue);
        }

        // ��������� ������� �������� �������� � PlayerPrefs
        PlayerPrefs.SetFloat(color_value, hue);
    }

    private void SetSpriteColorFromSliderValue(float hue)
    {
        // ������� ����� ���� �� �������� �������� �������� � ������������� ��� ��� ���� ������� 
        playerSprite.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}

