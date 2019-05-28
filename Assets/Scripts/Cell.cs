using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GridSystem
{

    public class Cell : MonoBehaviour
    {
        public bool Free;
        internal int x;
        internal int y;
        internal Vector3 worldPosition;

        public Cell()
        {

        }
        
        public Cell(int _x, int _y, Vector3 _worldPosition, bool _free)
        {
            Free = _free;
            x = _x;
            y = _y;
            worldPosition = _worldPosition;
        }
        public bool CellFree()
        {

            return Free;
        }
    }
}
    

