using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Player player;
    public Slider peeSlider, thirstSlider, hungerSlider, tirednessSlider;
    public List<Slider> sliders;

    private void Start()
    {
        sliders.Add(peeSlider);
        sliders.Add(thirstSlider);
        sliders.Add(hungerSlider);
        sliders.Add(tirednessSlider);
    }

    public void UpdateSliders()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            UpdateSlider(sliders[i], player.Stats.list[i]);
        }
    }

    void UpdateSlider(Slider slider, float value)
    {
        slider.value = value;
    }
}
