using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgandStruct
{
    using System;
    using System.Collections.Generic;
    public class TreeNode
    {
        public int Value { get; set; }
        public List<TreeNode> Children { get; }
        public TreeNode(int value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }
        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }
        public TreeNode AddChild(int value)
        {
            var child = new TreeNode(value);
            Children.Add(child);
            return child;
        }
        public bool IsLeaf => Children.Count == 0;
        public void ModifyTree()
        {
            if (IsLeaf)
            {
                Value += 1;
            }
            else
            {
                Value -= 1;
                foreach (var child in Children)
                {
                    child.ModifyTree();
                }
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            BuildTreeString(sb, "", true);
            return sb.ToString();
        }

        private void BuildTreeString(StringBuilder sb, string prefix, bool isTail)
        {
            sb.Append(prefix)
              .Append(isTail ? "└── " : "├── ")
              .AppendLine($"{Value} ");

            for (int i = 0; i < Children.Count; i++)
            {
                bool lastChild = i == Children.Count - 1;
                Children[i].BuildTreeString(sb, prefix + (isTail ? "    " : "│   "), lastChild);
            }
        }
    }
}
