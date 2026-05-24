ToDoList is a desktop application built with C# and Windows Forms for managing tasks and projects. It presents a simple, Kanban-style interface to help users visualize their workflow and track the progress of tasks from creation to completion.

Features
Task Management: Create tasks with a name, detailed description, assigned person, and a specific due date.
Kanban Board: Organize tasks across three status columns: "Did-not Start," "Under-Construction," and "Construction Has Completed."
Workflow Progression: Move tasks between columns using navigation buttons on each task card to reflect their current status.
Due Date Visualization: Task cards are automatically color-coded based on proximity to the due date for an at-a-glance status check:
Green: Due in 10 or more days.
Orange: Due in less than 10 days.
Red: Due in less than 5 days.
Gray: Overdue.
Project Persistence: Save the entire state of your task board, including all tasks and their statuses, to a binary (.bin) file.
Load Projects: Open and continue working on previously saved projects.
Tech Stack
C#
.NET Framework 4.8
Windows Forms
Getting Started
Prerequisites
.NET Framework 4.8
An IDE like Visual Studio
Running the Application
Clone the repository to your local machine.
Open the ToDoList.sln file in Visual Studio.
Build the solution to restore dependencies.
Run the project (Press F5 or click the Start button). The application will automatically create a Projects directory within the build output folder (e.g., bin/Debug/Projects) for saving and loading project files.
How to Use
Add a Task: Click the Add New Task button. Fill in the task details in the form that appears and click Save. Input is validated to ensure all fields are completed and the due date is in the future.
Manage Workflow: The new task will appear in the "Did-not Start" column. Use the > and < buttons on the task card to move it through the workflow stages.
Save Your Board: Enter a name for your project in the "Project Name" text box and click Save Project. The current board state will be saved to a .bin file in the Projects directory.
Load a Board: Click Open Project and select a previously saved .bin file to load its tasks and statuses onto the board.
