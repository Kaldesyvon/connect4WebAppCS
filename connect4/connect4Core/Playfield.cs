using System.Runtime.InteropServices.ComTypes;

namespace connect4Core
{
    public class Playfield
    {

        private Stone stone;
        private readonly Tile[,] _tiles;
        public Playfield(int playfieldWidth, int playfieldHeight)
        {
            PlayfieldWidth = playfieldWidth;
            PlayfieldHeight = playfieldHeight;
            _tiles = new Tile[playfieldHeight, playfieldWidth];
        }

        public int PlayfieldWidth { get; }
        public int PlayfieldHeight { get; }
        public Tile GetTile(int row, int column)
        {
            return _tiles[row, column];
        }

        public bool AddStone(StoneColor stoneColor, int columnPosition)
        {
            stone = CreateStone(stoneColor, columnPosition);
            if (stone == null)
            {
                return false;
            }
            UseGravity();
            return true;
        }

        private Stone CreateStone(StoneColor stoneColor, int columnPosition)
        {
            return (_tiles[0, columnPosition] != null) ? null : new Stone(stoneColor, columnPosition);
        }

        private void UseGravity()
        {
            var columnPosition = stone.ColumnPosition;
            var rowPosition = 0;

            while (rowPosition != PlayfieldHeight - 1)
            {
                if (_tiles[rowPosition + 1, columnPosition] == null)
                {
                    rowPosition++;
                }
                else
                {
                    break;
                }
            }

            stone.RowPosition = rowPosition;
            _tiles[rowPosition, columnPosition] = stone;
        }

        public bool CheckForWin()
        {
            var stoneRowPosition = stone.RowPosition;
            var stoneColumnPosition = stone.ColumnPosition;
            var stoneColor = stone.StoneColor;

            var isGameWon = false;

            if (stoneColumnPosition >= PlayfieldWidth - 4)
            {
                if (_tiles[stoneRowPosition, stoneColumnPosition - 1] is Stone
                    && _tiles[stoneRowPosition, stoneColumnPosition - 2] is Stone
                    && _tiles[stoneRowPosition, stoneColumnPosition - 3] is Stone) {
                    isGameWon = _tiles[stoneRowPosition, stoneColumnPosition - 1].StoneColor == stoneColor
                            && _tiles[stoneRowPosition, stoneColumnPosition - 2].StoneColor == stoneColor
                            && _tiles[stoneRowPosition, stoneColumnPosition - 3].StoneColor == stoneColor;
                }
            }

            // check from left to right
            if (!isGameWon && stoneColumnPosition <= 3)
            {
                if (_tiles[stoneRowPosition, stoneColumnPosition + 1] is Stone
                    && _tiles[stoneRowPosition, stoneColumnPosition + 2] is Stone
                    && _tiles[stoneRowPosition, stoneColumnPosition + 3] is Stone) {
                    isGameWon = _tiles[stoneRowPosition, stoneColumnPosition + 1].StoneColor == stoneColor
                            && _tiles[stoneRowPosition, stoneColumnPosition + 2].StoneColor == stoneColor
                            && _tiles[stoneRowPosition, stoneColumnPosition + 3].StoneColor == stoneColor;
                }
            }

            // vertical check
            // check up is not necessarily
            // check down
            if (!isGameWon && stoneRowPosition <= 2)
            {
                if (_tiles[stoneRowPosition + 1, stoneColumnPosition] is Stone
                    && _tiles[stoneRowPosition + 2, stoneColumnPosition] is Stone
                    && _tiles[stoneRowPosition + 3, stoneColumnPosition] is Stone) {
                    isGameWon = _tiles[stoneRowPosition + 1, stoneColumnPosition].StoneColor == stoneColor
                            && _tiles[stoneRowPosition + 2, stoneColumnPosition].StoneColor == stoneColor
                            && _tiles[stoneRowPosition + 3, stoneColumnPosition].StoneColor == stoneColor;
                }
            }

            // check diagonally
            // check from bottom left to top right
            if (!isGameWon && stoneColumnPosition >= PlayfieldWidth - 4 && stoneRowPosition >= PlayfieldHeight - 4)
            {
                if (_tiles[stoneRowPosition - 1, stoneColumnPosition - 1] is Stone
                    && _tiles[stoneRowPosition - 2, stoneColumnPosition - 2] is Stone
                    && _tiles[stoneRowPosition - 3, stoneColumnPosition - 3] is Stone) {
                    isGameWon = _tiles[stoneRowPosition - 1, stoneColumnPosition - 1].StoneColor == stoneColor
                            && _tiles[stoneRowPosition - 2, stoneColumnPosition - 2].StoneColor == stoneColor
                            && _tiles[stoneRowPosition - 3, stoneColumnPosition - 3].StoneColor == stoneColor;
                }
            }

            // check from bottom left to top right
            if (!isGameWon && stoneColumnPosition <= 3 && stoneRowPosition >= PlayfieldHeight - 4)
            {
                if (_tiles[stoneRowPosition - 1, stoneColumnPosition + 1] is Stone
                    && _tiles[stoneRowPosition - 2, stoneColumnPosition + 2] is Stone
                    && _tiles[stoneRowPosition - 3, stoneColumnPosition + 3] is Stone) {
                    isGameWon = _tiles[stoneRowPosition - 1, stoneColumnPosition + 1].StoneColor == stoneColor
                            && _tiles[stoneRowPosition - 2, stoneColumnPosition + 2].StoneColor == stoneColor
                            && _tiles[stoneRowPosition - 3, stoneColumnPosition + 3].StoneColor == stoneColor;
                }
            }

            // check from top left to bottom right
            if (!isGameWon && stoneColumnPosition >= PlayfieldWidth - 4 && stoneRowPosition <= 2)
            {
                if (_tiles[stoneRowPosition + 1, stoneColumnPosition - 1] is Stone
                    && _tiles[stoneRowPosition + 2, stoneColumnPosition - 2] is Stone
                    && _tiles[stoneRowPosition + 3, stoneColumnPosition - 3] is Stone) {
                    isGameWon = _tiles[stoneRowPosition + 1, stoneColumnPosition - 1].StoneColor == stoneColor
                            && _tiles[stoneRowPosition + 2, stoneColumnPosition - 2].StoneColor == stoneColor
                            && _tiles[stoneRowPosition + 3, stoneColumnPosition - 3].StoneColor == stoneColor;
                }
            }

            // check from top right to bottom left
            if (!isGameWon && stoneColumnPosition <= 3 && stoneRowPosition <= 2)
            {
                if (_tiles[stoneRowPosition + 1, stoneColumnPosition + 1] is Stone
                    && _tiles[stoneRowPosition + 2, stoneColumnPosition + 2] is Stone
                    && _tiles[stoneRowPosition + 3, stoneColumnPosition + 3] is Stone) {
                    isGameWon = _tiles[stoneRowPosition + 1, stoneColumnPosition + 1].StoneColor == stoneColor
                            && _tiles[stoneRowPosition + 2, stoneColumnPosition + 2].StoneColor == stoneColor
                            && _tiles[stoneRowPosition + 3, stoneColumnPosition + 3].StoneColor == stoneColor;
                }
            }

            // none of win condition is satisfied so it is loss
            return isGameWon;
        }
    }
}