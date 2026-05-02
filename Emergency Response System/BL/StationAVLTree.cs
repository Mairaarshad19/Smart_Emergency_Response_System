using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
        public class StationAVLTree
        {
            private StationNode root;

            private int Height(StationNode n) => n?.Height ?? 0;
            private int BalanceFactor(StationNode n) => n == null ? 0 : Height(n.Left) - Height(n.Right);

            private StationNode RightRotate(StationNode y)
            {
                StationNode x = y.Left, T2 = x.Right;
                x.Right = y; y.Left = T2;
                y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
                x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
                return x;
            }

            private StationNode LeftRotate(StationNode x)
            {
                StationNode y = x.Right, T2 = y.Left;
                y.Left = x; x.Right = T2;
                x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
                y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
                return y;
            }

            private StationNode Balance(StationNode node, int key)
            {
                int bf = BalanceFactor(node);

                if (bf > 1 && key < node.Left.Data.station_id) return RightRotate(node);
                if (bf < -1 && key > node.Right.Data.station_id) return LeftRotate(node);
                if (bf > 1 && key > node.Left.Data.station_id) { node.Left = LeftRotate(node.Left); return RightRotate(node); }
                if (bf < -1 && key < node.Right.Data.station_id) { node.Right = RightRotate(node.Right); return LeftRotate(node); }

                return node;
            }

            public void Insert(StationBL s) { root = Insert(root, s); }

            private StationNode Insert(StationNode node, StationBL s)
            {
                if (node == null) return new StationNode(s);

                if (s.station_id < node.Data.station_id) node.Left = Insert(node.Left, s);
                else if (s.station_id > node.Data.station_id) node.Right = Insert(node.Right, s);
                else return node; // no duplicates

                node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
                return Balance(node, s.station_id);
            }

            public StationBL Search(int stationId)
            {
                StationNode cur = root;
                while (cur != null)
                {
                    if (stationId == cur.Data.station_id) return cur.Data;
                    cur = (stationId < cur.Data.station_id) ? cur.Left : cur.Right;
                }
                return null;
            }

            public void Delete(int stationId) { root = Delete(root, stationId); }

            private StationNode Delete(StationNode node, int stationId)
            {
                if (node == null) return null;

                if (stationId < node.Data.station_id) node.Left = Delete(node.Left, stationId);
                else if (stationId > node.Data.station_id) node.Right = Delete(node.Right, stationId);
                else
                {
                    if (node.Left == null || node.Right == null)
                        node = (node.Left != null) ? node.Left : node.Right;
                    else
                    {
                        StationNode succ = Min(node.Right);
                        node.Data = succ.Data;
                        node.Right = Delete(node.Right, succ.Data.station_id);
                    }
                }

                if (node == null) return null;
                node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
                return Balance(node, stationId);
            }

            private StationNode Min(StationNode node)
            {
                StationNode cur = node;
                while (cur.Left != null) cur = cur.Left;
                return cur;
            }

            // Traversal callback to avoid using built-in collections
            public void InOrder(Action<StationBL> visit) { InOrder(root, visit); }
            private void InOrder(StationNode node, Action<StationBL> visit)
            {
                if (node == null) return;
                InOrder(node.Left, visit);
                visit(node.Data);
                InOrder(node.Right, visit);
            }
        }
}


