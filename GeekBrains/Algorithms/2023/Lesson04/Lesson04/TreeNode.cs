namespace Lesson04
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Data { get; set; }
        public bool IsDeleted { get; set; }
        public TreeNode(int value)
        {
            this.Data = value;
        }
        public void Insert(int value)
        {
            if (value >= Data)
            {
                if (Right == null)
                    Right = new TreeNode(value);
                else
                    Right.Insert(value);
            }
            else
            {
                if (Left == null)
                    Left = new TreeNode(value);
                else
                    Left.Insert(value);
            }
        }
        public void Delete() { IsDeleted = true; }
        public override bool Equals(object? obj)
        {
            TreeNode node = obj as TreeNode;
            if (node == null)
                return false;
            return node.Data == this.Data;
        }
        public TreeNode Find(int value)
        {
            TreeNode current = this;
            while (current != null)
            {
                if (value == current.Data && !current.IsDeleted) // soft delete check
                    return current;
                else if (value > current.Data)
                    current = current.Right;
                else
                    current = current.Left;
            }
            return null;
        }
        public TreeNode FindRecursive(int value)
        {
            if (value == Data && !IsDeleted) // soft delete check
                return this;
            else if (value > Data && Right != null)
                return Right.FindRecursive(value);
            else if (Left != null)
                return Left.FindRecursive(value);
            else
                return null;
        }
        public void InOrderTraversal()
        {
            // First go to the left child abd if its children will be null so we print its data
            if (Left != null)
                Left.InOrderTraversal();
            Console.Write(this.Data + " ");
            // Then we go to the right node wich will print itself as both its children are null
            if (Right != null)
                Right.InOrderTraversal();
        }
        public void PreorderTraversal()
        {
            Console.Write(this.Data + " ");
            if (Left != null)
                Left.InOrderTraversal();
            if (Right != null)
                Right.InOrderTraversal();
        }
        public void PostorderTraversal()
        {
            if (Left != null)
                Left.InOrderTraversal();
            if (Right != null)
                Right.InOrderTraversal();
            Console.Write(this.Data + " ");
        }
        public Nullable<int> SmallestValue()
        {
            if (Left == null)
                return Data;
            else
                return Left.SmallestValue();
        }
        public Nullable<int> LargestValue()
        {
            if (Right == null)
                return Data;
            else
                return Right.LargestValue();
        }
        public int NumberOfLeafNodes()
        {
            if (this.Left == null && this.Right == null)
                return 1; // leaf node
            int leftLeaves = 0;
            int rightLeaves = 0;
            if (this.Left != null)
                leftLeaves = this.Left.NumberOfLeafNodes();
            if (this.Right != null)
                rightLeaves = this.Right.NumberOfLeafNodes();
            return leftLeaves + rightLeaves;
        }
        public int Height()
        {
            if (this.Left == null && this.Right == null)
                return 1; // leaf node
            int left = 0;
            int right = 0;
            if (this.Left != null)
                left = this.Left.Height();
            if (this.Right != null)
                right = this.Right.Height();
            if (left > right)
                return left + 1;
            else
                return right + 1;
        }

    }
}
