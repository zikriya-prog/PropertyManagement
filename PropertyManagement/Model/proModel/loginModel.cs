using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Model.proModel
{
    public static class loginModel
    {
        public static ObjectParameter PARM_USER_ID = new ObjectParameter("PARM_USER_ID", typeof(string));
        public static ObjectParameter PARM_FULL_USER_NAME = new ObjectParameter("PARM_FULL_USER_NAME", typeof(string));
        public static ObjectParameter PARM_USER_ROLE = new ObjectParameter("PARM_USER_ROLE", typeof(string));
        public static ObjectParameter PARM_ERROR_MESSAGE = new ObjectParameter("PARM_ERROR_MESSAGE", typeof(string));
        public static List<tbl_userMenu> userMenus;
        public static List<tbl_Menu> Menus;

        public static string GetFormNameByTag(string tag)
        {
            tbl_Menu menu = Menus.FirstOrDefault(x => x.MenuId == tag);
            return menu!=null?menu.NAME:"";
        }
    }
}
