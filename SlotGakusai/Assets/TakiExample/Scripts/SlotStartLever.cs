using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    public class SlotStartLever : MonoBehaviour
    {

        //�_����C�x���g���󂯎��̂��B
        //��̓I�ɂ́A���o�[�������ꂽ�Ƃ��Ɏ��s���邩�񂷂�������B
        Action slotStartEvent;

        //�ꉞ�v���p�e�B��
        public Action SlotStartEvent
        {
            get
            {
                return slotStartEvent;
            }
            set
            {
                slotStartEvent = value;
            }
        }

        /// <summary>
        /// Unity�̃{�^���Ȃǂ̃C�x���g����Ăяo���Ƃ��p
        /// </summary>
        public void UseLever()
        {
            slotStartEvent();//�C�x���g�����s����B
        }

    }
}