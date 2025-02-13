using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MimicSpace
{
    /// <summary>
    /// This is a very basic movement script, if you want to replace it
    /// Just don't forget to update the Mimic's velocity vector with a Vector3(x, 0, z)
    /// </summary>
    public class Movement : MonoBehaviour
    {
        [Header("Controls")]
        [Tooltip("Body Height from ground")]
        [Range(0.5f, 5f)]
        public float height = 0.8f;
        public float speed = 5f;
        Vector3 velocity = Vector3.zero;
        public float velocityLerpCoef = 4f;
        Mimic myMimic;
        public Transform[] posMoveMimics;
        public Transform newPosMove;
        public Transform player;

        private void Start()
        {
            myMimic = GetComponent<Mimic>();
            newPosMove = posMoveMimics[Random.Range(0, posMoveMimics.Length)];
        }

        void Update()
        {
            // velocity = Vector3.Lerp(velocity, new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed, velocityLerpCoef * Time.deltaTime);
            if(!MimicAttack.Instance.isAttack){
                TargetMove();
            }
            else{
                MimicAttack.Instance.Attack();
                MoveToAttack(player);
            }
               
        }

        public void TargetMove(){
            if (Vector3.Distance(transform.position, newPosMove.position) > 0.1f)
            {
                // Lerp velocity về vị trí đích
                velocity = Vector3.Lerp(velocity, (newPosMove.position - transform.position).normalized * speed, velocityLerpCoef * Time.deltaTime);
            }
            else
            {
                newPosMove = posMoveMimics[Random.Range(0, posMoveMimics.Length)];
                // Nếu đã tới vị trí đích, đặt velocity về 0
                // velocity = Vector3.zero;
            }
            MimicMove();
        }

        public void MimicMove(){
            myMimic.velocity = velocity;

            transform.position = transform.position + velocity * Time.deltaTime;
            RaycastHit hit;
            Vector3 destHeight = transform.position;
            if (Physics.Raycast(transform.position + Vector3.up * 5f, -Vector3.up, out hit))
                destHeight = new Vector3(transform.position.x, hit.point.y + height, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destHeight, velocityLerpCoef * Time.deltaTime);
        }
        public void MoveToAttack(Transform target){
            newPosMove = target;
            velocity = Vector3.Lerp(velocity, (newPosMove.position - transform.position).normalized * speed, velocityLerpCoef * Time.deltaTime);
            MimicMove();
        }   
    }

}