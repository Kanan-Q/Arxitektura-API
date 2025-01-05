using BlogApp.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entites.Category
{
    public class Category:BaseEntity
    {
        public string Name {  get; set; }
        public string Icon {  get; set; }
    }
}
