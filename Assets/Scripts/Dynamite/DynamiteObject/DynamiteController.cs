using System.Collections;
using UnityEngine;
/// <summary>
/// Contolls sequens of actions after dynamite was instantiated.
/// </summary>
public class DynamiteController : MonoBehaviour
{
    [SerializeField] private float ExplosionDelay = 2.0f;
    [SerializeField] private DynamiteExplosion DynamiteExplosion;
    [SerializeField] private AudioSource ExplosionSound;
    [SerializeField] private Animator ExplosionEffect;
    [SerializeField] private DynamiteMovement DynamiteMovement;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(ExplosionDelay);
        DynamiteExplosion.Explode();
        //анимация взрыва
        if (Settings.IsSoundsOn)
        {
            ExplosionSound.Play();
        }
        //это тоже кривой код, но пока так
        ExplosionEffect.gameObject.SetActive(true);
        //выключение иконки динамита, потому что я блять не могу сделать это переменной и назначить в инспекторе.
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        DynamiteMovement.enabled = false;
        yield return new WaitForSeconds(/*ExplosionSound.clip.length*/1.0f);
        Destroy(gameObject);
    }
}
