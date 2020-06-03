using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectTile;
    public float Damage;
    public float animTime = 0.25f;
    public float projectTileForce;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("isAttack", true);
        }
        StartCoroutine(Fire());
    }

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }

    private IEnumerator Fire()
    {
        if(IsAnimationPlaying("Player_Attack_Right") || IsAnimationPlaying("Player_Attack_Left") ||
               IsAnimationPlaying("Player_Attack_Up") || IsAnimationPlaying("Player_Attack_Down"))
        {
            yield return new WaitForSeconds(animTime);
            animator.SetBool("isAttack", false);
            GameObject Bullet = Instantiate(projectTile, transform.position, Quaternion.identity);
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pos = transform.position;
            Vector2 direction = (mousepos - pos).normalized;
            Bullet.GetComponent<Rigidbody2D>().velocity = direction * projectTileForce;
            Bullet.GetComponent<TestBullet>().Damage = Damage;
        }
    }
}
