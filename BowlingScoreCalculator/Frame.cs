using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    public class Frame
    {
        public int FrameNumber { get; set; }
        public int Score { get; set; }
        public int Throw1 { get; set; }
        public int? Throw2 { get; set; }
        public int? Throw3 { get; set; }
        public bool isStrike { get; set; }
        public bool isSpare { get; set; }

        public Frame(int frameNum) {
            FrameNumber = frameNum;
            Score = 0;
        }
    }
}
