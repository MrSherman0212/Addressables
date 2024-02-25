using UnityEngine;

public class SpinObject : MonoBehaviour
{
    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _transform.Rotate(0, 0, 1);
    }
}
