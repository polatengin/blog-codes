using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Tree<T>
{
    public Node<T> Top { get; set; }

    public void Add(params T[] values)
    {
        if (values == null || !values.Any())
        {
            throw new ArgumentOutOfRangeException("Please fill values parameter, or it'll throw an exception!");
        }

        var _values = new List<T>(values);
        var middle = _values.OrderBy(e => e).Skip(_values.Count / 2).First();
        _values.Remove(middle);
        _values.Insert(0, middle);

        foreach (var value in values)
        {
            if (this.Top == null)
            {
                Top = new Node<T>() { Value = value };

                continue;
            }

            var current = this.Top;
            var added = false;

            do
            {
                if (Comparer<T>.Default.Compare(value, current.Value) == -1)
                {
                    // go for left
                    if (current.Left == null)
                    {
                        current.Left = new Node<T>() { Value = value };
                        added = true;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                else
                {
                    // go for right
                    if (current.Right == null)
                    {
                        current.Right = new Node<T>() { Value = value };
                        added = true;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            } while (!added);
        }
    }

    public string Display()
    {
        return DisplayRecursive(this.Top, 12);
    }

    private string DisplayRecursive(Node<T> node, int indent)
    {
        var result = node.Value.ToString().PadLeft(indent) + Environment.NewLine;

        if(node.Left != null)
        {
            indent -= 2;
            result += DisplayRecursive(node.Left, indent).PadLeft(indent);
        }

        if(node.Right != null)
        {
            indent += 2;
            result += DisplayRecursive(node.Right, indent).PadLeft(indent);
        }

        return result;
    }
}
