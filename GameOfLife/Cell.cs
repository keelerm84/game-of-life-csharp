namespace GameOfLife
{
  class Cell
  {
    public bool isAlive { set; get; }
    private int numAliveNeighbors;

    public Cell(bool isAlive)
    {
      this.isAlive = isAlive;
    }

    public void numberOfAliveNeighbors(int numAlive)
    {
      numAliveNeighbors = numAlive;
    }

    public void evolve()
    {
      if ( ! isAlive && 3 == numAliveNeighbors )
      {
        // Any dead cell with exactly three live neighbours becomes a
        // live cell, as if by reproduction.
        isAlive = true;
      } else if ( isAlive && 2 > numAliveNeighbors )
      {
        // Any live cell with fewer than two live neighbours dies, as
        // if caused by under-population.
        isAlive = false;
      } else if ( isAlive && 3 < numAliveNeighbors ) 
      {
        // Any live cell with more than three live neighbours dies, as
        // if by overcrowding.
        isAlive = false;
      }
      // Check for live cell with 2 or 3 neighbors isn't necessary.
      // It is already alive, so we just let it be
    }
  }
}