using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Расположения узла относительно родителя
    /// </summary>
    public enum Side
    {
        Left,
        Right
    }

    // класс, представляющий обход дерева
    public class BinaryTreeNode
    {

        public BinaryTreeNode(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
        // левый узел дерева
        public BinaryTreeNode LeftNode { get; set; }
        // правый узел дерева
        public BinaryTreeNode RightNode { get; set; }
        // корень дерева
        public BinaryTreeNode ParentNode { get; set; }

        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;
        public override string ToString() => Data.ToString();


    }
    public class BinaryTree
    {

        public BinaryTreeNode RootNode { get; set; }
        public BinaryTreeNode Add(BinaryTreeNode node, BinaryTreeNode currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0 ? currentNode : result < 0 ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }

        // функция добавления значения в дерево
        public BinaryTreeNode Add(string data)
        {
            return Add(new BinaryTreeNode(data));
        }

        public BinaryTreeNode FindNode(string data, BinaryTreeNode startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = data.CompareTo(startWithNode.Data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }
    }
}