namespace RestApiTicTacToe.Models
{
    public class GameField
    {
        public List<Cell> Cells { get; set; }
        public int GameId { get; set; }
        public CellsTypes Winner { get; set; }
        public GameField(int GameId)
        {
            Cells = new List<Cell>();

            for(int i = 1; i <= 9; i++)
            {
                Cells.Add(new Cell(i, CellsTypes.None));
            }

            this.GameId = GameId;
        }

        public List<Cell> Update(int Index, CellsTypes Type)
        {
            if (Type != CellsTypes.None)
            {
                if (Cells[Index].Type == CellsTypes.None)
                    Cells[Index].Type = Type;
            }
            return Cells;
        }
    }
}
