using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_ThreeTree
{

    public class TreeNode
    {
        public int Size { get; set; }
        int[] Keys = new int[3];
        TreeNode First, Second, Third, Fourth, Parent;
        public List<int> values;
        public TreeNode(int key, TreeNode first, TreeNode second, TreeNode third, TreeNode fourth, TreeNode parent)
        {
            Size = 1;
            Keys = new int[3] { key, 0, 0 };
            First = first;
            Second = second;
            Third = third;
            Fourth = fourth;
            Parent = parent;
            values = new List<int>();
        }

        public TreeNode(int key)
        {
            Size = 1;
            Keys = new int[3] { key, 0, 0 };
            First = null;
            Second = null;
            Third = null;
            Fourth = null;
            Parent = null;
            values = new List<int>();
        }

        public bool Find(int key)//поиск элемента
        {
            for (int i = 0; i<Size; ++i)
            if (Keys[i] == key) return true;
            return false;            
        }

        void Swap(ref int x, ref int y)//меняет местами
        {
            x += y;
            y = x - y;
            x -= y;
        }

        void SortKeys(ref int x, ref int y)//сортирует 2 элемента
        {
            if (x > y) Swap(ref x, ref y);
        }

        void SortKeys(ref int x, ref int y, ref int z)//сортирока 3-еч элементов
        {
            if (x > y) Swap(ref x, ref y);
            if (x > z) Swap(ref x, ref z);
            if (y > z) Swap(ref y, ref z);
        }

        void Sort()//сортировка
        {
            if (Size == 1) return;
            if (Size == 2) SortKeys(ref Keys[0], ref Keys[1]);
            else SortKeys(ref Keys[0], ref Keys[1], ref Keys[2]);
        }

        void InsertToNode(int key)
        {
            Keys[Size] = key;
            Size++;
        }

        void RemoveFromNode(int key)
        {
            if (Size >= 1 && Keys[0] == key)
            {
                Keys[0] = Keys[1];
                Keys[1] = Keys[2];
                Size--;
            }
            else if (Size == 2 && Keys[1] == key)
            {
                Keys[1] = Keys[2];
                Size--;
            }
        }

        void ChangeToDoubleNode(int key, TreeNode first, TreeNode second)
        {
            Keys[0] = key;
            First = first;
            Second = second;
            Third = null;
            Fourth = null;
            Parent = null;
            Size = 1;
        }

        bool IsLeaf()
        {
            return (First == null && Second == null && Third == null);
        }

        void DeleteIt(TreeNode item)
        {
            if (item.Parent.First == item) item.Parent.First = null;
            else if (item.Parent.Second == item) item.Parent.Second = null;
            else if (item.Parent.Third == item) item.Parent.Third = null;
        }

        public TreeNode Insert(TreeNode p, int k)
        {
            // вставка ключа k в дерево с корнем p; всегда возвращаем корень дерева, т.к. он может меняться
            p.values.Add(k);
            if (p == null) return new TreeNode(k);// если дерево пусто, то создаем первую 2-3-вершину (корень)

            if (p.IsLeaf()) p.InsertToNode(k);
            else if (k <= p.Keys[0]) Insert(p.First, k);
            else if (p.Size == 1 || (p.Size == 2 && k <= p.Keys[1])) Insert(p.Second, k);
            else Insert(p.Third, k);

            return Split(p);
        }

        TreeNode Split(TreeNode item)
        {
            if (item.Size < 3) return item;

            // Создаем две новые вершины,
            // которые имеют такого же родителя, как и разделяющийся элемент.
            var x = new TreeNode(item.Keys[0], item.First, item.Second, null, null, item.Parent);
            var y = new TreeNode(item.Keys[2], item.First, item.Second, null, null, item.Parent);
            if (x.First != null) x.First.Parent = x;// Правильно устанавливаем "родителя" "сыновей".
            if (x.Second != null) x.Second.Parent = x;// После разделения, "родителем" "сыновей" является "дедушка",
            if (y.First != null) y.First.Parent = y;// Поэтому нужно правильно установить указатели.
            if (y.Second != null) y.Second.Parent = y;
            if (item.Parent != null)
            {
                item.Parent.InsertToNode(item.Keys[1]);

                if (item.Parent.First == item) item.Parent.First = null;
                else if (item.Parent.Second == item) item.Parent.Second = null;
                else if (item.Parent.Third == item) item.Parent.Third = null;

                // Дальше происходит своеобразная сортировка ключей при разделении.
                if (item.Parent.First == null)
                {
                    item.Parent.Fourth = item.Parent.Third;
                    item.Parent.Third = item.Parent.Second;
                    item.Parent.Second = y;
                    item.Parent.First = x;
                }
                else if (item.Parent.Second == null)
                {
                    item.Parent.Fourth = item.Parent.Third;
                    item.Parent.Third = y;
                    item.Parent.Second = x;
                }
                else
                {
                    item.Parent.Fourth = y;
                    item.Parent.Third = x;
                }

                var tmp = item.Parent;
                DeleteIt(item);
                return tmp;
            }
            else
            {
                x.Parent = item; // Так как в эту ветку попадает только корень,
                y.Parent = item; // то мы "родителем" новых вершин делаем разделяющийся элемент.

                item.ChangeToDoubleNode(item.Keys[1], x, y);
                return item;
            }
        }

        public TreeNode Search(TreeNode p, int k)
        { // Поиск ключа k в 2-3 дереве с корнем p.
            if (p == null) return null;

            if (p.Find(k)) return p;
            if (k < p.Keys[0]) return Search(p.First, k);
            else if ((p.Size == 2) && (k < p.Keys[1]) || (p.Size == 1)) return Search(p.Second, k);
            else if (p.Size == 2) return Search(p.Third, k);
            return null;
        }

        public TreeNode SearchMin(TreeNode p)
        { // Поиск узла с минимальным элементов в 2-3-дереве с корнем p.
            if (p == null) return p;
            if (p.First == null) return p;
            else return SearchMin(p.First);
        }

        public TreeNode Remove(TreeNode p, int k)
        { // Удаление ключа k в 2-3-дереве с корнем p.
          //Search(p, k) Ищем узел, где находится ключ k
            values.Remove(k);
            var item = Search(p, k);
            if (item == null) return p;

            TreeNode min = null;
            if (item.Keys[0] == k) min = SearchMin(item.Second); // Ищем эквивалентный ключ
            else min = SearchMin(Search(p, k).Third);

            if (min != null)
            { // Меняем ключи местами
                int z = (k == item.Keys[0] ? item.Keys[0] : item.Keys[1]);
                item.Swap(ref z, ref min.Keys[0]);
                item = min; // Перемещаем указатель на лист, т.к. min - всегда лист
            }
            item.RemoveFromNode(k); // И удаляем требуемый ключ из листа
            return Fix(item); // Вызываем функцию для восстановления свойств дерева.
        }

        TreeNode Fix(TreeNode leaf)
        {
            if (leaf.Size == 0 && leaf.Parent == null)
            { // Случай 0, когда удаляем единственный ключ в дереве
                DeleteIt(leaf);
                return null;
            }
            if (leaf.Size != 0)
            { // Случай 1, когда вершина, в которой удалили ключ, имела два ключа
                if (leaf.Parent != null) return Fix(leaf.Parent);
                else return leaf;
            }

            TreeNode parent = leaf.Parent;
            if (parent.First.Size == 2 || parent.Second.Size == 2 || parent.Size == 2) leaf = Redistribute(leaf); // Случай 2, когда достаточно перераспределить ключи в дереве
            else if (parent.Size == 2 && parent.Third.Size == 2) leaf = Redistribute(leaf); // Аналогично
            else leaf = Merge(leaf); // Случай 3, когда нужно произвести склеивание и пройтись вверх по дереву как минимум на еще одну вершину

            return Fix(leaf);
        }

        TreeNode Redistribute(TreeNode leaf)
        {
            TreeNode parent = leaf.Parent;
            TreeNode first = parent.First;
            TreeNode second = parent.Second;
            TreeNode third = parent.Third;

            if ((parent.Size == 2) && (first.Size < 2) && (second.Size < 2) && (third.Size < 2))
            {
                if (first == leaf)
                {
                    parent.First = parent.Second;
                    parent.Second = parent.Third;
                    parent.Third = null;
                    parent.First.InsertToNode(parent.Keys[0]);
                    parent.First.Third = parent.First.Second;
                    parent.First.Second = parent.First.First;

                    if (leaf.First != null) parent.First.First = leaf.First;
                    else if (leaf.Second != null) parent.First.First = leaf.Second;
                    if (parent.First.First != null) parent.First.First.Parent = parent.First;
                    parent.RemoveFromNode(parent.Keys[0]);
                    DeleteIt(First);
                }
                else if (second == leaf)
                {
                    first.InsertToNode(parent.Keys[0]);
                    parent.RemoveFromNode(parent.Keys[0]);
                    if (leaf.First != null) first.Third = leaf.First;
                    else if (leaf.Second != null) first.Third = leaf.Second;

                    if (first.Third != null) first.Third.Parent = first;

                    parent.Second = parent.Third;
                    parent.Third = null;
                    DeleteIt(Second);
                }
                else if (third == leaf)
                {
                    second.InsertToNode(parent.Keys[1]);
                    parent.Third = null;
                    parent.RemoveFromNode(parent.Keys[1]);
                    if (leaf.First != null) second.Third = leaf.First;
                    else if (leaf.Second != null) second.Third = leaf.Second;

                    if (second.Third != null) second.Third.Parent = second;
                    DeleteIt(Third);
                }
            }
            else if ((parent.Size == 2) && ((first.Size == 2) || (second.Size == 2) || (third.Size == 2)))
            {
                if (third == leaf)
                {
                    if (leaf.First != null)
                    {
                        leaf.Second = leaf.First;
                        leaf.First = null;
                    }

                    leaf.InsertToNode(parent.Keys[1]);
                    if (second.Size == 2)
                    {
                        parent.Keys[1] = second.Keys[1];
                        second.RemoveFromNode(second.Keys[1]);
                        leaf.First = second.Third;
                        second.Third = null;
                        if (leaf.First != null) leaf.First.Parent = leaf;
                    }
                    else if (first.Size == 2)
                    {
                        parent.Keys[1] = second.Keys[0];
                        leaf.First = second.Second;
                        second.Second = second.First;
                        if (leaf.First != null) leaf.First.Parent = leaf;

                        second.Keys[0] = parent.Keys[0];
                        parent.Keys[0] = first.Keys[1];
                        first.RemoveFromNode(first.Keys[1]);
                        second.First = first.Third;
                        if (second.First != null) second.First.Parent = second;
                        first.Third = null;
                    }
                }
                else if (second == leaf)
                {
                    if (third.Size == 2)
                    {
                        if (leaf.First == null)
                        {
                            leaf.First = leaf.Second;
                            leaf.Second = null;
                        }
                        second.InsertToNode(parent.Keys[1]);
                        parent.Keys[1] = third.Keys[0];
                        third.RemoveFromNode(third.Keys[0]);
                        second.Second = third.First;
                        if (second.Second != null) second.Second.Parent = second;
                        third.First = third.Second;
                        third.Second = third.Third;
                        third.Third = null;
                    }
                    else if (first.Size == 2)
                    {
                        if (leaf.Second == null)
                        {
                            leaf.Second = leaf.First;
                            leaf.First = null;
                        }
                        second.InsertToNode(parent.Keys[0]);
                        parent.Keys[0] = first.Keys[1];
                        first.RemoveFromNode(first.Keys[1]);
                        second.First = first.Third;
                        if (second.First != null) second.First.Parent = second;
                        first.Third = null;
                    }
                }
                else if (first == leaf)
                {
                    if (leaf.First == null)
                    {
                        leaf.First = leaf.Second;
                        leaf.Second = null;
                    }
                    first.InsertToNode(parent.Keys[0]);
                    if (second.Size == 2)
                    {
                        parent.Keys[0] = second.Keys[0];
                        second.RemoveFromNode(second.Keys[0]);
                        first.Second = second.First;
                        if (first.Second != null) first.Second.Parent = first;
                        second.First = second.Second;
                        second.Second = second.Third;
                        second.Third = null;
                    }
                    else if (third.Size == 2)
                    {
                        parent.Keys[0] = second.Keys[0];
                        second.Keys[0] = parent.Keys[1];
                        parent.Keys[1] = third.Keys[0];
                        third.RemoveFromNode(third.Keys[0]);
                        first.Second = second.First;
                        if (first.Second != null) first.Second.Parent = first;
                        second.First = second.Second;
                        second.Second = third.First;
                        if (second.Second != null) second.Second.Parent = second;
                        third.First = third.Second;
                        third.Second = third.Third;
                        third.Third = null;
                    }
                }
            }
            else if (parent.Size == 1)
            {
                leaf.InsertToNode(parent.Keys[0]);

                if (first == leaf && second.Size == 2)
                {
                    parent.Keys[0] = second.Keys[0];
                    second.RemoveFromNode(second.Keys[0]);

                    if (leaf.First == null) leaf.First = leaf.Second;

                    leaf.Second = second.First;
                    second.First = second.Second;
                    second.Second = second.Third;
                    second.Third = null;
                    if (leaf.Second != null) leaf.Second.Parent = leaf;
                }
                else if (second == leaf && first.Size == 2)
                {
                    parent.Keys[0] = first.Keys[1];
                    first.RemoveFromNode(first.Keys[1]);

                    if (leaf.Second == null) leaf.Second = leaf.First;

                    leaf.First = first.Third;
                    first.Third = null;
                    if (leaf.First != null) leaf.First.Parent = leaf;
                }
            }
            return parent;
        }

        TreeNode Merge(TreeNode leaf)
        {
            var parent = leaf.Parent;

            if (parent.First == leaf)
            {
                parent.Second.InsertToNode(parent.Keys[0]);
                parent.Second.Third = parent.Second.Second;
                parent.Second.Second = parent.Second.First;

                if (leaf.First != null) parent.Second.First = leaf.First;
                else if (leaf.Second != null) parent.Second.First = leaf.Second;

                if (parent.Second.First != null) parent.Second.First.Parent = parent.Second;

                parent.RemoveFromNode(parent.Keys[0]);
                DeleteIt(parent.First);
                parent.First = null;
            }
            else if (parent.Second == leaf)
            {
                parent.First.InsertToNode(parent.Keys[0]);

                if (leaf.First != null) parent.First.Third = leaf.First;
                else if (leaf.Second != null) parent.First.Third = leaf.Second;

                if (parent.First.Third != null) parent.First.Third.Parent = parent.First;

                parent.RemoveFromNode(parent.Keys[0]);
                DeleteIt(parent.Second);
                parent.Second = null;
            }

            if (parent.Parent == null)
            {
                TreeNode tmp = null;
                if (parent.First != null) tmp = parent.First;
                else tmp = parent.Second;
                tmp.Parent = null;
                DeleteIt(parent);
                return tmp;
            }
            return parent;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 30, 70, 15, 50, 5, 60, 85, 10, 20, 35, 40, 55, 65, 80, 90 };
            var tree = new TreeNode(5);
            foreach (var e in arr)
            {
                tree.Insert(tree, e);
            }
            
        }
    }
}