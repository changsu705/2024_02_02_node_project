using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protocols : MonoBehaviour
{
   
    public class Packets
    {
        public class common
        {
            public int cmd;                          //��ɼ��� ǥ��
            public string messsage;                  //�޼���
        }

        public class req_data : common
        {
            public int id;                          //id �� �޾Ƽ� �Ѵ�.(?)
            public string data;                     //���� ������
        }
    }
    
}
