using Pente_WPFApp;

namespace PenteTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PlacePiece()
        {
            BoardLogic boardLogic = new BoardLogic();

            boardLogic.placeBlack(0,0);
            
            Assert.AreEqual(1, boardLogic.gameBoard.GetBoard()[0,0]);
            Assert.AreNotEqual(1, boardLogic.gameBoard.GetBoard()[1,1]);
        }

        [TestMethod]
        public void PieceCaptureWhite()
        {
            BoardLogic boardLogic = new BoardLogic();

            int[,] board = boardLogic.gameBoard.GetBoard();

            board[0, 0] = 2;
            board[0, 1] = 1;
            board[0, 2] = 1;

            boardLogic.gameBoard.SetBoard(board);
            
            boardLogic.placeWhite(0,3);

            Assert.AreEqual(1, boardLogic.whiteCaptures);
        }

        [TestMethod]
        public void FiveInARowWhite()
        {
            BoardLogic boardLogic = new BoardLogic();

            int[,] board = boardLogic.gameBoard.GetBoard();

            board[0, 1] = 2;
            board[0, 2] = 2;
            board[0, 3] = 2;
            board[0, 4] = 2;
            board[0, 5] = 2;

            boardLogic.gameBoard.SetBoard(board);

            Assert.IsTrue(boardLogic.checkWinWhite(boardLogic.gameBoard.GetBoard(), 0, 5));
        }

        [TestMethod]
        public void FiveInARowBlack()
        {
            BoardLogic boardLogic = new BoardLogic();

            int[,] board = boardLogic.gameBoard.GetBoard();

            board[0, 1] = 1;
            board[0, 2] = 1;
            board[0, 3] = 1;
            board[0, 4] = 1;
            board[0, 5] = 1;

            boardLogic.gameBoard.SetBoard(board);

            Assert.IsTrue(boardLogic.checkWinBlack(boardLogic.gameBoard.GetBoard(), 0, 5));
        }

        [TestMethod]
        public void captureWinWhite()
        {
            BoardLogic boardLogic = new BoardLogic();

            int[,] board = boardLogic.gameBoard.GetBoard();

            board[0, 0] = 2;
            board[0, 1] = 1;
            board[0, 2] = 1;

            boardLogic.gameBoard.SetBoard(board);

            boardLogic.whiteCaptures = 4;

            boardLogic.placeWhite(0,3);

            boardLogic.checkWinWhite(board, 0, 3);

            Assert.AreEqual(1, boardLogic.winner);
        }
    }
}