using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Coding_Test
{
    public class Folder : Node
    {
        // Constructor for the Folder class.
        public Folder(string name) : base(name + " (" + typeof(Folder).Name + ")")
        {
        }

        // Method to add a subset to a folder.
        public override void AddSubset(Node subset)
        {
            // Call the base class's AddSubset method to add the subset.
            base.AddSubset(subset);
            // Set the subset's parent to this folder.
            subset.Parent = this;
        }

        // Method to remove a subset from a folder and its descendants recursively.
        public override void RemoveSubset(Node subset)
        {
            // Remove each of the subset's descendants recursively.
            foreach (Node subOfSubsets in subset.Collection)
            {
                subset.RemoveSubset(subOfSubsets);
            }

            // Call the base class's RemoveSubset method to remove the subset.
            base.RemoveSubset(subset);
        }

        // Method to move a folder to a new parent.
        public override void MoveTo(Node newParent)
        {
            // Remove the folder from its current parent.
            this.Parent.RemoveSubset(this);

            // Add the folder to the new parent.
            newParent.AddSubset(this);

            // Update the folder's parent reference.
            Parent = newParent;

            // Move each of the folder's children to the new parent recursively.
            List<Node> children = new List<Node>(Collection);
            foreach (Node subset in children)
            {
                subset.MoveTo(this);
            }

            // Output a message indicating that the folder was moved to the new parent.
            op.makeItColor(ConsoleColor.Green, this.Name + " Moved to " + newParent.Name);
        }
    }
}
