using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTextEffect : MonoBehaviour
{
    List<Animator> _animators;
    void Start()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(PlayWave());
    }
    IEnumerator PlayWave()
    {
        while (true)
        {
            foreach (var animator in _animators)
            {
                animator.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(0.15f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
