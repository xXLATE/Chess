using System;


namespace WPFLibrary
{
    public static class PieceMaker
    {
        public static Piece Make(string pieceCode, int x, int y)
        {
            Piece piece = null;

            switch (pieceCode)
            {
                case "K":
                    piece = new King(x, y);
                    break;

                case "Q":
                    piece = new Queen(x, y);
                    break;

                case "B":
                    piece = new Bishop(x, y);
                    break;

                case "N":
                    piece = new Knight(x, y);
                    break;

                case "R":
                    piece = new Rook(x, y);
                    break;

                case "P":
                    piece = new Pawn(x, y);
                    break;
            }
            return piece;
        }
    }


    public abstract class Piece
    {
        protected int x;
        protected int y;

        public Piece(int newX, int newY)
        {
            x = newX;
            y = newY;
        }
        public abstract bool Move(int newX, int newY);

        public bool PreMove(int newX, int newY)
        {
            if (Move(newX, newY))
            {
                x = newX;
                y = newY;
                return true;
            }
            return false;
        }
    }

    class King : Piece
    {
        public King(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            return (Math.Abs(x - newX) <= 1 && Math.Abs(y - newY) <= 1);
        }
    }

    class Queen : Piece
    {
        public Queen(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            return (x == newX || y == newY || Math.Abs(x - newX) == Math.Abs(y - newY));
        }
    }

    class Bishop : Piece
    {
        public Bishop(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            return (Math.Abs(x - newX) == Math.Abs(y - newY));
        }
    }

    class Knight : Piece
    {
        public Knight(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            return ((Math.Abs(x - newX) == 2 && Math.Abs(y - newY) == 1) ||
                    (Math.Abs(x - newX) == 1 && Math.Abs(y - newY) == 2));
        }
    }

    class Rook : Piece
    {
        public Rook(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            return (x == newX || y == newY);
        }
    }

    class Pawn : Piece
    {
        public Pawn(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            return ((x == newX && y == 7 && newY == 5 ) ||
                    (x == newX && y == 2 && newY == 4) ||
                    (x == newX && (y - 1 == newY || y + 1 == newY)));
        }
    }
}