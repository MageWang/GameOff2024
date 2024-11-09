using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieMarc.TopDown
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class CharacterAnim : MonoBehaviour
    {
        private PlayerCharacter character;
        private CharacterHoldItem character_item;
        private Animator animator;

        void Awake()
        {
            character = GetComponent<PlayerCharacter>();
            character_item = GetComponent<CharacterHoldItem>();
            animator = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            //Anims
            animator.SetFloat("Speed", character.GetMove().magnitude);
            animator.SetInteger("Side", character.GetSideAnim());
            if(character_item != null)
                animator.SetBool("Hold", character_item.GetHeldItem() != null);
        }
    }

}