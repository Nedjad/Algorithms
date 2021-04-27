using System;

namespace Lesson_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myNewTree = new Node();
            myNewTree.AddItem(30);
            myNewTree.AddItem(25);
            myNewTree.AddItem(41);
            myNewTree.AddItem(20);
            myNewTree.AddItem(27);
            myNewTree.AddItem(50);
            myNewTree.AddItem(35);
            myNewTree.AddItem(61);
            myNewTree.AddItem(40);
            myNewTree.AddItem(28);
            myNewTree.AddItem(15);
            myNewTree.AddItem(34);
            myNewTree.AddItem(26);

            myNewTree.PrintMethodThree(myNewTree);





        }
    }
}
