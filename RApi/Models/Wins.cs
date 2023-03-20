using RestApiTicTacToe;
namespace RestApiTicTacToe.Models;

class Wins
{
    private List<List<int>> wins;
    public Wins()
    {
       
        wins = new List<List<int>>() {
                            new List<int>(){ 0, 1, 2 },
                            new List<int>(){ 3, 4, 5 },
                            new List<int>(){ 6, 7, 8 },
                            new List<int>(){ 0, 3, 6 },
                            new List<int>(){ 1, 4, 7 },
                            new List<int>(){ 2, 5, 8 },
                            new List<int>(){ 0, 4, 8 },
                            new List<int>(){ 2, 4, 6 }
                };
    }
    private List<int> ToIntMap(List<Cell> map, CellsTypes type)
    {
        List<int> IntMap = new List<int>();
        for (int i = 0; i < map.Count; i++)
            if (map[i].Type == type)
                IntMap.Add(i);
        return IntMap;
    }
    public CellsTypes IsWin(List<Cell> field)
    {
        List<int> intMapX = ToIntMap(field, CellsTypes.X);
        List<int> intMapO = ToIntMap(field, CellsTypes.O);

        foreach (List<int> obj in wins)
        {
            if (!obj.Except(intMapX).Any())
                return CellsTypes.X;
            else if(!obj.Except(intMapO).Any())
                return CellsTypes.O;
            else
                continue;
        }
        return CellsTypes.None;
    }
}
