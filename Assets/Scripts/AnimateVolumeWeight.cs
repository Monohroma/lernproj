using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AnimateVolumeWeight : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private float _animationTime = 0.3f;
    [SerializeField] private LevelGetter _levelGetter;

    private bool _isAnimate = false;
    private float _elapsedTime;

    public void Animate()
    {
        if(_isAnimate)
        {
            return;
        }

        _isAnimate = true;

        Vignette vignette;

        if(_volume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.color.value = _levelGetter.GetterColor;
        }

        _elapsedTime = 0f;

        StartCoroutine(AnimateVolume());
    }

    protected IEnumerator AnimateVolume()
    {
        while (_elapsedTime < _animationTime)
        {
            yield return new WaitForEndOfFrame();

            _volume.weight = Mathf.Sin(Mathf.PI * _elapsedTime / _animationTime);

            _elapsedTime += Time.deltaTime;
        }

        _isAnimate = false;
    }
}
