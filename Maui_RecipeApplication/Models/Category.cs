using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_RecipeApplication.Models
{
    public class Category
    {
        
        [JsonProperty("idCategory")] 
        public string Id { get; set; }

        [JsonProperty("strCategory")] 
        public string Name { get; set; }
        
        [JsonProperty("strCategoryThumb")] 
        public string Image { get; set; }
        
        [JsonProperty("strCategoryDescription")] 
        public string Description { get; set; }

    }

    public class CategoryList
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
