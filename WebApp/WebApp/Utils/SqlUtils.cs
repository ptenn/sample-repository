using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Utils
{
    public class SqlUtils
    {
        public IList<Category> FindCategories()
        {
            IDictionary<int, Category> categoryDictionary = new Dictionary<int, Category>();
            IList<Category> categories = new List<Category>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContosoAdsDataSource"].ConnectionString))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Category", conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Category category = new Category();
                                category.Id = (int) reader["Id"];
                                category.Name = (string) reader["Name"];
                                if (System.DBNull.Value != reader["ParentCategoryId"])
                                {
                                    category.ParentCategoryId = (int?) reader["ParentCategoryId"];
                                }
                                
                                categoryDictionary.Add(category.Id, category);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Table not created.");
                }
            }

            // Build out Categories - structured
            foreach (Category category in categoryDictionary.Values)
            {
                if (category.ParentCategoryId.HasValue)
                {
                    Category parentCategory = categoryDictionary[category.ParentCategoryId.Value];
                    if (parentCategory.SubCategories == null)
                    {
                        parentCategory.SubCategories = new List<Category>();
                    }
                    parentCategory.SubCategories.Add(category);
                }
            }

            // Now, all Subcategories are nested under parents
            // Get the Top-level Parents and add them to the List for return
            foreach (Category category in categoryDictionary.Values)
            {
                if (category.ParentCategoryId == null)
                {
                    categories.Add(category);
                }
            }
            
            return categories;
        }
    }
}