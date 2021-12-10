using System;
using System.Linq;
using UnityEngine;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// ��]���郊�[�����������܂��B
    /// </summary>
    public class Reel : MonoBehaviour, IReelStopable, IReelStartable
    {
        enum ReelState
        {
            Stop,
            Roll,
            Slip,
        }

        int targetSymbol;//�ǂ̃V���{���Ŏ~�܂邱�Ƃ��߂��Ă��邩���i�[�B-1�Ńt���[

        ReelState reelState;
        ReelRoll[] reelRolls;//3�̕\���������

        [SerializeField] float topY;//���[���̈�ԏ�ƂȂ���W
        [SerializeField] float bottomY;//���[���̒�ƂȂ���W

        //���[���}�l�[�W���[����C�x���g���󂯎��̂��B
        //��̓I�ɂ́A���[�����~�߂邱�Ƃɐ��������ۂɔ��΂��ׂ��֐��B
        Action reelStopEvent;





        void Start()
        {

            reelRolls = new ReelRoll[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                reelRolls[i] = transform.GetChild(i).GetComponent<ReelRoll>();
                reelRolls[i].topY = topY;
                reelRolls[i].bottomY = bottomY;
                reelRolls[i].symbolCount = reelRolls.Length;
            }
        }

        void FixedUpdate()
        {

            bool isEndRolling = false;

            if (reelState == ReelState.Roll || reelState == ReelState.Slip)
            {
                foreach (ReelRoll reelRoll in reelRolls)
                {
                    //�}���̏ꏊ�����炷
                    if (reelRoll.isRolling)
                    {
                        reelRoll.ScrollReel();
                    }
                    else if (reelRoll.isStopping)
                    {
                        isEndRolling = reelRoll.ScrollReel() || isEndRolling;
                    }
                }
                if (isEndRolling)
                {
                    //������������������A���������Ɏw��̏����ɂȂ�܂œ��ׂ�c�c�͂�

                    if (GetAllReel()[2] == targetSymbol || targetSymbol == -1)
                    {
                        StopAllReelRolling();

                    }

                }
            }

        }




        /// <summary>
        /// ���g���Q�Ƃ��Ă��郊�[�����~�߂�֐�
        /// </summary>
        public void StopReel()
        {
            if (reelState == ReelState.Roll)
            {
                Debug.Log("���[�����~�߂܂����B");
                reelState = ReelState.Slip;
                for (int i = 0; i < reelRolls.Length; i++)
                {
                    reelRolls[i].StopMainRolling();
                }
            }
            else
            {
                Debug.Log("���[���͎~�܂��Ă���͂��ł�");

            }
        }
        /// <summary>
        /// ���g���Q�Ƃ��Ă��郊�[�����񂷊֐�
        /// </summary>
        public void StartReel(int target)
        {
            targetSymbol = target;
            if (reelState == ReelState.Roll)
            {
                Debug.Log("���[���͊��ɉ���Ă��܂�");
            }
            else
            {
                Debug.Log("���[���͉��n�߂�");
                reelState = ReelState.Roll;
                for (int i = 0; i < reelRolls.Length; i++)
                {
                    reelRolls[i].isRolling = true;
                }
            }
        }


        public void SetStopEvent(Action action)
        {
            reelStopEvent = action;
        }



        /// <summary>
        /// ���[���̏��Ԃ������̏��Ɏ��
        /// </summary>
        /// <returns></returns>
        public int[] GetAllReel()
        {

            int[] returnArray = new int[reelRolls.Length];
            reelRolls = reelRolls.OrderByDescending(a => a.transform.position.y).ToArray();
            for (int i = 0; i < reelRolls.Length; i++)
            {
                returnArray[i] = reelRolls[i].GetZugara();
                //Debug.Log(reelRolls[i].GetZugara());
            }
            return returnArray;
        }

        /// <summary>
        /// ���S�Ƀ��[�����~�߂�
        /// </summary>
        void StopAllReelRolling()
        {
            reelStopEvent();//�}�l�[�W���[����󂯎�����C�x���g�𔭉�
            reelState = ReelState.Stop;
            Debug.Log("���[���͊��S�Ɏ~�܂���");
        }

    }
}
