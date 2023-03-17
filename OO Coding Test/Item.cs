using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Coding_Test
{
    public class Item : Node
    {
        // Constructor for the Item class.
        public Item(string name) : base(name + " (" + typeof(Item).Name + ")")
        {
        }

        // Method to add a subset to an item, which is not allowed.
        public override void AddSubset(Node child)
        {
            // Output an error message since an item cannot have a subset.
            op.OutPutError("Cannot add collection to an item ");
        }

        // Method to remove a subset from an item, which is not allowed.
        public override void RemoveSubset(Node child)
        {
            // Output an error message since an item cannot have a subset to remove.
            op.OutPutError("Item cannot have children");
        }

        // Method to move an item to a new parent.
        public override void MoveTo(Node newParent)
        {
            // Call the base class's MoveTo method to move the item to the new parent.
            base.MoveTo(newParent);
        }
    }
}
