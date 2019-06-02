using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_105_ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            using (var db = new ToDoModel())
            {
                UserSelection.Items.Clear();
                foreach (var c in db.Users)
                {
                    UserSelection.Items.Add(c.UserName);
                    DoneInput.IsReadOnly = true;
                }
                foreach (var b in db.Categories)
                {
                    TypeInput.Items.Add(b.CategoryName);
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Add.Content.ToString() == "Add Task")
            {
                NameInput.IsReadOnly = false;
                //StartInput.IsReadOnly = false;
                //EndInput.IsReadOnly = false;
                TypeInput.IsReadOnly = false;
                Add.Content = "Save Changes";
                Delete.IsEnabled = false;
                Edit.IsEnabled = false;
            }
            else
            {
                using (var db = new ToDoModel())
                {
                    Add.Content = "Add Task";
                    Delete.IsEnabled = true;
                    Edit.IsEnabled = true;
                    Task added = new Task();
                    added.TaskDescription = NameInput.Text;
                    if (EndInput.Text.ToString() != "")
                        added.Done = true;
                    else if (EndInput.Text.ToString() == "")
                        added.Done = false;
                    else
                        added.Done = null;
                    added.DateStarted = Convert.ToDateTime(StartInput.Text.ToString());
                    if (EndInput.Text.ToString() != "")
                        added.DateFinished = Convert.ToDateTime(EndInput.Text.ToString());
                    else
                        added.DateFinished = null;
                    if (TypeInput.Text.ToString() != null)
                        added.CategoryID = db.Categories.Where(c=>c.CategoryName== TypeInput.SelectedValue.ToString()).First().CategoryID;
                    added.UserID = db.Users.Where(u => u.UserName == UserSelection.SelectedValue.ToString()).First().UserID;
                    db.Tasks.Add(added);
                    db.SaveChanges();
                    Refresh();
                    NameInput.IsReadOnly = true;
                    //StartInput.IsReadOnly = true;
                    //EndInput.IsReadOnly = true;
                    TypeInput.IsReadOnly = true;
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Edit.Content.ToString() == "Edit Task")
            {
                NameInput.IsReadOnly = false;
                //StartInput.IsReadOnly = false;
                //EndInput.IsReadOnly = false;
                TypeInput.IsReadOnly = false;
                Edit.Content = "Save Changes";
                Delete.IsEnabled = false;
                Add.IsEnabled = false;
            }
            else
            {
                using (var db = new ToDoModel())
                {
                    Edit.Content = "Edit Task";
                    Delete.IsEnabled = true;
                    Add.IsEnabled = true;
                    Task CurrentTask = (Task)ListBox02.SelectedItem;
                    Task task = db.Tasks.Where(t => t.TaskId == CurrentTask.TaskId).First();
                    task.TaskDescription = NameInput.Text;
                    if (EndInput.Text.ToString() != "") { 
                        task.Done = true;
                    }
                    else if (EndInput.Text.ToString() == "")
                        task.Done = false;
                    else
                        task.Done = null;
                    task.DateStarted = Convert.ToDateTime(StartInput.Text.ToString());
                    if (EndInput.Text.ToString() != "")
                        task.DateFinished = Convert.ToDateTime(EndInput.Text.ToString());
                    else
                        task.DateFinished = null;
                    if (TypeInput.Text.ToString() != null)
                        task.CategoryID = db.Categories.Where(c => c.CategoryName == TypeInput.SelectedValue.ToString()).First().CategoryID;
                    db.SaveChanges();
                    Refresh();
                    NameInput.IsReadOnly = true;
                    //StartInput.IsReadOnly = true;
                    //EndInput.IsReadOnly = true;
                    TypeInput.IsReadOnly = true;
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Delete.Content.ToString() == "Delete Task")
            {
                NameInput.IsReadOnly = false;
                //StartInput.IsReadOnly = false;
                //EndInput.IsReadOnly = false;
                TypeInput.IsReadOnly = false;
                Delete.Content = "Save Changes";
                Edit.IsEnabled = false;
                Add.IsEnabled = false;
            }
            else
            {
                using (var db = new ToDoModel())
                {
                    Delete.Content = "Delete Task";
                    Edit.IsEnabled = true;
                    Add.IsEnabled = true;
                    Task CurrentTask = (Task)ListBox02.SelectedItem;
                    Task task = db.Tasks.Where(t => t.TaskId == CurrentTask.TaskId).First();
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                    Refresh();
                    NameInput.IsReadOnly = true;
                    //StartInput.IsReadOnly = true;
                    //EndInput.IsReadOnly = true;
                    TypeInput.IsReadOnly = true;
                }
            }
        }

        private void UserSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new ToDoModel())
            {
                Refresh();
            }
        }

        private void ListBox02_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new ToDoModel())
            {
                if (ListBox02.SelectedItem != null)
                {
                    EndInput.Text = "";
                    Task task = (Task)ListBox02.SelectedItem;
                    NameInput.Text = task.TaskDescription;
                    if (task.DateFinished != null)
                        DoneInput.Text = "Completed";
                    else
                        DoneInput.Text = "Outstanding";
                    StartInput.Text = task.DateStarted.ToString();
                    EndInput.Text = task.DateFinished.ToString();
                    TypeInput.Text = db.Categories.Where(c=>c.CategoryID==task.CategoryID).First().CategoryName;
                }
            }
        }

        public void Refresh()
        {
            using (var db = new ToDoModel())
            {
                int id = db.Users.Where(u => u.UserName == UserSelection.SelectedValue.ToString()).First().UserID;
                List<Task> tasks = db.Tasks.Where(t => t.UserID == id).ToList();
                ListBox01.Items.Clear();
                ListBox03.Items.Clear(); 
                for(int i= 0; i<= tasks.Count-1;i++)
                {
                    ListBox01.Items.Add(i+1);
                    if (tasks[i].DateFinished.ToString() != "")
                    {
                        ListBox03.Items.Add("Completed");
                    }
                    else if (tasks[i].DateFinished.ToString() == "")
                        ListBox03.Items.Add("Outstanding");
                    else
                        ListBox03.Items.Add(null);
                }
                ListBox04.DisplayMemberPath = "DateStarted";
                ListBox04.ItemsSource = tasks;
                ListBox05.DisplayMemberPath = "DateFinished";
                ListBox05.ItemsSource = tasks;
                ListBox02.DisplayMemberPath = "TaskDescription";
                ListBox02.ItemsSource = tasks;
                var query = from task in tasks
                            join categ in db.Categories on task.CategoryID equals categ.CategoryID
                            select categ.CategoryName;
                ListBox06.ItemsSource = query;
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ToDoModel())
            {
                User newuser = new User();
                newuser.UserName = UserInput.Text;
                db.Users.Add(newuser);
                db.SaveChanges();
                Initialize();
            }
        }
    }
}
