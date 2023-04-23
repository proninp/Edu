namespace Lesson04
{
    public class BinaryTree
    {
        private TreeNode root;
        public void Insert(int data)
        {
            if (root == null)
                root = new TreeNode(data);
            else
                root.Insert(data);
        }
        public TreeNode Find(int data)
        {
            if (root == null)
                return null;
            return root.Find(data);
        }
        public TreeNode FindRecursive(int data)
        {
            if (root == null)
                return null;
            return root.FindRecursive(data);
        }
        public void Remove(int data)
        {
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false; // Keeps track of wich child of parent should be removed
            if (current == null)
                return;
            while (current != null && current.Data != data)
            {
                parent = current;
                if (data < current.Data)
                {
                    current = current.Left;
                    isLeftChild = true;
                }
                else
                {
                    current = current.Right;
                    isLeftChild = false;
                }
            }
            if (current == null) // Nothing to return
                return;
            if (current.Left == null && current.Right == null) // Leaf node
            {
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }   
            }
            else if (current.Right == null) // current only has left child, so we set the parents node child to be this left child
            {
                if (current == root)
                    root = current.Left;
                else
                {
                    if (isLeftChild)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;
                }
            }
            else if (current.Left == null)
            {
                if (current == root)
                    root = current.Right;
                else
                {
                    if (isLeftChild)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
            }
            else // Current Node has both a left and a right child
            {
                TreeNode successor = GetSuccessor(current);
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                    parent.Left = successor;
                else
                    parent.Right = successor;
            }
        }
        // Mark Node as deleted
        public void SoftDelete(int data)
        {
            TreeNode toDelete = Find(data);
            if (toDelete != null)
                toDelete.Delete();
        }
        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }
        public void PreorderTraversal()
        {
            if (root != null)
                root.PreorderTraversal();
        }
        public void PostorderTraversal()
        {
            if (root != null)
                root.PostorderTraversal();
        }
        public Nullable<int> Smallest()
        {
            if (root == null)
                return null;
            return root.SmallestValue();
        }
        public Nullable<int> Largest()
        {
            if (root == null)
                return null;
            return root.LargestValue();
        }
        public int NumberOfLeafNodes()
        {
            if (root == null)
                return 0;
            return root.NumberOfLeafNodes();
        }
        public int Height()
        {
            if (root == null)
                return 0;
            return root.Height();
        }
        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.Right;
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.Left;
            }
            if (successor != node.Right)
            {
                parentOfSuccessor.Left = successor.Right;
                successor.Right = node.Right;
            }
            successor.Left = node.Left;
            return successor;
        }
    }
}
