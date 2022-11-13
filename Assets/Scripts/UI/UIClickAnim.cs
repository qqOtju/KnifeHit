using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIClickAnim : MonoBehaviour
{
   private float _time = 0.2f;
   public void OnClickAnim(Image image)
   {
      image.DOFade(0.7f,_time).OnComplete(() =>
      {
         image.DOFade(1f,_time);
      });
   }
}
