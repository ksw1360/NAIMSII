using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Operator.Models
{
    public class Dummy //임시 Data
    {
        public bool IsSelected { get; set; } // CheckBox용
        public int Title { get; set; } // 순번
        public string Email { get; set; } // 자료명
        public string Duration { get; set; } // 전송처
        public string TakeTime { get; set; } // 예상소요시간
        public int Progress { get; set; } // 파일상태 (퍼센트)
        public string AddedTime { get; set; } // 파일 상태
        public string CompletedTime { get; set; } // 배포일
        public string protectdate { get; set; } // 보호기간 만료일
        public long FileSize { get; set; } // 파일크기(kb)
    }
}
