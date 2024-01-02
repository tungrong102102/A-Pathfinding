using UnityEngine;

namespace Obvious.Soap
{
    [CreateAssetMenu(fileName = "scriptable_variable_GridMap.asset", menuName = "Soap/ScriptableVariables/GridMap")]
    public class GridMapVariable : ScriptableVariable<bool [,]>
    {
        public Vector2Int size;
        public override void Init()
        {
            _value = new bool[size.x,size.y];
            base.Init();
        }

        public void Set(int x, int y,bool to)
        {
            _value[x, y] = to;
        }
        public bool CheckPosition(int x, int y)
        {
            if(x < 0 || x >= size.x)
                return false;
            if (y < 0 || y >= size.y)
                return false;
            return true;
        }
        
        internal bool CheckWalkable(int xPos, int yPos)
        {
            return _value[xPos, yPos] == false;
        }
    }
}
