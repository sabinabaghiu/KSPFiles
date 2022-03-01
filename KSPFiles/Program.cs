namespace KSPFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Projects\KSPFiles\KSPFiles\persistent.sfs";
            string rootName = null;
            MyTreeNode rootNode = null;
            MyTreeNode currentNode = null;
            MyTreeNode parentNode = null;

            foreach (string line in File.ReadLines(filePath)) {
                if (line.Trim() == "{") {
                    continue;
                }
                
                if (line.Trim() == "}") {
                    currentNode = parentNode;
                    // this should only happen at the end of the file, hopefully
                    if (currentNode == null) {
                        parentNode = null;
                    }
                    else {
                        parentNode = currentNode.ParentNode; 
                    }
                    continue;
                }

                if (!line.Contains("=")) {
                    if (rootNode == null)
                    {
                        rootName = line.Trim();
                        rootNode = new MyTreeNode(null);
                        parentNode = rootNode;
                        currentNode = rootNode;
                    } else {
                        parentNode = currentNode;
                        currentNode = new MyTreeNode(parentNode);
                        parentNode.NodeChildren.Add(new MyObject(line.Trim(), currentNode));
                    }
                    continue;
                }

                string[] keyValue = line.Split(" = ");
                currentNode.NodeChildren.Add(new MyObject(keyValue[0], keyValue[1]));
            }

            Console.WriteLine("--------------------");
            Console.WriteLine(rootName);
            printTree(rootNode, 1);
        }

        static void printTree(MyTreeNode root, int depth)
        {
            foreach (MyObject nodeChild in root.NodeChildren) {
                printDepth(depth);
                if (nodeChild.Value is MyTreeNode) {
                    Console.WriteLine("- " + nodeChild.Key);
                    printTree((MyTreeNode) nodeChild.Value, depth + 1);
                } else {
                    printDepth(depth);
                    Console.WriteLine(nodeChild.Key.Trim() + " = " + nodeChild.Value);
                }
            }
        }

        static void printDepth(int depth) {
            for (int i = 0; i < depth; i++) {
                Console.Write("   ");
            }
        }
    }
}