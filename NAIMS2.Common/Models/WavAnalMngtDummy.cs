using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Common.Models
{
    public class WavAnalMngtDummy
    {
        public string MissionName { get; set; }   //임무폴더명
        public string Collect { get; set; }       //수집체계
        public string CollectBox { get; set; }    //수집함
        public DateTime CollectDate { get; set; } //수집일자
        public DateTime RecvDate { get; set; }    //수집일자
        public int WavSignalCnt { get; set; }     //원음신호 수
        public int ChannelCnt { get; set; }       //채널 수
        public string CellectMove { get; set; }   //수집영상
        public string JobStatus { get; set; }     //처리상태
        public string WorkName { get; set; }      //원음분석담당자
    }
}

