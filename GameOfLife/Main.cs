using System;

namespace GameOfLife
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Board board = new Board(int.Parse(args[0]), int.Parse(args[1]));

      for( int i = 0; i < int.Parse(args[2]); i++ )
      {
        board.print();
        board.evolve();
        System.Threading.Thread.Sleep(int.Parse(args[3]));
        Console.Clear();
      }
    }
  }
}
