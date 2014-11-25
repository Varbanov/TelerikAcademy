
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.TodoList
{
    public partial class Todo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> CategoriesList_GetData()
        {
            var context = new TODOListEntities();

            var categories =
                context.Categories;

            return categories;

        }

        protected void ButtonInsertCatrgory_Click(object sender, EventArgs e)
        {
            this.CategoriesList.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CategoriesList_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.CategoriesList.InsertItemPosition = InsertItemPosition.None;
        }

        public void CategoriesList_InsertItem()
        {
            var item = new Todo().Category;
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var context = new TODOListEntities();
                using (context)
                {
                    context.Categories.Add(item);

                    context.SaveChanges();
                }

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesList_DeleteItem(int id)
        {
            var context = new TODOListEntities();
            using (context)
            {
                Category category = context.Categories.FirstOrDefault(c => c.Id == id);

                context.Categories.Remove(category);

                context.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesList_UpdateItem(int id)
        {

            var context = new TODOListEntities();

            using (context)
            {
                Category category = context.Categories.Find(id);
                if (category == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("",
                        String.Format("Product with id {0} was not found", id));
                    return;
                }
                TryUpdateModel(category);
                if (ModelState.IsValid)
                {
                    context.Entry(category).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public IQueryable<Todo> TodosListView_GetData()
        {
            var context = new TODOListEntities();

            if (this.CategoriesList.SelectedDataKey != null)
            {
                int id = int.Parse(this.CategoriesList.SelectedDataKey.Value.ToString());

                return context.Categories.FirstOrDefault(x => x.Id == id).Todos.AsQueryable();
            }
            else
            {
                return null;
            }

        }

        protected void TodosListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.TodosListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonInsertTodo_Click(object sender, EventArgs e)
        {
            this.TodosListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TodosListView.DataBind();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void TodosListView_UpdateItem(int id)
        {
            var context = new TODOListEntities();

            using (context)
            {
                Todo todo = context.Todos.Find(id);
                if (todo == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("",
                        String.Format("Product with id {0} was not found", id));
                    return;
                }
                TryUpdateModel(todo);
                if (ModelState.IsValid)
                {
                    todo.DateOfLastChange = DateTime.Now;
                    context.Entry(todo).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void TodosListView_InsertItem()
        {
            var item = new Todo();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                item.DateOfLastChange = DateTime.Now;

                var context = new TODOListEntities();
                using (context)
                {
                    context.Todos.Add(item);
                    context.SaveChanges();
                }

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void TodosListView_DeleteItem(int id)
        {
            var context = new TODOListEntities();

            using (context)
            {
                var todo = context.Todos.FirstOrDefault(t => t.Id == id);
                context.Todos.Remove(todo);
                context.SaveChanges();
            }
        }
    }
}