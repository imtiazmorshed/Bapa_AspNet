using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface IItemFacade
    {
        //Item
        List<Item> GetItemAll();
        Item GetItemByID(long id);
        List<Item> GetItemListByCategoryID(long categoryID);

        //Department
        List<Inv_Department> GetDepartmentAll();
        Inv_Department GetDepartmentByID(long id);

        //Category
        List<Inv_Category> GetCategoryAll();
        List<Inv_Category> GetCategoryListByDepartmentID(long departmentID);
        Inv_Category GetCategoryByID(long id);


        void Dispose();
    }

    class ItemFacade:BaseFacade,IItemFacade
    {
        public ItemFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region IItemFacade Members
        #region Item
        public List<Item> GetItemAll()
        {
            List<Item> itemList = new List<Item>();
            List<Item> itemListNew = new List<Item>();
            itemList = Database.Items.Where(i => i.IsRemoved == 0).ToList();
            foreach(Item item in itemList)
            {
                item.MeasurementUnit = item.MeasurementUnit;
                item.ItemQuantity = item.ItemQuantity;
                item.Inv_Category = item.Inv_Category;
                item.Inv_Category.Inv_Department = item.Inv_Category.Inv_Department; 
                itemListNew.Add(item);
            }
            return itemListNew;
        }

        public Item GetItemByID(long id)
        {
            Item item = new Item();
            item= Database.Items.Single(i => i.IID == id && i.IsRemoved == 0);
            item.MeasurementUnit = item.MeasurementUnit;
            return item;
        }

        public List<Item> GetItemListByCategoryID(long categoryID)
        {
            List<Item> itemList = new List<Item>();
            List<Item> itemListNew = new List<Item>();
            itemList = GetItemAll().Where(i => i.CategoryID == categoryID).ToList();
            foreach (Item item in itemList)
            {
                item.MeasurementUnit = item.MeasurementUnit;
                item.ItemQuantity = item.ItemQuantity;
                itemListNew.Add(item);
            }
            return itemListNew;
        }



        #endregion
        
        #region Category

        public List<Inv_Category> GetCategoryAll()
        {
            List<Inv_Category> categoryList = new List<Inv_Category>();
            List<Inv_Category> categoryListNew = new List<Inv_Category>();
            categoryList = Database.Inv_Categories.Where(c => c.IsRemoved == 0).ToList();
            foreach (Inv_Category category in categoryList)
            {
                category.Inv_Department= category.Inv_Department;

                categoryListNew.Add(category);
            }
            return categoryListNew;
        }

        public Inv_Category GetCategoryByID(long id)
        {
            Inv_Category category = new Inv_Category();
            category = Database.Inv_Categories.Single(c => c.IID == id && c.IsRemoved == 0);
            category.Inv_Department = category.Inv_Department;
            return category;
        }

        public List<Inv_Category> GetCategoryListByDepartmentID(long departmentID)
        {
            List<Inv_Category> categoryList = new List<Inv_Category>();
            List<Inv_Category> categoryListNew = new List<Inv_Category>();
            categoryList = GetCategoryAll().Where(i => i.DepartmentID == departmentID).ToList();
            foreach (Inv_Category category in categoryList)
            {
                category.Inv_Department = category.Inv_Department;

                categoryListNew.Add(category);
            }
            return categoryListNew;
        }

        #endregion
        
        #region Department

        public List<Inv_Department> GetDepartmentAll()
        {
            List<Inv_Department> departmentList = new List<Inv_Department>();
            departmentList = Database.Inv_Departments.Where(d => d.IsRemoved == 0).ToList();

            return departmentList;
        }

        public Inv_Department GetDepartmentByID(long id)
        {
            Inv_Department department = new Inv_Department();
            department = Database.Inv_Departments.Single(i => i.IID == id && i.IsRemoved == 0);
            
            return department;
        }
        
        #endregion
        
        
        
        
        
        #endregion
    }
}
