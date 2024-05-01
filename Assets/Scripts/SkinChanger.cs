using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    public Slider colorSlider; // ссылка на компонент Slider
    public SpriteRenderer playerSprite; // ссылка на компонент SpriteRenderer

    private const string color_value = "PlayerColor"; // ключ для сохранения цвета в PlayerPrefs
    private Color initialColor; // изначальный цвет спрайта

    private void Start()
    {
        // Сохраняем изначальный цвет спрайта
        initialColor = playerSprite.color;

        // Загружаем сохраненный цвет из PlayerPrefs
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
            // Если значение слайдера равно нулю, используем изначальный цвет спрайта
            playerSprite.color = initialColor;
        }
        else
        {
            // Иначе используем цвет, сохраненный в PlayerPrefs
            SetSpriteColorFromSliderValue(hue);
        }

        // Сохраняем текущее значение слайдера в PlayerPrefs
        PlayerPrefs.SetFloat(color_value, hue);
    }

    private void SetSpriteColorFromSliderValue(float hue)
    {
        // Создаем новый цвет из текущего значения слайдера и устанавливаем его как цвет спрайта 
        playerSprite.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}

