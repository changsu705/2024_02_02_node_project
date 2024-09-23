using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protocols : MonoBehaviour
{
   
    public class Packets
    {
        public class common
        {
            public int cmd;                          //명령숫자 표시
            public string messsage;                  //메세지
        }

        public class req_data : common
        {
            public int id;                          //id 를 받아서 한다.(?)
            public string data;                     //전달 데이터
        }
    }
    
}
