using System.Collections.Generic;
using System;

namespace GameOfLife
{
  class Board
  {
    private int width;
    private int height;
    private List<List<Cell>> cells;

    public Board(int width, int height)
    {
      this.width = width;
      this.height = height;
      cells = new List<List<Cell>>();
      
      initialize();
    }

    public void evolve()
    {
      for(int row = 0; row < cells.Count; row++)
        for(int column = 0; column < cells[row].Count; column++)
          cells[row][column].numberOfAliveNeighbors(getLiveNeighbors(row, column));

      foreach( var row in cells )
        foreach(var cell in row)
          cell.evolve();
    }

    public void print()
    {
      foreach(var row in cells)
      {
        foreach(var cell in row)
        {
          System.Console.Write(cell.isAlive ? "." : " ");
        }
        System.Console.WriteLine("");
      }
    }

    protected void initialize()
    {
      Random random = new Random();

      for(int row = 0; row < height; ++row)
        {
          cells.Add (new List<Cell>());
          for(int column = 0; column < width; ++column)
            {
              cells[row].Add (new Cell(random.Next(0, 100) < 50));
            }
        }
    }

    protected int getLiveNeighbors(int row, int column)
    {
      // Consider board to be wrapped on a torus
      int above = ( row - 1 ) < 0 ? height - 1 : row - 1;
      int below = ( row + 1 ) == height ? 0 : row + 1;
      int left = ( column - 1 ) < 0 ? width - 1 : column - 1;
      int right = ( column + 1 ) == width ? 0 : column + 1;

      int alive = 0;

      alive += cells[above][left].isAlive ? 1 : 0;
      alive += cells[above][column].isAlive ? 1 : 0;
      alive += cells[above][right].isAlive ? 1 : 0;

      alive += cells[below][left].isAlive ? 1 : 0;
      alive += cells[below][column].isAlive ? 1 : 0;
      alive += cells[below][right].isAlive ? 1 : 0;

      alive += cells[row][left].isAlive ? 1 : 0;
      alive += cells[row][right].isAlive ? 1 : 0;

      return alive;
    }
  }
}