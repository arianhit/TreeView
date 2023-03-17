using OO_Coding_Test;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using static System.Net.Mime.MediaTypeNames;

namespace OO_Coding_Test
{
    class Program
    {

        static void Main(string[] args)
        {
            OutputOperater op = new OutputOperater();
            List<Node> nodes = new List<Node>();

            Node parent = null;
            Node subset = null;

            // Create a root node and add it to the list of nodes
            Root root = new Root("Desktop");
            nodes.Add(root);

            // Create some folders and items and add them to the list of nodes
            Folder images = new Folder("Images");
            Folder videos = new Folder("Videos");
            Folder musics = new Folder("Musics");
            Item item1 = new Item("img1");
            Item item2 = new Item("img2");
            Item item3 = new Item("img3");
            Item item4 = new Item("video1");
            Item item5 = new Item("video2");
            Item item6 = new Item("video3");
            nodes.Add(images);
            nodes.Add(videos);
            nodes.Add(musics);
            nodes.Add(item1);
            nodes.Add(item2);
            nodes.Add(item3);
            nodes.Add(item4);
            nodes.Add(item5);
            nodes.Add(item6);

            int chosenOptionNum = -1;
            bool inMenu = true;
            bool validInput = false;
            // Display the main menu and process the user's input until they choose to exit
            Console.WriteLine("***********************Welcom to the tree view file manager ***********************\n\n\n");
            while (inMenu)
            {
                TreeView(); // Display the current state of the tree

                // Display the menu options and get the user's choice
                Console.WriteLine("Please chose an option from below (enter a number for example : 1)\n\n");
                Console.WriteLine("\t1.Add Node");
                Console.WriteLine("\t2.Remove Node");
                Console.WriteLine("\t3.Move Node");
                Console.WriteLine("\t4.Search Node");
                Console.WriteLine("\t5.Test the whole program");
                Console.WriteLine("\t0.Exit");

                try
                {
                    // Validate the user's input and ensure it is a number between 0 and 5
                    while (!validInput)
                    {
                        chosenOptionNum = Convert.ToInt32(Console.ReadLine());
                        if (chosenOptionNum >= 0 && chosenOptionNum <= 5)
                        {
                            validInput = true;
                        }
                        else
                        {
                            op.OutPutError("Please enter a number between 0 to 5!");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    op.OutPutError(e.Message);
                }

                // Process the user's choice
                switch (chosenOptionNum) // switch statement to handle different menu options based on chosenOptionNum variable
                {
                    case 0: // case for exiting the program
                        op.MakeItColor(ConsoleColor.Green, "Thank you for using tree view file manager"); // prints a message to the console
                        inMenu = false; // sets inMenu flag to false to exit the loop and end the program
                        break;
                    case 1: // case for adding a subset to a parent node
                        try // tries to execute the code block
                        {
                            GettingParentAndSubset(); // calls a function to prompt the user for the parent and subset nodes they want to add
                            op.MakeItColor(ConsoleColor.Yellow, "\nAdding node.\n"); // prints a message to the console
                            op.MakeItColor(ConsoleColor.Cyan, subset.Name + " added to " + parent.Name + "\n"); // prints a message to the console with the names of the parent and subset nodes
                            parent.AddSubset(subset); // adds the subset to the parent node
                        }
                        catch (Exception e) // handles any exceptions thrown by the code block
                        {
                            op.OutPutError(e.Message); // prints the error message to the console
                        }
                        validInput = false; // sets the flag to false to exit the loop
                        break;
                    case 3: // case for moving a subset to a different parent node
                        try // tries to execute the code block
                        {
                            GettingParentAndSubset(); // calls a function to prompt the user for the parent and subset nodes they want to move
                            op.MakeItColor(ConsoleColor.Yellow, "\nMoving node.\n"); // prints a message to the console
                            op.MakeItColor(ConsoleColor.Cyan, subset.Name + " Moved to " + parent.Name + "\n"); // prints a message to the console with the names of the parent and subset nodes
                            subset.MoveTo(parent); // moves the subset to the new parent node
                        }
                        catch (Exception e) // handles any exceptions thrown by the code block
                        {
                            op.OutPutError(e.Message); // prints the error message to the console
                        }
                        validInput = false; // sets the flag to false to exit the loop
                        break;
                    case 4: // case for searching for a node by name
                        string searchQuery; // declares a string variable to store the user's search query
                        bool validSearch = false; // declares a boolean flag to track whether a valid search result has been found
                        while (true) // loops until a valid search query is entered or the user cancels the search
                        {
                            Console.WriteLine("\t\tPlease provide name of the Node that you want to search"); // prints a message to the console
                            searchQuery = Console.ReadLine(); // prompts the user to enter a search query and stores it in the searchQuery variable
                            foreach (Node node in nodes) // loops through all the nodes in the tree
                            {
                                if (node.Name == searchQuery || node.Name.ToLower().Contains(searchQuery.ToLower())) // checks if the node's name matches the search query (case-insensitive)
                                {
                                    subset = node; // sets the subset variable to the matching node
                                    validSearch = true; // sets the flag to true to indicate a valid search result has been found
                                }
                            }
                            if (!validSearch) // if no matching node was found, prints an error message to the console
                            {
                                op.OutPutError("The node that you searched is not included");
                            }
                            if (validSearch)
                            {
                                break;
                            }
                        }
                        //prints a message to the console with the search query
                        op.MakeItColor(ConsoleColor.Yellow, "\nSearching ....\n");// prints a message to the console
                        search(searchQuery); // search
                        validInput = false;// sets the flag to false to exit the loop
                        break;
                    case 5:
                        testing();//run the testing function which will test the whole programm
                        op.MakeItColor(ConsoleColor.Green, "Press Enter to continue");// prints a message to the console
                        Console.ReadLine();//to stop the console if user wants to read all the data
                        validInput = false;// sets the flag to false to exit the loop
                        break;
                    default:// default case for handling invalid menu options
                        op.OutPutError("Invalid option!");// prints the error message to the console
                        validInput = false;// sets the flag to false to exit the loop
                        break;

                }

            }


            // This function prompts the user to enter the names of a parent node and a subset node.
            // It then searches the nodes list for the nodes with those names and assigns them to the parent and subset variables.

            bool GettingParentAndSubset()
            {
                try
                {
                    bool parentFounded = false;     // Flag to indicate whether the parent node has been found
                    bool subsetFounded = false;     // Flag to indicate whether the subset node has been found

                    while (true)    // Loop until both nodes have been found
                    {
                        Console.WriteLine("\t\tPlease provide the name of parent of the Node ");
                        string parentName = Console.ReadLine();
                        Console.WriteLine("\t\tPlease provide the name of the subset Node");
                        string theNode = Console.ReadLine();

                        // Search the nodes list for the subset node
                        foreach (Node node in nodes)
                        {
                            if (node.Name == theNode || node.Name.ToLower().Contains(theNode.ToLower()))
                            {
                                subset = node;
                                subsetFounded = true;
                            }
                        }

                        // Search the nodes list for the parent node
                        foreach (Node node in nodes)
                        {
                            if (node.Name.ToLower() == parentName.ToLower() || node.Name.ToLower().Contains(parentName.ToLower()))
                            {
                                parent = node;
                                parentFounded = true;
                            }
                        }

                        // Check if both nodes have been found
                        if (!parentFounded)
                        {
                            op.OutPutError("parent not founded please enter the one of the nodes that has been provided");
                        }
                        if (!subsetFounded)
                        {
                            op.OutPutError("subset not founded please enter the one of the nodes that has been provided");
                        }
                        if (parentFounded && subsetFounded)
                        {
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    op.OutPutError(e.Message);
                }
                return true;
            }
            void testing()
            {
              
                try
                {

                    //Adding folder to the root
                    root.AddSubset(images);
                    root.AddSubset(videos);

                    //adding item to the folders
                    images.AddSubset(item1);
                    images.AddSubset(item2);


                    //adding item to the folders
                    videos.AddSubset(item4);
                    videos.AddSubset(item5);

                    //•	Cannot create multiple root nodes
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nTry to creat another root.\n");
                    op.MakeItColor(ConsoleColor.Cyan, " Creat root1" + "\n");
                    Root root1 = new Root("Driver");



                    //•	Adding and deleting items within a folder.
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nAdding items within a folder.\n");
                    op.MakeItColor(ConsoleColor.Cyan, videos.Name + " add " + item6.Name + "\n");
                    videos.AddSubset(item6);
                    op.MakeItColor(ConsoleColor.Cyan, images.Name + " add " + item3.Name + "\n");
                    images.AddSubset(item3);


                    //•	Items cannot contain anything.
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nTry to add item to another item.\n");
                    op.MakeItColor(ConsoleColor.Cyan, item1.Name + " add " + item3.Name + "\n");
                    item1.AddSubset(item3);


                    //Cannot add root to any node
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nTry to add root to a folder.\n");
                    op.MakeItColor(ConsoleColor.Cyan, videos.Name + " add " + root.Name + "\n");
                    videos.AddSubset(root);

                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nDeleting items within a folder.\n");
                    op.MakeItColor(ConsoleColor.Cyan, item1.Name + " remove from " + images.Name + "\n");
                    images.RemoveSubset(item1);
                    op.MakeItColor(ConsoleColor.Cyan, item5.Name + " remove from " + videos.Name + "\n");
                    videos.RemoveSubset(item5);

                    //Cannot remove item from an item
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nTry to remove item from another item.\n");
                    op.MakeItColor(ConsoleColor.Cyan, item3.Name + " remove from " + item1.Name + "\n");
                    item1.RemoveSubset(item3);


                    //•	Adding and deleting folders.
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nAdding folders.\n");
                    op.MakeItColor(ConsoleColor.Cyan, root.Name + " add " + musics.Name + "\n");
                    root.AddSubset(musics);


                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nTry to add item to the root.\n");
                    op.MakeItColor(ConsoleColor.Cyan, root.Name + " add " + item3.Name + "\n");
                    root.AddSubset(item3);

                    //•	Deleting a folder should delete everything contained in the folder.
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nDeleting folders.\n");
                    op.MakeItColor(ConsoleColor.Cyan, videos.Name + " remove from " + root.Name + "\n");
                    root.RemoveSubset(videos);


                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nSearching item.\n");
                    search("img2");
                    op.MakeItColor(ConsoleColor.Yellow, "\nSearching Folder.\n");
                    search("images");

                    //•	Moving items or folders (along with the contents, it is a folder being moved.)
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nMoving Items.\n");
                    op.MakeItColor(ConsoleColor.Cyan, item2.Name + " moved to " + musics.Name + "\n");
                    item2.MoveTo(musics);


                    //•	Moving a folder should move everything contained within the folder.
                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nMoving Folder.\n");
                    op.MakeItColor(ConsoleColor.Cyan, images.Name + " moved to " + musics.Name + "\n");
                    images.MoveTo(musics);

                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nTry to move root to a folder.\n");
                    op.MakeItColor(ConsoleColor.Cyan, root.Name + " moved to " + musics.Name + "\n");
                    root.MoveTo(musics);

                    TreeView();
                    op.MakeItColor(ConsoleColor.Yellow, "\nTry to move item to a root.\n");
                    op.MakeItColor(ConsoleColor.Cyan, item2.Name + " moved to " + root.Name + "\n");
                    item2.MoveTo(root);

                    TreeView();
                }
                catch (Exception e)
                {
                    op.OutPutError(e.Message);
                }
            }
            // Define a method to display the tree structure
            void TreeView()
            {
                System.Threading.Thread.Sleep(1000);
                // Print some separator lines to improve readability
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------TREE VIEW FILE MANAGER----------------------------------------------------------------");
                Console.WriteLine();

                // Print the name of the root node
                Console.WriteLine("****************" + root.Name + "**********************\n");

                // Iterate over the child nodes of the root node
                foreach (Folder folder in root.Collection)
                {
                    // Print the name of each child node
                    Console.WriteLine("\t****" + folder.Name + "\n");

                    // Iterate over the child nodes of the current child node
                    foreach (var item in folder.Collection)
                    {
                        // Print the name of each grandchild node
                        Console.WriteLine("\t\t**" + item.Name + "\n");

                        // If the current grandchild node has child nodes, iterate over them
                        if (item.Collection.Count > 0)
                        {
                            foreach (var unit in item.Collection)
                            {
                                // Print the name of each great-grandchild node
                                Console.WriteLine("\t\t\t*" + unit.Name + "\n");
                            }
                        }
                    }
                }

                // Print some separator lines to improve readability
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                System.Threading.Thread.Sleep(1000);

            }

            // Define a method to search for a node with a given name within the tree
            void search(string searchQuery)
            {
                // Use a helper method to change the color of the console text
                op.MakeItColor(ConsoleColor.Green, searchQuery + " Searched!");

                // Print some separator lines to improve readability
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Resaults :");

                // Call the Search method of the root node to find all nodes with the given name
                List<Node> matches = root.Search(searchQuery);

                // Iterate over the list of matches and print their names and locations in the tree
                foreach (Node match in matches)
                {
                    if (match.Collection.Count > 0)
                    {
                        // If the current match has child nodes, print their names and locations
                        Console.WriteLine("\t****" + match.Name + "   from: " + root.Name + "/" + match.Parent.Name + "\n");
                        foreach (var unit in match.Collection)
                        {
                            Console.WriteLine("\t\t**" + unit.Name + "   from: " + root.Name + "/" + unit.Parent.Name + "\n");
                        }
                    }
                    else
                    {
                        // If the current match has no child nodes, print its name and location
                        Console.WriteLine("\t\t**" + match.Name + "   from: " + root.Name + "/" + match.Parent.Name + "\n");
                    }
                }

                // Print some separator lines to improve readability
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }
        }

    }
}


