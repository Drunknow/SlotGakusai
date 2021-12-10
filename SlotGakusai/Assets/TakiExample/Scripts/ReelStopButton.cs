using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// ���[�����~�߂邽�߂����ɑ��݂���{�^��
    /// </summary>
    public class ReelStopButton : MonoBehaviour
    {
        [SerializeField] GameObject reel;


        /// <summary>
        /// ���g���Q�Ƃ��郊�[���́A�X�g�b�v�֐����Ăяo���B
        /// </summary>
        public void StopReel()
        {
            //�C���^�t�F�[�X���烊�[�����~�߂�z�����������B
            reel.GetComponent<IReelStopable>().StopReel();
        }
    }
}