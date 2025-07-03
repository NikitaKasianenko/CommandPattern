using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.onValueChanged.AddListener(GameEvents.ChangeSpeed);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(GameEvents.ChangeSpeed);
    }

}
