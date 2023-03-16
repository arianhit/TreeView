using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OO_Coding_Test
{
    public class Node
    {
        // An instance of the "OutputOperater" class is used to print messages to the console
        public OutputOperater op = new OutputOperater();

        // The name of the node, which can be set and accessed through a property
        public string Name { get; set; }

        // A collection of child nodes, which can be accessed through a property
        public List<Node> Collection { get; set; }

        // The parent node of this node, which can be accessed through a property
        public Node Parent { get; set; }

        // A static property that stores the root node of the tree
        public static Root RootNode { get; set; }

        // Constructor that sets the name and initializes the child node collection
        public Node(string name)
        {
            Name = name;
            Collection = new List<Node>();
        }

        // Method that adds a child node to the collection
        public virtual void AddSubset(Node subset)
        {
            // If the child node is a root node, it cannot be added to a folder or another root node
            if (subset is Root)
            {
                op.outPutError("Cannot add a root node to a folder or another root node.");
            }
            else
            {
                // Add the child node to the collection and print a message to the console
                Collection.Add(subset);
                op.makeItColor(ConsoleColor.Green, subset.Name + " Added!\n");
            }
        }

        // Method that removes a child node from the collection
        public virtual void RemoveSubset(Node subset)
        {
            // Remove the child node from the collection and print a message to the console
            Collection.Remove(subset);
            op.makeItColor(ConsoleColor.Green, subset.Name + " Removed!\n");
        }

        // Method that moves the node to a new parent node
        public virtual void MoveTo(Node newParent)
        {
            // If trying to move to self, do nothing
            if (newParent == this)
            {
                return;
            }

            // If trying to move to the root node, print an error message
            if (newParent is Root)
            {
                op.outPutError("Cannot move a node to the root");
            }

            // If trying to move to a folder, remove from current parent and add to new parent
            if (newParent is Folder)
            {
                Parent?.RemoveSubset(this);
                newParent.AddSubset(this);
                Parent = newParent;
                op.makeItColor(ConsoleColor.Green, this.Name + " Moved to " + newParent.Name + "\n");
            }
            else
            {
                // If trying to move to an item, print an error message
                op.outPutError("Cannot move a node to an item ");
            }
        }

        // Method that searches for nodes with a given search term in their name
        public List<Node> Search(string searchTerm)
        {
            // Create a list to store the matches
            List<Node> matches = new List<Node>();

            // Convert the search term to lowercase for case-insensitive search
            searchTerm = searchTerm.ToLower();

            // If the node's name contains the search term, add it to the matches list
            if (Name.ToLower().Contains(searchTerm))
            {
                matches.Add(this);
            }

            // Recursively search child nodes and add any matches to the matches list
            foreach (Node subset in Collection)
            {
                matches.AddRange(subset.Search(searchTerm));
            }

            // Return the resualts of search
            return matches;
        }
    }
}
