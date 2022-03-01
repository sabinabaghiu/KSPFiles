namespace KSPFiles
{
    public class MyTreeNode
    {
        public IList<MyObject> NodeChildren { get; set; }
        public MyTreeNode ParentNode { get; set; }

        public MyTreeNode(MyTreeNode parentNode)
        {
            ParentNode = parentNode;
            NodeChildren = new List<MyObject>();
        }
        
    }
}