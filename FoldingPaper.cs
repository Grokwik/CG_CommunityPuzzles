using System;

namespace FoldingPaper
{
    class Solution
    {
        static int[] _visibleLayers;
        const int _Up = 0;
        const int _Right = 1;
        const int _Down = 2;
        const int _Left = 3;

        static int Dir(string D)
        {
            return Dir(D[0]);
        }

        static int Dir(char D)
        {
            switch (D)
            {
                case 'U': return _Up;
                case 'R': return _Right;
                case 'D': return _Down;
                case 'L': return _Left;
            }
            return -1;
        }

        static char Dir(int D)
        {
            switch (D)
            {
                case _Up: return 'U';
                case _Right: return 'R';
                case _Down: return 'D';
                case _Left: return 'L';
            }
            return ' ';
        }

        static void Update(int foldDirection)
        {
            _visibleLayers[(foldDirection + 2) % 4] += _visibleLayers[foldDirection];
            _visibleLayers[(foldDirection + 1) % 4] *= 2;
            _visibleLayers[(foldDirection + 3) % 4] *= 2;
            _visibleLayers[foldDirection] = 1;
        }

        static int LayerCount(string order, string side)
        {
            #region init
            _visibleLayers = new int[4];
            _visibleLayers[_Up] = 1;
            _visibleLayers[_Right] = 1;
            _visibleLayers[_Down] = 1;
            _visibleLayers[_Left] = 1;
            #endregion

            foreach (var d in order)
                Update(Dir(d));

            return _visibleLayers[Dir(side)];
        }
    }
}