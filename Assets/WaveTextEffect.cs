using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveTextEffect : MonoBehaviour
{
    List<Animator> _animators;
    
    bool load = false;
    void Start()
    {
        //Handle();   
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(PlayWave());
    }
    //public void Handle()
    //{
    //    string TitleText = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).Title;
    //    int temp = TitleText.Length/2;
    //    Debug.Log(TitleText.Length);
    //    for (int i = 1; i <= TitleText.Length; i++)
    //    {
    //        sample.text = TitleText.Substring(i-1, 1);
    //        TextMeshProUGUI _T  = Instantiate(sample,this.gameObject.transform);
    //        _T.transform.position = new Vector3(this.transform.position.x - (sample.preferredWidth * (temp - i))+ sample.preferredWidth, this.transform.position.y, 0);
    //        Debug.Log(sample.text+"i= "+i);
    //    }
    //}
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
