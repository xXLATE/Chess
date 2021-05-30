using System;

class Program
{
    static void Main()
    {
        Figure[] board = new Figure[8];

        board[0] = new Knight(1, 1);
        board[1] = new Queen(1, 1);
        board[2] = new Bishop(4, 4);
        board[3] = new Queen(1, 1);
        board[4] = new King(4, 4);
        board[5] = new Knight(1, 1);
        board[6] = new Rook(4, 4);
        board[7] = new Pawn(2, 2);

        foreach (var Figure in board)
        {
            if (Figure.isRightMove(1, 4) == true)
            {
                Figure.Move(1, 4);
                Console.WriteLine("YES");
            }
            else
                Console.WriteLine("NO");
        }
    }
}

class Figure
{
    public int x;
    public int y;

    public Figure(int inpt1, int inpt2)
    {
        x = inpt1;
        y = inpt2;
    }

    public virtual bool isRightMove(int newX, int newY)
    {
        return false;
    }

    public void Move(int newX, int newY)
    {
        if (isRightMove(newX, newY))
        {
            x = newX;
            y = newY;
        }
    }
}

class King : Figure
{
    public King(int x, int y) : base(x, y)
    {
    }

    public override bool isRightMove(int newX, int newY)
    {
        return (Math.Abs(x - newX) <= 1 && Math.Abs(y - newY) <= 1);
    }
}

class Queen : Figure
{
    public Queen(int x, int y) : base(x, y)
    {
    }

    public override bool isRightMove(int newX, int newY)
    {
        return (x == newX || y == newY || Math.Abs(x - newX) == Math.Abs(y - newY));
    }
}

class Bishop : Figure
{
    public Bishop(int x, int y) : base(x, y)
    {
    }

    public override bool isRightMove(int newX, int newY)
    {
        return (Math.Abs(x - newX) == Math.Abs(y - newY));
    }
}

class Knight : Figure
{
    public Knight(int x, int y) : base(x, y)
    {
    }

    public override bool isRightMove(int newX, int newY)
    {
        return ((Math.Abs(x - newX) == 2 && Math.Abs(y - newY) == 1) ||
                (Math.Abs(x - newX) == 1 && Math.Abs(y - newY) == 2));
    }
}

class Rook : Figure
{
    public Rook(int x, int y) : base(x, y)
    {
    }

    public override bool isRightMove(int newX, int newY)
    {
        return (x == newX || y == newY);
    }
}

class Pawn : Figure
{
    public Pawn(int x, int y) : base(x, y)
    {
    }

    public override bool isRightMove(int newX, int newY)
    {
        return ((x == newX && y == 2 && y + 2 >= newY) ||
                (x == newX && y + 1 == newY));
    }
}