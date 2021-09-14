namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private Pawn[,] pieces;

        public ChessBoard()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
        }

        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            if (IsValidRow(pieceColor, xCoordinate) && IsLegalBoardPosition(xCoordinate, yCoordinate)
                && pieces.GetValue(xCoordinate, yCoordinate) == null)
            {
                SetCoordinates(pawn, xCoordinate, yCoordinate);
                pieces[xCoordinate, yCoordinate] = pawn;
            }
            else
            {
                SetCoordinates(pawn, -1, -1);
            }

        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            if (IsValidCoordinate(xCoordinate))
            {
                return IsValidCoordinate(yCoordinate);
            }
            return false;
        }

        private bool IsValidRow(PieceColor pieceColor, int xCoordinate)
        {
            if (pieceColor == PieceColor.Black && xCoordinate == 6)
                return true;
            return false;
        }

        private void SetCoordinates(Pawn pawn, int xCoordinate, int yCoordinate)
        {
            pawn.XCoordinate = xCoordinate;
            pawn.YCoordinate = yCoordinate;
        }

        private bool IsValidCoordinate(int coordinate)
        {
            if (coordinate < 0 || coordinate > 7)
                return false;
            return true;
        }
    }
}
