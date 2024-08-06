using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private void Start()
    {
      
        StartCoroutine(ReturnTopoolafterDelay(60));
    }
    private IEnumerator ReturnTopoolafterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        PoolManger.Instance.ReturnToPool("Platform",this.gameObject);
    }

    public void PlatformReturningEventHandler(PlatformReturningEvent e)
    {
     
    }


  
}
