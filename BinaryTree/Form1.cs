using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        Tree MyTree;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();//Create random number generator
            int num;// Hold the random number to be added to the tree
            lblArray1.Text = "";//lblArray1 displays the unsorted list number
            label2.Text = "";//label2.Text will be sorted list of numbers from the tree
            num = rnd.Next(0, 100);//set the first item int the tree
            lblArray1.Text = lblArray1.Text + num.ToString().PadLeft(3);// add it to the unsorted list string
            MyTree = new Tree(num);//Create the tree with an initail value equal to the first item generated above

            int n = Convert.ToInt32(textBox1.Text);//get the number of items to store in the tree
            for(int i = 0; i < n; i++)
            {
                num = rnd.Next(0, 100);//generate a random number to be addeto the tree
                lblArray1.Text = lblArray1.Text + num.ToString().PadLeft(3);//add it to the usorted list string
                MyTree.AddRc(num);//add it to the tree by calling the add recursive method of the tree class (addRc)

            }
            string treestring = "";
            MyTree.Print(null, ref treestring);// Call the print method of the tree classto output the sorted list
            label2.Text = treestring;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int initial)
        {
            value = initial;
            left = null;
            right = null;
        }
    }
    class Tree
    {
        Node top;
        public Tree()
        {
            top = null;
        }
        public Tree(int initial)
        {
            top = new Node(initial);
        }
        public void Add(int value)
        {
            //Non-recurse add
            if(top == null)//The tree is null
            {
                //Add item as a base node
                Node NewNode = new Node(value);
                top = NewNode;
                return;
            }
            Node currentnode = top;
            bool added = false;
            do
            {
                //Traverse tree
                if(value < currentnode.value)
                {
                    //go left
                    if(currentnode.left == null)
                    {
                        //Add the item
                        Node NewNode = new Node(value);
                        currentnode.left = NewNode;
                        added = true;
                    }
                    else
                    {
                        currentnode = currentnode.left;
                    }
                }
                if (value >= currentnode.value)
                {
                    if(currentnode.right == null)
                    {
                        Node NewNode = new Node(value);
                        currentnode.right = NewNode;
                        added = true;

                    }else
                    {
                        //go right
                        currentnode = currentnode.right;
                    }
                }
            } while (!added);
        }
        public void AddRc(int value)
        {
            //recurse add
            AddR(ref top, value);

        }

        private void AddR(ref Node N, int value)
        {
            //private recursive search for where to add the new node
            if (N == null)
            {
                //Node doesn't exist add it here
                Node NewNode = new Node(value);
                N = NewNode;//Set the old Node reference to the newly created node thus attaching it to the tree
                return;// End the function call and fall back
            }
            if(value < N.value)
            {
                AddR(ref N.left, value);
                return;
            }
            if (value >= N.value)
            {
                AddR(ref N.right, value);
                return;
            }
        }
        public void Print(Node N, ref string s)
        {
            //Write out the tree in sorted order to the string newstring
            //implement  using recursion
            if (N == null)
            {
                N = top;
            }
            if(N.left != null)
            {
                Print(N.left, ref s);
                s = s + N.value.ToString().PadLeft(3);
            }
            else
            {
                s = s + N.value.ToString().PadLeft(3);
            }
            if(N.right != null)
            {
                Print(N.right, ref s);
            }
        }
    }
}
