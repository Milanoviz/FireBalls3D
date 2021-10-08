using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private float _filledDuration;
    [SerializeField] private Slider _slider;
    [SerializeField] private Tower _tower;
    [SerializeField] private TowerBuilder _towerBuilder;

    private float _startTowerSize;

    private void Awake()
    {
        _startTowerSize = _towerBuilder.GetTowerStartSize();
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _tower.SizeUpdated += OnTowerSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= OnTowerSizeUpdated;
    }

    private void OnTowerSizeUpdated(int size)
    {
        if (size != _startTowerSize)
        {
            _slider.DOValue((_startTowerSize - size) / _startTowerSize, _filledDuration);
        }
    }
}
