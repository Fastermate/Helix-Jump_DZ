using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;
    private float _startY;

    private void Start()
    {
        _startY = Player.transform.position.y;

    }

    private void Update()
    {
        float currentY = Player.transform.position.y;
        float finishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY, currentY);
        Slider.value = t;
    }
}
