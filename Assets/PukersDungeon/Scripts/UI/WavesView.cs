using UnityEngine;

public class WavesView : MonoBehaviour
{
    [SerializeField] private GameObject[] _imagesOfWaves;
    [SerializeField] private WaveSpawner _spawner;

    private void OnEnable()
    {
        _spawner.WaveChanged += imageView;
    }

    private void imageView(int currentWaveIndex)
    {
        _imagesOfWaves[currentWaveIndex].SetActive(true);
    }
}