using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// �X���b�g�����n�߂��u�ԂɁA�ǂ�Ȃ₭�����낢���邩�����肷��z
    /// </summary>
    public class SlotRoleDetaminer
    {

        /// <summary>
        /// �ǂ�Ȗ����������邩�����肵�Ă����ꏊ�ł�
        /// �������m���I�Ɏw�肵����D���ɂł���
        /// </summary>
        /// <returns></returns>
        public int[] DetaminAllSymbol()
        {
            return new int[] { Random.Range(0, 7), Random.Range(0, 7), Random.Range(0, 7) };
        }


    }
}