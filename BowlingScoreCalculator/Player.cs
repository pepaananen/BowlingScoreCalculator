using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    public class Player
    {
        public string Name {  get; set; }
        public int FinalScore { get; set; }
        public List<Frame> Round { get; set; }

        public Player(string name) { 
            Name = name;
            FinalScore = 0;
            Round = new List<Frame>();
            for (int i = 1; i <= 10; i++) { 
                Round.Add(new Frame(i));
            }
        }

        public void GetThrows(Frame frame) {
            int downedPins = GetThrowFromUser(Name, frame.FrameNumber, 1);
            if (downedPins == 10) {//If we have a strike
                frame.isStrike = true;
                frame.Throw1 = 10;
            } else {
                frame.Throw1 = downedPins;
                downedPins = GetThrowFromUser(Name, frame.FrameNumber, 2, frame.Throw1);
                if (downedPins + frame.Throw1 == 10) {//If we have a spare
                    frame.isSpare = true;
                }
                frame.Throw2 = downedPins;
            }

            if (frame.FrameNumber == 10 && (frame.isStrike || frame.isSpare)) {//If we are on the last frame and have a strike or spare
                if (frame.isSpare) {
                    downedPins = GetThrowFromUser(Name, frame.FrameNumber, 3);
                    frame.Throw3 = downedPins;
                } else {//Strike on frame 10
                    downedPins = GetThrowFromUser(Name, frame.FrameNumber, 2);
                    frame.Throw2 = downedPins;
                    if (downedPins == 10) {//If we got a strike on the second throw of frame 10 reset for throw 3
                        downedPins = 0;
                    }
                    downedPins = GetThrowFromUser(Name, frame.FrameNumber, 3,downedPins);
                    frame.Throw3 = downedPins;
                }
            }

        }

        public int GetThrowFromUser(string name, int frameNum, int throwNum, int prevThrow = 0) {
            string throwInput = "";
            int downedPins = 0;
            bool validInput = true;
            Console.WriteLine("What did " + name + " get on throw " + throwNum + " of Frame " + frameNum + "?");
            throwInput = Console.ReadLine();
            validInput = Int32.TryParse(throwInput, out downedPins);
            int pinsLeft = 10 - prevThrow;
            while (!validInput || downedPins > pinsLeft || downedPins < 0) {//Check for valid input
                Console.WriteLine("Sorry that input was invalid. Please input an integer between 0 and " + pinsLeft + ".\nWhat did " + name + " get on throw " + throwNum + " of Frame " + frameNum + "?");
                throwInput = Console.ReadLine();
                validInput = Int32.TryParse(throwInput, out downedPins);
            }
            return downedPins;
        }

        public void CalculateFinalScore() {
            CalculateFramesScore();
            FinalScore = Round.Sum(f => f.Score);
        }

        public void CalculateFramesScore() {
            for (int i = 0; i < Round.Count; i++) {//Get the score of each frame.
                Frame frame = Round[i];
                if (!frame.isStrike && !frame.isSpare && frame.Throw2 != null) {//If we have an open frame
                    frame.Score = (int)(frame.Throw1 + frame.Throw2);
                } else if (frame.isSpare && frame.Throw2 != null) {//If we have a spare
                    if (frame.FrameNumber == 10 && frame.Throw3 != null) {//Spare on the 10th
                        frame.Score = (int)(frame.Throw1 + frame.Throw2 + frame.Throw3);
                    } else {//All other spares
                        frame.Score = (int)(frame.Throw1 + frame.Throw2 + Round[i + 1].Throw1);
                    }
                } else {//If the current frame was a strike
                    if (frame.FrameNumber < 10) {//If we are not on the last frame
                        Frame nextFrame = Round[i + 1];
                        if (nextFrame.isStrike) {
                            if (frame.FrameNumber < 9) {
                                frame.Score = frame.Throw1 + 10 + Round[i + 2].Throw1;
                            } else if (nextFrame.Throw3 != null) {
                                frame.Score = (int)(frame.Throw1 + 10 + nextFrame.Throw3);
                            }
                        }
                    } else {//Strike on the last frame
                        if (frame.Throw2 != null && frame.Throw3 != null) {
                            frame.Score = (int)(frame.Throw1 + frame.Throw2 + frame.Throw3);
                        }
                    }
                }
            }
        }
    }
}
