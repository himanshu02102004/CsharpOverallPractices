//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Logical_ques
//{
   

   



//class Node
//    {
//        public int data;
//        public Node next;

//        public Node(int new_data)
//        {
//            data = new_data;
//            next = null;
//        }
//    }

//    class LinkedList
//    {

//        // Function to get the intersection point of two linked
//        // lists
//        static Node intersectPoint(Node head1,
//                                               Node head2)
//        {
//            HashSet<Node> visitedNodes = new HashSet<Node>();

//            // Traverse the first list and store all nodes in a set
//            Node curr1 = head1;
//            while (curr1 != null)
//            {
//                visitedNodes.Add(curr1);
//                curr1 = curr1.next;
//            }

//            // Traverse the second list and check if any node is
//            // in the set
//            Node curr2 = head2;
//            while (curr2 != null)
//            {

//                // Intersection point found
//                if (visitedNodes.Contains(curr2))
//                    return curr2;
//                curr2 = curr2.next;
//            }

//            return null;
//        }

//        //static void Main(string[] args)
//        //{

//        //    // creation of first list: 10 -> 15 -> 30
//        //    Node head1 = new Node(10);
//        //    head1.next = new Node(15);
//        //    head1.next.next = new Node(30);

//        //    // creation of second list: 3 -> 6 -> 9 -> 15 -> 30
//        //    Node head2 = new Node(3);
//        //    head2.next = new Node(6);
//        //    head2.next.next = new Node(9);

//        //    // 15 is the intersection point
//        //    head2.next.next.next = head1.next;

//        //    Node intersectionPoint = intersectPoint(head1, head2);

//        //    if (intersectionPoint == null)
//        //        Console.WriteLine("-1");
//        //    else
//        //        Console.WriteLine(intersectionPoint.data);
//        //}
//    }
//}
//}
