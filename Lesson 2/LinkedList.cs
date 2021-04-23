using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedList
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        public class ListMethod : ILinkedList
        {
            private Node head;
            private Node tail;
            private int count;

            LinkedList<int> list = new LinkedList<int>();

            public void AddNode(int value)
            {
                var Node = new Node { Value = value };

                //Запись первого элемента, при отсутствии других
                if (head == null)
                {
                    head = Node;
                }
                // При наличии других элементов, осуществляем запись в конец списка
                else
                {
                    tail.NextNode = Node;
                    Node.PrevNode = tail;
                }

                tail = Node;
                count++;
            }

            public void AddNodeAfter(Node node, int value)
            {
                Node newNode = new Node { Value = value, PrevNode = node, NextNode = node.NextNode };
                node.NextNode = newNode;
                count++;
            }

            public Node FindNode(int searchValue)
            {
                var currentNode = head;

                while (currentNode != null)
                {

                    if (currentNode.Value == searchValue)
                    {
                        return currentNode;
                    }

                    currentNode = currentNode.NextNode;
                }
                return null;
            }

            public int GetCount()
            {
                return count;
            }

            public void RemoveNode(int index)
            {
                Node current = head;

                for (int i = 0; i < index; i++)
                {
                    current = current.NextNode;
                }

                if (current == null)
                {
                    return;
                }
                if (current.NextNode != null)
                {
                    current.NextNode.PrevNode = current.PrevNode;
                }
                else
                {
                    tail = current.PrevNode;
                }
                if (current.PrevNode != null)
                {
                    current.PrevNode.NextNode = current.NextNode;
                }
                else
                {
                    head = current.NextNode;
                }
                count--;
            }

            public void RemoveNode(Node node)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Value.Equals(node))
                    {
                        break;
                    }
                    current = current.NextNode;
                }
                if (current != null)
                {
                    if (current.NextNode != null)
                    {
                        current.NextNode.PrevNode = current.PrevNode;
                    }
                    else
                    {
                        tail = current.PrevNode;
                    }

                    if (current.PrevNode != null)
                    {
                        current.PrevNode.NextNode = current.NextNode;
                    }
                    else
                    {
                        head = current.NextNode;
                    }
                    count--;
                }
            }
        }

        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }
    }
}
