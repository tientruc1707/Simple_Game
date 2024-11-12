using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    //public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == StringConstant.ObjectTags.PLAYER)
        {
            StartCoroutine("LevelExit");
        }
    }

    IEnumerator LevelExit()
    {
        yield return new WaitForSeconds(0.1f);

        //UIManager.Instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);
        GameManager.Instance.CompleteLevel = true;
    }
}
