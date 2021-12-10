using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    public class ReelsManager : MonoBehaviour
    {


        //�_����C�x���g���󂯎��̂��B
        //��̓I�ɂ́A�S�Ẵ��[�����~�܂������ɔ��΂��ׂ��֐��B
        Action<int> allReelStopEvent;
        //�ꉞ�v���p�e�B��
        public Action<int> AllReelStopEvent
        {
            get
            {
                return allReelStopEvent;
            }
            set
            {
                allReelStopEvent = value;
            }
        }

        [SerializeField] GameObject[] Reels;//���[���ւ̎Q��
        int stopedReelCount;//�~�܂��Ă��郊�[���̃J�E���g�B


        /// <summary>
        /// ���g���Q�Ƃ��Ă���S�Ẵ��[�����񂷊֐�
        /// </summary>
        public void StartAllReel()
        {
            SlotRoleDetaminer slotRoleDetaminer = new SlotRoleDetaminer();
            int[] hitReelSymbols = slotRoleDetaminer.DetaminAllSymbol();
            for(int i = 0; i < Reels.Length; i++)
            {
                Reels[i].GetComponent<IReelStartable>().StartReel(hitReelSymbols[i]);
                Reels[i].GetComponent<IReelStartable>().SetStopEvent(StopOneReel);
            }
            stopedReelCount = 0;//�S�Ẵ��[���͉��n�߂�
        }

        void StopOneReel()
        {
            //�~�܂��Ă��鐔��+1����
            stopedReelCount = stopedReelCount + 1;

            //�����A�~�܂��Ă��郊�[���̐����Q�Ƃ̐��Ƃ�������Ȃ�A�_����󂯎�����C�x���g�𔭉΂���B
            if(stopedReelCount == Reels.Length)
            {

                //�l�i�𔻒f����B
                SlotRoleJudgement slotRoleJudgement = new SlotRoleJudgement();//������ō��̃l�[�~���O�ł͂Ȃ��ł����H
                //���ׂẴ��[���̏��������Ƃ��āA���Ȃ׌N(���𔻒肵�Ă����l)�ɓn��
                int getCoin = slotRoleJudgement.CheckSlotReel(GetCurrentZugara());

                /*�f�o�b�O�p
                int[][] debugindex= GetCurrentZugara();
                for(int i = 0; i < debugindex.Length; i++)
                {
                    for(int j = 0; j < debugindex[i].Length; j++)
                    {
                        Debug.Log(i + "�Ԗڂ̃��[����" + j + "�Ԗڂ�" + debugindex[i][j]);
                    }
                }
                */

                //�Ō�Ɏ󂯎�����֐��𔭉΂���B
                allReelStopEvent(getCoin);
            }
        }


        /// <summary>
        /// ���ׂĂ̐}�����擾���ĕԂ��B
        /// �e���[�����Ƃɔz��Ƃ��A
        /// �񎟌��z��ŕԂ��B
        /// </summary>
        /// <returns></returns>
        public int[][] GetCurrentZugara()
        {
            int[][] reals = new int[3][];
            reals[0] = new int[3];
            reals[1] = new int[3];
            reals[2] = new int[3];

            for(int i = 0; i < 3; i++)
            {
                reals[i] = Reels[i].GetComponent<Reel>().GetAllReel();           
            }

            return reals;
        }
        

    }
}