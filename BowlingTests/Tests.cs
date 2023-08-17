using System.Runtime.CompilerServices;

namespace BowlingTests {
    [TestClass]
    public class Tests {
        [TestMethod]
        public void FrameScoreCalculationOpenFramesTest() {
            Game testGame = new Game();
            testGame.AddPlayer("TestPlayer");
            Player testPlayer = testGame.Players.First();

            //Test Open Frames
            foreach (var frame in testPlayer.Round) {
                    frame.Throw1 = 2;
                    frame.Throw2 = 3;
            }
            testPlayer.CalculateFramesScore();
            foreach (var frame in testPlayer.Round) {
                Assert.AreEqual(5, frame.Score);
            }
        }
        [TestMethod]
        public void FrameScoreCalculationSpareFramesTest() {
            Game testGame = new Game();
            testGame.AddPlayer("TestPlayer");
            Player testPlayer = testGame.Players.First();

            //Test Open Frames
            foreach (var frame in testPlayer.Round) {
                frame.Throw1 = 5;
                frame.Throw2 = 5;
                frame.isSpare = true;
                if (frame.FrameNumber == 10) {
                    frame.Throw3 = 5;
                }
            }
            testPlayer.CalculateFramesScore();
            foreach (var frame in testPlayer.Round) {
                Assert.AreEqual(15, frame.Score);
            }
        }
        [TestMethod]
        public void FrameScoreCalculationStrikeFramesTest() {
            Game testGame = new Game();
            testGame.AddPlayer("TestPlayer");
            Player testPlayer = testGame.Players.First();

            //Test Open Frames
            foreach (var frame in testPlayer.Round) {
                frame.Throw1 = 10;
                frame.isStrike = true;

                if (frame.FrameNumber == 10) {
                    frame.Throw2 = 10;
                    frame.Throw3 = 10;
                }
            }
            testPlayer.CalculateFramesScore();
            foreach (var frame in testPlayer.Round) {
                Assert.AreEqual(30, frame.Score);
            }
        }
        [TestMethod]
        public void FinalScoreOpenFramesTest() {
            Game testGame = new Game();
            testGame.AddPlayer("TestPlayer");
            Player testPlayer = testGame.Players.First();

            //Test Open Frames
            foreach (var frame in testPlayer.Round) {
                frame.Throw1 = 2;
                frame.Throw2 = 3;
            }
            testPlayer.CalculateFinalScore();
            
            Assert.AreEqual(50, testPlayer.FinalScore);
        }
        [TestMethod]
        public void FinalScoreSpareFramesTest() {
            Game testGame = new Game();
            testGame.AddPlayer("TestPlayer");
            Player testPlayer = testGame.Players.First();

            //Test Open Frames
            foreach (var frame in testPlayer.Round) {
                frame.Throw1 = 5;
                frame.Throw2 = 5;
                frame.isSpare = true;
                if (frame.FrameNumber == 10) {
                    frame.Throw3 = 5;
                }
            }
            testPlayer.CalculateFinalScore();

            Assert.AreEqual(150, testPlayer.FinalScore);
        }
        [TestMethod]
        public void FinalScoreStrikesFramesTest() {
            Game testGame = new Game();
            testGame.AddPlayer("TestPlayer");
            Player testPlayer = testGame.Players.First();

            //Test Open Frames
            foreach (var frame in testPlayer.Round) {
                frame.Throw1 = 10;
                frame.isStrike = true;

                if (frame.FrameNumber == 10) {
                    frame.Throw2 = 10;
                    frame.Throw3 = 10;
                }
            }
            testPlayer.CalculateFinalScore();
            Assert.AreEqual(300,testPlayer.FinalScore);
        }
    }
}