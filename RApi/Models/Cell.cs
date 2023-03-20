namespace RestApiTicTacToe.Models
{
    public class Cell
    {
        public int CellId { get; set; }
        public CellsTypes Type { get; set; }
        public Cell(int CellId, CellsTypes Type) {
            this.CellId = CellId;
            this.Type = Type;
        }
        
    }
}
