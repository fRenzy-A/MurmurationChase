using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderManager : MonoBehaviour
{
    public SmoolsController SmoolsController;

    public TextMeshProUGUI VelocityNum = null;
    public TextMeshProUGUI AttractMultNum = null;
    public TextMeshProUGUI RepelMultNum = null;
    public TextMeshProUGUI AttractRadNum = null;
    public TextMeshProUGUI RepelRadNum = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //All these Methods are for the sliders
    public void VelocityCapSlider(float value)
    {
        float localValue = value;
        VelocityNum.text = localValue.ToString();
        SmoolsController.MaxSpeedCap = value;      
    }
    public void AttractMultiplierSlider(float value)
    {
        float localValue = value;
        AttractMultNum.text = localValue.ToString();
        SmoolsController.AttractMultiplier = value;
    }
    public void RepelMultiplierSlider(float value)
    {
        float localValue = value;
        RepelMultNum.text = localValue.ToString();
        SmoolsController.RepelMultiplier = value;
    }
    public void AttractRangeSlider(float value)
    {
        float localValue = value;
        AttractRadNum.text = localValue.ToString();
        SmoolsController.AttractRange = value;
    }
    public void RepelRangeSlider(float value)
    {
        float localValue = value;
        RepelRadNum.text = localValue.ToString();
        SmoolsController.RepelRange = value;
    }
}
