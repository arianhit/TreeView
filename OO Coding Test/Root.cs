using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Coding_Test
{
    public class Root : Node
    {
        // Constructor for the Root class.
        public Root(string name) : base(name)
        {
            // Check if a root node already exists. If not, assign this node as the root.
            if (RootNode == null)
            {
                RootNode = this;
            }
            else
            {
                // Output an error message if a root node already exists.
                op.outPutError("Cannot create multiple root nodes.");
            }
        }

        // Method to add a subset to the root node.
        public override void AddSubset(Node subset)
        {
            // Check if the subset being added is a folder.
            if (subset is Folder)
            {
                // Call the base class's AddSubset method to add the subset.
                base.AddSubset(subset);
                // Set the subset's parent to this root node.
                subset.Parent = this;
            }
            else
            {
                // Output an error message if the subset being added is not a folder.
                op.outPutError("Only folder are allowed as collection of the root ");
            }
        }

        // Method to remove a subset from the root node.
        public override void RemoveSubset(Node subset)
        {
            // Call the base class's RemoveSubset method to remove the subset.
            base.RemoveSubset(subset);
        }

        // Method to move the root node to a new parent.
        public override void MoveTo(Node newParent)
        {
            // Output an error message since the root node cannot be moved.
            op.outPutError("Cannot move the root");
        }
    }
}
