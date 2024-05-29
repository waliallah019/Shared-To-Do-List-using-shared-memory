using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Windows.Forms;

namespace OS_Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeDataGridView();
                // Read tasks from the file
                LoadFromSharedMemory();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Tasks file not found: " + ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading tasks file: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Unauthorized access to shared memory: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
        }
        private void LoadFromSharedMemory()
        {
            try
            {
                string[] tasks = File.ReadAllLines("tasks.txt");

                // Combine tasks into a single string separated by new lines
                string tasksText = string.Join(Environment.NewLine, tasks);

                // Convert the tasks text to bytes
                byte[] buffer = Encoding.UTF8.GetBytes(tasksText);

                // Write the bytes to shared memory
                SharedMemoryManager.Accessor.WriteArray(0, buffer, 0, buffer.Length);

                // Load data into the grid view to reflect the tasks
                LoadDataIntoGridView();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mainPage = new MainPage();
            mainPage.Show();
        }

        private void addTask_Click(object sender, EventArgs e)
        {
            string text = taskTB.Text.Trim();
            string userName = MainPage.UserName;  // Get the user's name
            string taskWithUser = $"{userName}: {text}";  // Combine user name and task text

            try
            {
                // Open or create the file for permanent storage
                using (StreamWriter sw = new StreamWriter("tasks.txt", true))
                {
                    sw.WriteLine(taskWithUser);
                }

                // Read the existing bytes from shared memory
                byte[] existingBuffer = new byte[SharedMemoryManager.Accessor.Capacity];
                SharedMemoryManager.Accessor.ReadArray(0, existingBuffer, 0, existingBuffer.Length);

                // Convert the bytes to a string using UTF-8 encoding and trim trailing null characters
                string existingText = Encoding.UTF8.GetString(existingBuffer).TrimEnd('\0');

                // Calculate the length of the existing data in bytes
                long existingLength = Encoding.UTF8.GetByteCount(existingText);

                // Convert the new task text to bytes
                byte[] newTaskBuffer = Encoding.UTF8.GetBytes(Environment.NewLine + taskWithUser);

                // Check if the new task data will fit within the capacity of the accessor
                if (existingLength + newTaskBuffer.Length <= SharedMemoryManager.Accessor.Capacity)
                {
                    // Write the new task bytes to shared memory starting from the end of existing data
                    SharedMemoryManager.Accessor.WriteArray(existingLength, newTaskBuffer, 0, newTaskBuffer.Length);

                    // Indicate successful creation
                    MessageBox.Show("New task added successfully.");
                    ReadFromSharedMemory();
                    LoadDataIntoGridView();
                }
                else
                {
                    // Reinitialize the accessor with the new required capacity
                    SharedMemoryManager.ReinitializeAccessor(existingLength + newTaskBuffer.Length);

                    // Write the existing and new task data to the resized shared memory
                    byte[] combinedBuffer = Encoding.UTF8.GetBytes(existingText + Environment.NewLine + taskWithUser);
                    SharedMemoryManager.Accessor.WriteArray(0, combinedBuffer, 0, combinedBuffer.Length);

                    MessageBox.Show("New task added successfully after resizing shared memory.");
                    ReadFromSharedMemory();
                    LoadDataIntoGridView();
                }
            }
            catch (IOException ex)
            {
                // Handle IOException
                MessageBox.Show("Error creating shared memory: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle UnauthorizedAccessException
                MessageBox.Show("Error creating shared memory: " + ex.Message);
            }
        }

        private string ReadFromSharedMemory()
        {
            string text = "";

            try
            {
                // Read the bytes from shared memory
                byte[] buffer = new byte[SharedMemoryManager.Accessor.Capacity];
                SharedMemoryManager.Accessor.ReadArray(0, buffer, 0, buffer.Length);

                // Convert the bytes to string using UTF-8 encoding
                text = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
            }
            catch (FileNotFoundException ex)
            {
                // Handle FileNotFoundException (shared memory doesn't exist)
                MessageBox.Show("Shared memory not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("Error reading from shared memory: " + ex.Message);
            }

            MessageBox.Show(text);
            return text;
        }

        private void LoadDataIntoGridView()
        {
            try
            {
                // Read the bytes from shared memory
                byte[] buffer = new byte[SharedMemoryManager.Accessor.Capacity];
                SharedMemoryManager.Accessor.ReadArray(0, buffer, 0, buffer.Length);

                string text = Encoding.UTF8.GetString(buffer).TrimEnd('\0');

                // Split the text into lines
                string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                // Clear existing rows in the grid view
                Tasks.Rows.Clear();

                // Add each task to a new row in the grid view
                foreach (string line in lines)
                {
                    // Extract task details
                    string[] parts = line.Split(new[] { ": " }, 2, StringSplitOptions.None);
                    string addedBy = parts[0];
                    string taskDescription = parts.Length > 1 ? parts[1] : "";

                    string markedBy = "";
                    string status = "Not Done";

                    if (taskDescription.Contains("[Done]"))
                    {
                        int doneIndex = taskDescription.IndexOf("[Done]");
                        markedBy = taskDescription.Substring(doneIndex + "[Done]".Length).Trim();
                        taskDescription = taskDescription.Substring(0, doneIndex).Trim();
                        status = "Done";
                    }

                    // Add the task to a new row
                    Tasks.Rows.Add(taskDescription, addedBy, markedBy, status);
                }

                sizeset();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Shared memory not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data into grid view: " + ex.Message);
            }
        }

        private void sizeset()
        {
            for (int i = 0; i < Tasks.Columns.Count; i++)
            {
                Tasks.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void completeTask_Click(object sender, EventArgs e)
        {
            if (Tasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to mark as done.");
                return;
            }

            // Get the index of the selected row
            int selectedIndex = Tasks.SelectedRows[0].Index;

            // Get the task description from the selected row
            string taskDescription = Tasks.Rows[selectedIndex].Cells[0].Value.ToString().Trim('\0');

            try
            {
                // Read the bytes from shared memory
                byte[] buffer = new byte[SharedMemoryManager.Accessor.Capacity];
                SharedMemoryManager.Accessor.ReadArray(0, buffer, 0, buffer.Length);

                // Convert the bytes to string using UTF-8 encoding
                string text = Encoding.UTF8.GetString(buffer).Trim('\0');

                // Update the text to mark the task as done
                string updatedText = text.Replace(taskDescription, taskDescription + " [Done] " + MainPage.UserName);

                // Convert the updated text back to bytes
                byte[] updatedBuffer = Encoding.UTF8.GetBytes(updatedText);

                // Write the updated bytes to shared memory
                if (updatedBuffer.Length > buffer.Length)
                {
                    // Reinitialize the accessor with the new required capacity
                    SharedMemoryManager.ReinitializeAccessor(updatedBuffer.Length);
                }

                // Write the updated bytes to shared memory
                SharedMemoryManager.Accessor.WriteArray(0, updatedBuffer, 0, updatedBuffer.Length);

                // Update the file storage
                string[] lines = File.ReadAllLines("tasks.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    // Split the line to separate the username and task description
                    string[] parts = lines[i].Split(new[] { ": " }, 2, StringSplitOptions.None);
                    if (parts.Length == 2 && parts[1] == taskDescription)
                    {
                        lines[i] = parts[0] + ": " + parts[1] + " [Done] " + MainPage.UserName;
                        break;
                    }
                }
                File.WriteAllLines("tasks.txt", lines);

                // Reload data into the grid view to reflect the changes
                LoadDataIntoGridView();

                MessageBox.Show("Task marked as done successfully.");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Shared memory not found: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Unauthorized access to shared memory: " + ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show("IO error while accessing shared memory: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error marking task as done: " + ex.Message);
            }
        }

        private void TaskTB_TextChanged(object sender, EventArgs e)
        {
        }

        private void deleteTask_Click(object sender, EventArgs e)
        {
            if (Tasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            // Get the index of the selected row
            int selectedIndex = Tasks.SelectedRows[0].Index;

            // Get the task description from the selected row
            string taskDescription = Tasks.Rows[selectedIndex].Cells[0].Value.ToString().Trim();
            string addedBy = Tasks.Rows[selectedIndex].Cells[1].Value.ToString().Trim();

            // Combine to find the exact line in tasks file
            string taskToDelete = $"{addedBy}: {taskDescription}";

            try
            {
                // Read the bytes from shared memory
                byte[] buffer = new byte[SharedMemoryManager.Accessor.Capacity];
                SharedMemoryManager.Accessor.ReadArray(0, buffer, 0, buffer.Length);

                // Convert the bytes to string using UTF-8 encoding
                string text = Encoding.UTF8.GetString(buffer).Trim('\0');

                // Remove the entire line corresponding to the task description
                string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string updatedText = string.Join(Environment.NewLine, lines.Where(line => line != taskToDelete));

                // Convert the updated text back to bytes
                byte[] updatedBuffer = Encoding.UTF8.GetBytes(updatedText);

                // Reinitialize the accessor with the new required capacity if needed
                if (updatedBuffer.Length > buffer.Length)
                {
                    SharedMemoryManager.ReinitializeAccessor(updatedBuffer.Length);
                }

                // Clear the old data in shared memory
                SharedMemoryManager.Accessor.WriteArray(0, new byte[SharedMemoryManager.Accessor.Capacity], 0, (int)SharedMemoryManager.Accessor.Capacity);

                // Write the updated bytes to shared memory
                SharedMemoryManager.Accessor.WriteArray(0, updatedBuffer, 0, updatedBuffer.Length);

                // Update the file storage
                string[] fileLines = File.ReadAllLines("tasks.txt");
                fileLines = fileLines.Where(line => line != taskToDelete).ToArray();
                File.WriteAllLines("tasks.txt", fileLines);

                // Reload data into the grid view to reflect the changes
                LoadDataIntoGridView();
                MessageBox.Show("Task deleted successfully.");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Shared memory not found: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Unauthorized access to shared memory: " + ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show("IO error while accessing shared memory: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting task: " + ex.Message);
            }
        }



        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            Tasks.Columns.Clear();

            // Add columns
            Tasks.Columns.Add("Task", "Task");
            Tasks.Columns.Add("AddedBy", "Added By");
            Tasks.Columns.Add("MarkedBy", "Marked By");
            Tasks.Columns.Add("Status", "Status");

            // Set the column width to fill the DataGridView
            foreach (DataGridViewColumn column in Tasks.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


    }

}
